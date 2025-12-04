using MaxApiLibrary.Entities.UpdateEntities;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record AudioAttachment : BaseAttachment
{
    public required AudioPayload Payload { get; set; }

    /// <summary>
    /// Аудио транскрипция
    /// </summary>
    public string? Transcription { get; set; }

    public record AudioPayload
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
