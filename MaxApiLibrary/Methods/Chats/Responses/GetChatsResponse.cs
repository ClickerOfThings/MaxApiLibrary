using MaxApiLibrary.Entities.ChatEntities;

namespace MaxApiLibrary.Methods.Chats.Responses;

/// <summary>
/// Результат вызова метода <see cref="IChatsMethods.GetChatsAsync"/>
/// </summary>
public record GetChatsResponse
{
    /// <summary>
    /// Список запрашиваемых чатов
    /// </summary>
    public required Chat[] Chats { get; set; }

    /// <summary>
    /// Указатель на следующую страницу запрашиваемых чатов
    /// </summary>
    public long? Marker { get; set; }
}
