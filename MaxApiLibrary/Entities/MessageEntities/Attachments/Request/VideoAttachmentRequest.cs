namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record VideoAttachmentRequest : BaseAttachmentRequest
{
    public VideoPayloadRequest Payload { get; set; }

    public record VideoPayloadRequest
    {
        /// <summary>
        /// Токен — уникальный ID загруженного медиафайла
        /// </summary>
        public string? Token { get; set; }
    }
}
