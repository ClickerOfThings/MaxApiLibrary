using System.Text.Json;
using MaxApiLibrary.Entities.MessageEntities;
using MaxApiLibrary.Implementations.Extensions;
using MaxApiLibrary.Implementations.InternalClasses;
using MaxApiLibrary.Methods.Messages;
using MaxApiLibrary.Methods.Messages.Requests;
using MaxApiLibrary.Methods.Messages.Responses;
using Microsoft.AspNetCore.Http.Extensions;
using Polly;
using Polly.Retry;

namespace MaxApiLibrary.Implementations;

/// <summary>
/// Имплементация API-методов из группы <c>messages</c>
/// </summary>
public class MessagesMethods : BaseApiClient, IMessagesMethods
{
    /// <inheritdoc />
    public MessagesMethods(string accessToken, HttpClient? httpClient = null, CancellationToken? cancellationToken = null) : base(accessToken, httpClient, cancellationToken)
    {
    }

    /// <inheritdoc />
    public async Task<GetMessagesResponse> GetMessagesAsync(long? chatId = null, long[]? messageIds = null, long? from = null, long? to = null, int? count = null)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("chat_id", chatId)
            .AddQueryParameter("message_ids",
                messageIds is not null ? string.Join(",", messageIds) : null)
            .AddQueryParameter("from", from)
            .AddQueryParameter("to", to)
            .AddQueryParameter("count", count);

        var response = await GetFromJsonAsync<GetMessagesResponse>($"messages{queryBuilder.ToQueryString()}");
        return response;
    }

    /// <inheritdoc />
    public async Task<SendMessageResponse> SendMessageAsync(SendMessageRequest body, long? userId = null, long? chatId = null, bool? disableLinkPreview = null)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("user_id", userId)
            .AddQueryParameter("chat_id", chatId)
            .AddQueryParameter("disable_link_preview", disableLinkPreview);

        var request = $"messages{queryBuilder.ToQueryString()}";

        // Иногда, сервер может выдавать такую ошибку:
        //   "code" : "attachment.not.ready",
        //   "message" : "Key: errors.process.attachment.file.not.processed"
        // В документации к API это не описано, поэтому необходимо вручную делать таймаут с длительностью по принципу "пальцем в небо" при помощи
        // Polly-стратегии Retry
        var retryOptions = new RetryStrategyOptions<SendMessageResponse>()
        {
            Delay = TimeSpan.FromSeconds(1),
            BackoffType = DelayBackoffType.Linear,
            MaxDelay = TimeSpan.FromSeconds(2),
            MaxRetryAttempts = 5,
            ShouldHandle = new PredicateBuilder<SendMessageResponse>().Handle<AttachmentNotReadyException>()
        };

        var resiliencePipeline = new ResiliencePipelineBuilder<SendMessageResponse>()
            .AddRetry(retryOptions)
            .Build();
        var response = await resiliencePipeline.ExecuteAsync(async token =>
        {
            var httpResponseMessage = await PostAsJsonAsync(request, body);

            var responseString = await httpResponseMessage.Content.ReadAsStringAsync(token);
            if (!responseString.Contains("attachment.not.ready"))
                return Deserialize<SendMessageResponse>(responseString) ??
                       throw new JsonException($"Couldn't parse \"message sending\" response, the value is null. The POST request URI: {request}, body: {body}");
            throw new AttachmentNotReadyException();
        }, CancellationToken);

        return response;
    }

    /// <inheritdoc />
    public async Task<EditMessageResponse> EditMessageAsync(string messageId, EditMessageRequest body)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("message_id", messageId);

        var response = await PutAndDeserializeAsJsonAsync<EditMessageRequest, EditMessageResponse>($"messages{queryBuilder.ToQueryString()}", body);
        return response;
    }

    /// <inheritdoc />
    public async Task<DeleteMessageResponse> DeleteMessageAsync(string messageId)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("message_id", messageId);

        var response = await DeleteFromJsonAsync<DeleteMessageResponse>($"messages{queryBuilder.ToQueryString()}");
        return response;
    }

    /// <inheritdoc />
    public async Task<Message> GetMessageAsync(string messageId) =>
        await DeleteFromJsonAsync<Message>($"messages/{messageId}");

    /// <inheritdoc />
    public async Task<GetVideoResponse> GetVideoAsync(string videoToken) =>
        await GetFromJsonAsync<GetVideoResponse>($"videos/{videoToken}");

    /// <inheritdoc />
    public async Task<PostAnswerResponse> PostAnswerAsync(string callbackId, PostAnswerRequest body)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("callback_id", callbackId);

        var response = await PostAndDeserializeAsJsonAsync<PostAnswerRequest, PostAnswerResponse>($"answers{queryBuilder.ToQueryString()}", body);
        return response;
    }
}
