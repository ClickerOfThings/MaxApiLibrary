using MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

namespace MaxApiLibrary.Entities.MessageEntities;

/// <summary>
/// Содержимое сообщения
/// </summary>
public record MessageBody
{
    /// <summary>
    /// Уникальный ID сообщения
    /// </summary>
    public required string Mid { get; set; }

    /// <summary>
    /// ID последовательности сообщения в чате
    /// </summary>
    public required long Seq { get; set; }

    /// <summary>
    /// Новый текст сообщения
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Вложения сообщения
    /// </summary>
    public BaseAttachment[]? Attachments { get; set; }

    /// <summary>
    /// Разметка текста сообщения
    /// </summary>
    public MarkupElement[]? Markup { get; set; }
}
