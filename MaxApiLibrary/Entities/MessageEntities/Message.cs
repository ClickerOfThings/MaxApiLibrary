using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.MessageEntities;

/// <summary>
/// Сообщение в чате
/// </summary>
public record Message
{
    /// <summary>
    /// Пользователь, отправивший сообщение
    /// </summary>
    public User? Sender { get; set; }

    /// <summary>
    /// Получатель сообщения. Может быть пользователем или чатом
    /// </summary>
    public required Recipient Recipient { get; set; }

    /// <summary>
    /// Время создания сообщения в формате Unix-time
    /// </summary>
    public required long Timestamp { get; set; }

    /// <summary>
    /// Пересланное или ответное сообщение
    /// </summary>
    public LinkedMessage? Link { get; set; }

    /// <summary>
    /// Содержимое сообщения. Текст + вложения. Может быть <c>null</c>, если сообщение содержит только пересланное сообщение
    /// </summary>
    public required MessageBody Body { get; set; }

    /// <summary>
    /// Статистика сообщения
    /// </summary>
    public MessageStat? Stat { get; set; }

    /// <summary>
    /// Публичная ссылка на сообщение. Может быть <c>null</c> для диалогов или не публичных чатов
    /// </summary>
    public string? Url { get; set; }
}
