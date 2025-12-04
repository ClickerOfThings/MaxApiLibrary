using MaxApiLibrary.Entities.UpdateEntities;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record FileAttachment : BaseAttachment
{
    public required FilePayload Payload { get; set; }

    /// <summary>
    /// Имя загруженного файла
    /// </summary>
    public required string Filename { get; set; }

    /// <summary>
    /// Размер файла в байтах
    /// </summary>
    public required int Size { get; set; }

    public record FilePayload
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
