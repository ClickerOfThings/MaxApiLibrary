namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record FileAttachmentRequest : BaseAttachmentRequest
{
    public required FilePayloadRequest Payload { get; set; }

    public record FilePayloadRequest
    {
        /// <summary>
        /// Токен — уникальный ID загруженного медиафайла
        /// </summary>
        public string? Token { get; set; }
    }
}
