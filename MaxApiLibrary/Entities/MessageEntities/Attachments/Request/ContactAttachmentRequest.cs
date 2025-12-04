namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record ContactAttachmentRequest : BaseAttachmentRequest
{
    public required ContactPayloadRequest Payload { get; set; }

    public record ContactPayloadRequest
    {
        /// <summary>
        /// Имя контакта
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ID контакта, если он зарегистрирован в MAX
        /// </summary>
        public long? ContactId { get; set; }

        /// <summary>
        /// Полная информация о контакте в формате VCF
        /// </summary>
        public string? VcfInfo { get; set; }

        /// <summary>
        /// Телефон контакта в формате VCF
        /// </summary>
        public string? VcfPhone { get; set; }
    }
}
