using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Methods.Chats.Responses;

/// <summary>
/// Результат вызова метода <see cref="IChatsMethods.GetChatAdminsAsync"/>
/// </summary>
public record GetChatAdminsResponse
{
    /// <summary>
    /// Список участников чата с информацией о времени последней активности
    /// </summary>
    public required ChatMember[] Members { get; init; }

    /// <summary>
    /// Указатель на следующую страницу данных
    /// </summary>
    public long? Marker { get; init; }
}
