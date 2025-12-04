using MaxApiLibrary.Entities.MessageEntities;

namespace MaxApiLibrary.Methods.Messages.Classes;

/// <summary>
/// Ссылка на сообщение
/// </summary>
public record NewMessageLink
{
    /// <summary>
    /// Тип ссылки сообщения
    /// </summary>
    public required LinkedMessage.MessageLinkType Type { get; set; }

    /// <summary>
    /// ID сообщения исходного сообщения
    /// </summary>
    public required string Mid { get; set; }
}
