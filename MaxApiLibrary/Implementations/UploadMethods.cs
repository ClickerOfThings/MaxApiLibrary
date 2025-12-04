using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using MaxApiLibrary.Implementations.Extensions;
using MaxApiLibrary.Implementations.InternalClasses;
using MaxApiLibrary.Methods.Upload;
using MaxApiLibrary.Methods.Upload.Responses;
using Microsoft.AspNetCore.Http.Extensions;
using MimeMapping;

namespace MaxApiLibrary.Implementations;

/// <summary>
/// Имплементация API-методов из группы <c>upload</c>
/// </summary>
public class UploadMethods : BaseApiClient, IUploadMethods
{
    /// <inheritdoc />
    public UploadMethods(string accessToken, HttpClient? httpClient = null, CancellationToken? cancellationToken = null) : base(accessToken, httpClient, cancellationToken)
    {
    }

    /// <inheritdoc />
    public async Task<UploadFileResponse> UploadFileAsync(string filePath, UploadTypes type)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("type", Enum.GetName(type)?.ToLower());

        var linkJson = await PostAndDeserializeAsJsonAsync<string, UploadLinkRequestResponse>($"uploads{queryBuilder.ToQueryString()}", "");

        await using var stream = File.OpenRead(filePath);
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(stream)
        {
            // Необходимо для некоторых загрузок, иначе сервер выдаст, что файл в запросе отсутствует
            Headers = { ContentType = MediaTypeHeaderValue.Parse(MimeUtility.GetMimeMapping(filePath)) }
        }, "data", Path.GetFileName(filePath));
        var httpFileUploadResponseMessage = await HttpClient.PostAsync(linkJson.Url, content, CancellationToken);
        var fileUploadResponseString = await httpFileUploadResponseMessage.Content.ReadAsStringAsync(CancellationToken);

        // Возврат <retval> происходит при загрузке видео и аудио файлов, которые, в свою очередь, на этапе
        // запроса ссылки на загрузку файла, сразу же выдают токен, в отличие от загрузки любого другого типа файла
        if (fileUploadResponseString.Contains("<retval>"))
            return new UploadFileResponse
            {
                Token = linkJson.Token!
            };

        // Не все виды загрузок возвращают одну и ту же структуру результата по какой-то причине. Необходимо прибегать
        // к более "динамичному" решению извлечения токена.
        var tokenRegex = Regex.Match(fileUploadResponseString, @"""token""\s*:\s*""(.+?)""");
        if (!tokenRegex.Success)
            throw new ArgumentException($"Couldn't find token field in file upload response. The response JSON: {fileUploadResponseString}");
        var token = Regex.Unescape(tokenRegex.Groups[1].Value);
        return new UploadFileResponse
        {
            Token = token
        };
    }
}
