using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record DialogMutedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, который отключил уведомления
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Время в формате Unix, до наступления которого диалог был отключён
    /// </summary>
    public required long MutedUntil { get; init; }

    /// <summary>
    /// Текущий язык пользователя в формате IETF BCP 47
    /// </summary>
    public string? UserLocale { get; init; }
}
