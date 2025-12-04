using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record DialogClearedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, который включил уведомления
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Текущий язык пользователя в формате IETF BCP 47
    /// </summary>
    public string? UserLocale { get; init; }
}
