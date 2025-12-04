using MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record InlineKeyboardAttachmentRequest : BaseAttachmentRequest
{
    public required InlineKeyboardPayloadRequest Payload { get; set; }

    public record InlineKeyboardPayloadRequest
    {
        /// <summary>
        /// Двумерный массив кнопок
        /// </summary>
        public BaseButton[][] Buttons { get; set; }
    }
}
