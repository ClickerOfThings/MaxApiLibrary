namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record ShareAttachment : BaseAttachment
{
    /// <summary>
    /// Полезная нагрузка запроса ShareAttachmentRequest
    /// </summary>
    public required SharePayload Payload { get; set; }

    /// <summary>
    /// Заголовок предпросмотра ссылки
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Описание предпросмотра ссылки
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Изображение предпросмотра ссылки
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Полезная нагрузка запроса ShareAttachmentRequest
    /// </summary>
    public record SharePayload
    {
        /// <summary>
        /// URL, прикрепленный к сообщению в качестве предпросмотра медиа. От 1 символа
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Токен вложения
        /// </summary>
        public string? Token { get; set; }
    }
}
