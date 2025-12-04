namespace MaxApiLibrary.Methods.Chats.Request;

/// <summary>
/// Запрос для вызова метода <see cref="IChatsMethods.AddChatMembersAsync"/>
/// </summary>
public record AddChatMembersRequest
{
    /// <summary>
    /// Массив ID пользователей для добавления в чат
    /// </summary>
    public required List<long> UserIds { get; init; }
}
