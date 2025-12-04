namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

public record LocationAttachmentRequest : BaseAttachmentRequest
{
    /// <summary>
    /// Широта
    /// </summary>
    public required string Latitude { get; set; }

    /// <summary>
    /// Долгота
    /// </summary>
    public required string Longitude { get; set; }
}
