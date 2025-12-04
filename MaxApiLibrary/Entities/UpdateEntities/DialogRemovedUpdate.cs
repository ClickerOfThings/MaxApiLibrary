using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record DialogRemovedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, который удалил чат
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Текущий язык пользователя в формате IETF BCP 47
    /// </summary>
    public string? UserLocale { get; init; }
}
