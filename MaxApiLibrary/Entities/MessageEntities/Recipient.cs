using MaxApiLibrary.Entities.ChatEntities;

namespace MaxApiLibrary.Entities.MessageEntities;

/// <summary>
/// Получатель сообщения
/// </summary>
public record Recipient
{
    /// <summary>
    /// ID чата
    /// </summary>
    public long? ChatId { get; set; }

    /// <summary>
    /// Тип чата
    /// </summary>
    public required Chat.ChatType ChatType { get; set; }

    /// <summary>
    /// ID пользователя, если сообщение было отправлено пользователю
    /// </summary>
    public long? UserId { get; set; }
}
