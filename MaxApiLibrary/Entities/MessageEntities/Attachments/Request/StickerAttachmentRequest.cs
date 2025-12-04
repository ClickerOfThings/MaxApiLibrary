namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record StickerAttachmentRequest : BaseAttachmentRequest
{
    public required StickerPayloadRequest Payload { get; set; }

    public record StickerPayloadRequest
    {
        /// <summary>
        /// Код стикера
        /// </summary>
        public required string Code { get; set; }
    }
}
