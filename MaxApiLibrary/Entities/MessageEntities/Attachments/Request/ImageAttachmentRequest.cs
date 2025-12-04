namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record ImageAttachmentRequest : BaseAttachmentRequest
{
    /// <summary>
    /// Запрос на прикрепление изображения (все поля являются взаимоисключающими)
    /// </summary>
    public required ImagePayloadRequest Payload { get; set; }

    public record ImagePayloadRequest
    {
        /// <summary>
        /// Любой внешний URL изображения, которое вы хотите прикрепить. От 1 символа
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Токен существующего вложения
        /// </summary>
        public string? Token { get; set; }

        // Объект "photos" отсутствует, поскольку в документации метода POST messages не приводится описание класса
    }
}
