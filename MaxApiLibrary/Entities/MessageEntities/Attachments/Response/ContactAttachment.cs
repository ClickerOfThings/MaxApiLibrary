using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record ContactAttachment : BaseAttachment
{
    public required ContactPayload Payload { get; set; }

    public record ContactPayload
    {
        /// <summary>
        /// Информация о пользователе в формате VCF
        /// </summary>
        public string? VcfInfo { get; set; }

        /// <summary>
        /// Информация о пользователе
        /// </summary>
        public User? MaxInfo { get; set; }
    }
}
