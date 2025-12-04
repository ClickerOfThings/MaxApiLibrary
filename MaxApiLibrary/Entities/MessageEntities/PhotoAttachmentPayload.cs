namespace MaxApiLibrary.Entities.MessageEntities;

/// <summary>
/// Payload-изображение
/// </summary>
public record PhotoAttachmentPayload
{
    /// <summary>
    /// Уникальный ID этого изображения
    /// </summary>
    public required long PhotoId { get; set; }

    /// <summary>
    /// Токен
    /// </summary>
    public required string Token { get; set; }

    /// <summary>
    /// URL изображения
    /// </summary>
    public required string Url { get; set; }
}
