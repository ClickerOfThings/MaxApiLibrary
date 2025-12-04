namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record ImageAttachment : BaseAttachment
{
    public required ImagePayload Payload { get; set; }

    public record ImagePayload
    {
        /// <summary>
        /// Уникальный ID этого изображения
        /// </summary>
        public required long PhotoId { get; set; }

        // TODO отсутствует документация на сайте
        public required string Token { get; set; }

        /// <summary>
        /// URL изображения
        /// </summary>
        public required string Url { get; set; }
    }
}
