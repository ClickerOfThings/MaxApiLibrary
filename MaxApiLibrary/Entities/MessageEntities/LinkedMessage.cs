using System.Text.Json.Serialization;
using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.MessageEntities;

/// <summary>
/// Пересланное или ответное сообщение
/// </summary>
public record LinkedMessage
{
    /// <summary>
    /// Тип связанного сообщения
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageLinkType
    {
        /// <summary>
        /// Пересланное сообщение
        /// </summary>
        Forward,

        /// <summary>
        /// Ответ на сообщение
        /// </summary>
        Reply
    }

    /// <summary>
    /// Тип связанного сообщения
    /// </summary>
    public required MessageLinkType Type { get; set; }

    /// <summary>
    /// Пользователь, отправивший сообщение
    /// </summary>
    public User? Sender { get; set; }

    /// <summary>
    /// Чат, в котором сообщение было изначально опубликовано. Только для пересланных сообщений
    /// </summary>
    public long? ChatId { get; set; }

    /// <summary>
    /// Схема, представляющая тело сообщения
    /// </summary>
    public required MessageBody Message { get; set; }
}
