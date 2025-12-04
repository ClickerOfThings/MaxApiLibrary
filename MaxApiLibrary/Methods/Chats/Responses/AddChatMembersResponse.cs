namespace MaxApiLibrary.Methods.Chats.Responses;

/// <summary>
/// Результат вызова метода <see cref="IChatsMethods.AddChatMembersAsync"/>
/// </summary>
public record AddChatMembersResponse
{
    /// <summary>
    /// <c>true</c>, если запрос был успешным, <c>false</c> в противном случае
    /// </summary>
    public required bool Success { get; init; }

    /// <summary>
    /// Объяснительное сообщение, если результат не был успешным
    /// </summary>
    public string? Message { get; init; }
}
