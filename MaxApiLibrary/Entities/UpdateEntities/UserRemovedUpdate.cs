using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record UserRemovedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, удалённый из чата
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Администратор, который удалил пользователя из чата. Может быть null, если пользователь покинул чат сам
    /// </summary>
    public long? AdminId { get; init; }

    /// <summary>
    /// Указывает, был ли пользователь удалён из канала или нет
    /// </summary>
    public required bool IsChannel { get; init; }
}
