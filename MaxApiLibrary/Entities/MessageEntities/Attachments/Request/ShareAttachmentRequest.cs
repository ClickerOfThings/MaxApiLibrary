namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record ShareAttachmentRequest : BaseAttachmentRequest
{
    /// <summary>
    /// Полезная нагрузка запроса ShareAttachmentRequest
    /// </summary>
    public required SharePayloadRequest Payload { get; set; }

    /// <summary>
    /// Полезная нагрузка запроса ShareAttachmentRequest
    /// </summary>
    public record SharePayloadRequest
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
