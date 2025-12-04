using MaxApiLibrary.Entities.UpdateEntities;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record StickerAttachment : BaseAttachment
{
    public required StickerPayload Payload { get; set; }

    /// <summary>
    /// Ширина стикера
    /// </summary>
    public required int Width { get; set; }

    /// <summary>
    /// Высота стикера
    /// </summary>
    public required int Height { get; set; }

    public record StickerPayload
    {
        /// <summary>
        /// URL медиа-вложения. Этот URL будет получен в объекте <see cref="BaseUpdate"/> после отправки сообщения в чат.
        /// Прямую ссылку на видео также можно получить с помощью метода <c>GET /videos/{-videoToken-}</c>
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Используйте <c>token</c>, если вы пытаетесь повторно использовать одно и то же вложение в другом сообщении
        /// </summary>
        public string? Token { get; set; }
    }
}
