using MaxApiLibrary.Entities.ChatEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record MessageChatCreatedUpdate : BaseUpdate
{
    /// <summary>
    /// Созданный чат
    /// </summary>
    public required Chat Chat { get; init; }

    /// <summary>
    /// ID сообщения, где была нажата кнопка
    /// </summary>
    public required string MessageId { get; init; }

    /// <summary>
    /// Полезная нагрузка от кнопки чата
    /// </summary>
    public string? StartPayload { get; init; }
}
