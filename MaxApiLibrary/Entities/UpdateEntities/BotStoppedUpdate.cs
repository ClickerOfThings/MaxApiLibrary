using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record BotStoppedUpdate : BaseUpdate
{
    /// <summary>
    /// ID диалога, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, который остановил чат
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Текущий язык пользователя в формате IETF BCP 47
    /// </summary>
    public string? UserLocale { get; init; }
}
