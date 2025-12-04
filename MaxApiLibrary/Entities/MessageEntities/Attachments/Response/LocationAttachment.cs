namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record LocationAttachment : BaseAttachment
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
