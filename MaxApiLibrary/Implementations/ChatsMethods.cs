using MaxApiLibrary.Entities.ChatEntities;
using MaxApiLibrary.Entities.MessageEntities;
using MaxApiLibrary.Entities.UserEntities;
using MaxApiLibrary.Implementations.Extensions;
using MaxApiLibrary.Methods.Chats;
using MaxApiLibrary.Methods.Chats.Request;
using MaxApiLibrary.Methods.Chats.Responses;
using Microsoft.AspNetCore.Http.Extensions;

namespace MaxApiLibrary.Implementations;

/// <summary>
/// Имлпементация API-методов из группы <c>bots</c>
/// </summary>
public class ChatsMethods : BaseApiClient, IChatsMethods
{
    /// <inheritdoc />
    public ChatsMethods(string accessToken, HttpClient? httpClient = null, CancellationToken? cancellationToken = null) : base(accessToken, httpClient, cancellationToken)
    {
    }

    /// <inheritdoc />
    public async Task<GetChatsResponse> GetChatsAsync(int? count = null, long? marker = null)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("count", count)
            .AddQueryParameter("marker", marker);

        var response = await GetFromJsonAsync<GetChatsResponse>($"chats{queryBuilder.ToQueryString()}");
        return response;
    }

    /// <inheritdoc />
    public async Task<Chat> GetChatByLinkAsync(string chatLink) =>
        await GetFromJsonAsync<Chat>($"chats/{chatLink}");

    /// <inheritdoc />
    public async Task<Chat> GetChatByIdAsync(string chatId) =>
        await GetFromJsonAsync<Chat>($"chats/{chatId}");

    /// <inheritdoc />
    public async Task<Chat> PatchChatAsync(long chatId, PatchChatRequest body) =>
        await PatchAndDeserializeAsJsonAsync<PatchChatRequest, Chat>($"chats/{chatId}", body);

    /// <inheritdoc />
    public async Task<DeleteChatResponse> DeleteChatAsync(long chatId) =>
        await DeleteFromJsonAsync<DeleteChatResponse>($"chats/{chatId}");

    /// <inheritdoc />
    public async Task<PostChatActionResponse> PostChatActionAsync(long chatId, PostChatActionRequest body) =>
        await PostAndDeserializeAsJsonAsync<PostChatActionRequest, PostChatActionResponse>($"chats/{chatId}/actions", body);

    /// <inheritdoc />
    public async Task<Message?> GetChatPinAsync(long chatId) =>
        await GetFromJsonAsync<Message?>($"chats/{chatId}/pin");

    /// <inheritdoc />
    public async Task<PinChatMessageResponse> PinChatMessageAsync(long chatId, PinChatMessageRequest body) =>
        await PutAndDeserializeAsJsonAsync<PinChatMessageRequest, PinChatMessageResponse>($"chats/{chatId}/pin", body);

    /// <inheritdoc />
    public async Task<DeleteChatPinResponse> DeleteChatPinAsync(long chatId) =>
        await DeleteFromJsonAsync<DeleteChatPinResponse>($"chats/{chatId}/pin");

    /// <inheritdoc />
    public async Task<ChatMember> GetMeMemberInfoAsync(long chatId) =>
        await GetFromJsonAsync<ChatMember>($"chats/{chatId}/members/me");

    /// <inheritdoc />
    public async Task<DeleteMeFromGroupChatResponse> DeleteMeFromGroupChatAsync(long chatId) =>
        await DeleteFromJsonAsync<DeleteMeFromGroupChatResponse>($"chats/{chatId}/members/me");

    /// <inheritdoc />
    public async Task<GetChatAdminsResponse> GetChatAdminsAsync(long chatId) =>
        await GetFromJsonAsync<GetChatAdminsResponse>($"chats/{chatId}/members/admins");

    /// <inheritdoc />
    public async Task<AssignAdminToChatResponse> AssignAdminToChatAsync(long chatId, AssignAdminToChatRequest body) =>
        await PostAndDeserializeAsJsonAsync<AssignAdminToChatRequest, AssignAdminToChatResponse>($"chats/{chatId}/members/admins", body);

    /// <inheritdoc />
    public async Task<DeleteChatAdminResponse> DeleteChatAdminAsync(long chatId, long userId) =>
        await DeleteFromJsonAsync<DeleteChatAdminResponse>($"chats/{chatId}/members/admins/{userId}");

    /// <inheritdoc />
    public async Task<GetChatMembersResponse> GetChatMembersAsync(long chatId, List<long>? userIds, long? marker, int? count)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("user_ids", userIds is not null ? string.Join(",", userIds) : null)
            .AddQueryParameter("marker", marker)
            .AddQueryParameter("count", count);

        var response = await GetFromJsonAsync<GetChatMembersResponse>($"chats/{chatId}/members");
        return response;
    }

    /// <inheritdoc />
    public async Task<AddChatMembersResponse> AddChatMembersAsync(long chatId, AddChatMembersRequest body) =>
        await PostAndDeserializeAsJsonAsync<AddChatMembersRequest, AddChatMembersResponse>($"chats/{chatId}/members", body);

    /// <inheritdoc />
    public async Task<DeleteChatMemberResponse> DeleteChatMemberAsync(long chatId, long userId, bool? block)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter("user_id", userId)
            .AddQueryParameter("block", block);

        var response = await DeleteFromJsonAsync<DeleteChatMemberResponse>($"chats/{chatId}/members");
        return response;
    }
}
