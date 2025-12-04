using MaxApiLibrary.Entities.UpdateEntities;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record VideoAttachment : BaseAttachment
{
    public VideoPayload Payload { get; set; }

    /// <summary>
    /// Миниатюра видео
    /// </summary>
    public VideoThumbnail? Thumbnail { get; set; }

    /// <summary>
    /// Ширина видео
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// Высота видео
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// Длина видео в секундах
    /// </summary>
    public int? Duration { get; set; }

    public record VideoPayload
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

    /// <summary>
    /// Миниатюра видео
    /// </summary>
    public record VideoThumbnail
    {
        /// <summary>
        /// URL изображения
        /// </summary>
        public required string Url { get; set; }
    }
}
