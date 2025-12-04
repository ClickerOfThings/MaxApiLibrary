using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Methods.Chats.Responses;

/// <summary>
/// Результат вызова метода <see cref="IChatsMethods.GetChatMembersAsync"/>
/// </summary>
public record GetChatMembersResponse
{
    /// <summary>
    /// Список участников чата
    /// </summary>
    public required List<ChatMember> Members { get; init; }

    /// <summary>
    /// Указатель на следующую страницу
    /// </summary>
    public long? Marker { get; init; }
}
