namespace MaxApiLibrary.Entities.UpdateEntities;

public record MessageRemovedUpdate : BaseUpdate
{
    /// <summary>
    /// ID удаленного сообщения
    /// </summary>
    public required string MessageId { get; init; }

    /// <summary>
    /// ID чата, где сообщение было удалено
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, удаливший сообщение
    /// </summary>
    public required long UserId { get; init; }
}
