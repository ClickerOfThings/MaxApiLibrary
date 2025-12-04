using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MaxApiLibrary.Implementations;

/// <summary>
/// Базовый класс для имплементаций API-методов, с инициализацией HTTP клиента
/// </summary>
public abstract class BaseApiClient
{
    private const string BaseApiAddress = "https://platform-api.max.ru";

    /// <summary>
    /// Токен отмены
    /// </summary>
    protected readonly CancellationToken CancellationToken;

    /// <summary>
    /// HTTP клиент
    /// </summary>
    protected readonly HttpClient HttpClient;

    /// <summary>
    /// Настройки JSON сериализатора
    /// </summary>
    protected readonly JsonSerializerOptions JsonSerializerOptions;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="accessToken">Токен бота, генерируемый в <a href="https://business.max.ru/self/#/bot-settings">платформе</a></param>
    /// <param name="httpClient">HTTP-клиент, который будет взят за основу для дальнейших вызовов методов API</param>
    /// <param name="cancellationToken">Токен отмены для асинхронных HTTP запросов</param>
    protected BaseApiClient(string accessToken, HttpClient? httpClient = null, CancellationToken? cancellationToken = null)
    {
        CancellationToken = cancellationToken ?? CancellationToken.None;
        HttpClient = httpClient ?? new HttpClient();

        HttpClient.BaseAddress = new Uri(BaseApiAddress);
        HttpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(accessToken);
        HttpClient.Timeout = Timeout.InfiniteTimeSpan; // Стандартное значение в 100 секунд может сбоить, если пользовать для таймайту Subscription-а выставил большее время

        JsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            AllowOutOfOrderMetadataProperties = true // API выдаёт поле с типом вложения (возможно и в других объектах так же) не самым первым по позиции
        };
    }

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.GetFromJsonAsync{T}(System.Net.Http.HttpClient, string?, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// и дополнительной проверкой JSON-результата на <c>null</c>
    /// </summary>
    protected async Task<TResponse> GetFromJsonAsync<TResponse>(
        [StringSyntax("Uri")] string? requestUri) =>
        await HttpClient.GetFromJsonAsync<TResponse>(requestUri, JsonSerializerOptions, CancellationToken) ??
        throw new JsonException($"The parsed JSON value is null. The GET request URI: {requestUri}");

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.PostAsJsonAsync{T}(System.Net.Http.HttpClient, string?, T, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// и дополнительной проверкой JSON-результата на <c>null</c>
    /// </summary>
    protected async Task<HttpResponseMessage> PostAsJsonAsync<TValue>(
        [StringSyntax("Uri")] string? requestUri,
        TValue value) =>
        await HttpClient.PostAsJsonAsync(requestUri, value, JsonSerializerOptions, CancellationToken);

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.PostAsJsonAsync{T}(System.Net.Http.HttpClient, string?, T, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// вместе с проверкой JSON-результата на <c>null</c> и десериализацией JSON-ответа
    /// </summary>
    protected async Task<TResponse> PostAndDeserializeAsJsonAsync<TRequest, TResponse>(
        [StringSyntax("Uri")] string? requestUri,
        TRequest value)
    {
        var httpResponseMessage = await PostAsJsonAsync(requestUri, value);
        var response = await DeserializeAsync<TResponse>(await httpResponseMessage.Content.ReadAsStreamAsync(CancellationToken)) ??
                       throw new JsonException($"The parsed JSON value is null. The POST request URI: {requestUri}; the JSON body: {value}");
        return response;
    }

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.DeleteFromJsonAsync{T}(System.Net.Http.HttpClient, string?, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// и дополнительной проверкой JSON-результата на <c>null</c>
    /// </summary>
    protected async Task<TResponse> DeleteFromJsonAsync<TResponse>(
        [StringSyntax("Uri")] string? requestUri) =>
        await HttpClient.DeleteFromJsonAsync<TResponse>(requestUri, JsonSerializerOptions, CancellationToken) ??
        throw new JsonException($"The parsed JSON value is null. The DELETE request URI: {requestUri}");

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.PutAsJsonAsync{T}(System.Net.Http.HttpClient, string?, T, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// </summary>
    protected async Task<HttpResponseMessage> PutAsJsonAsync<TValue>(
        [StringSyntax("Uri")] string? requestUri,
        TValue value) =>
        await HttpClient.PutAsJsonAsync(requestUri, value, JsonSerializerOptions, CancellationToken);

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.PutAsJsonAsync{T}(System.Net.Http.HttpClient, string?, T, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// вместе с проверкой JSON-результата на <c>null</c> и десериализацией JSON-ответа
    /// </summary>
    protected async Task<TResponse> PutAndDeserializeAsJsonAsync<TRequest, TResponse>(
        [StringSyntax("Uri")] string? requestUri,
        TRequest value)
    {
        var httpResponseMessage = await PutAsJsonAsync(requestUri, value);
        var response = await DeserializeAsync<TResponse>(await httpResponseMessage.Content.ReadAsStreamAsync(CancellationToken)) ??
                       throw new JsonException($"The parsed JSON value is null. The PUT request URI: {requestUri}; the JSON body: {value}");
        return response;
    }

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.PatchAsJsonAsync{T}(System.Net.Http.HttpClient, string?, T, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// </summary>
    protected async Task<HttpResponseMessage> PatchAsJsonAsync<TValue>(
        [StringSyntax("Uri")] string? requestUri,
        TValue value) =>
        await HttpClient.PatchAsJsonAsync(requestUri, value, JsonSerializerOptions, CancellationToken);

    /// <summary>
    /// <see cref="HttpClientJsonExtensions.PatchAsJsonAsync{T}(System.Net.Http.HttpClient, string?, T, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// вместе с проверкой JSON-результата на <c>null</c> и десериализацией JSON-ответа
    /// </summary>
    protected async Task<TResponse> PatchAndDeserializeAsJsonAsync<TRequest, TResponse>(
        [StringSyntax("Uri")] string? requestUri,
        TRequest value)
    {
        var httpResponseMessage = await PatchAsJsonAsync(requestUri, value);
        var response = await DeserializeAsync<TResponse>(await httpResponseMessage.Content.ReadAsStreamAsync(CancellationToken)) ??
                       throw new JsonException($"The parsed JSON value is null. The PATCH request URI: {requestUri}; the JSON body: {value}");
        return response;
    }

    /// <summary>
    /// <see cref="JsonSerializer.DeserializeAsync{T}(Stream, System.Text.Json.JsonSerializerOptions?, System.Threading.CancellationToken)"/> с использованием внутреннего для этого класса <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// </summary>
    protected async ValueTask<TValue?> DeserializeAsync<TValue>(
        Stream utf8Json) =>
        await JsonSerializer.DeserializeAsync<TValue>(utf8Json, JsonSerializerOptions, CancellationToken);

    /// <summary>
    /// <see cref="JsonSerializer.Deserialize{T}(string, System.Text.Json.JsonSerializerOptions?)"/> с использованием внутреннего для этого класса <see cref="System.Text.Json.JsonSerializerOptions"/>
    /// </summary>
    protected TValue? Deserialize<TValue>(
        string json) =>
        JsonSerializer.Deserialize<TValue>(json, JsonSerializerOptions);
}
