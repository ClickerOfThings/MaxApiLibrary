namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record AudioAttachmentRequest : BaseAttachmentRequest
{
    public required AudioPayloadRequest Payload { get; set; }

    public record AudioPayloadRequest
    {
        /// <summary>
        /// Токен — уникальный ID загруженного медиафайла
        /// </summary>
        public string? Token { get; set; }
    }
}
