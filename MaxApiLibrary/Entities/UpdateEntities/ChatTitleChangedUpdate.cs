using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record ChatTitleChangedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, который изменил название
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Новое название
    /// </summary>
    public required string Title { get; init; }
}
