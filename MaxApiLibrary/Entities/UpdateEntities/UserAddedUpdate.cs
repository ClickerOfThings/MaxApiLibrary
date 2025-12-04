using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record UserAddedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, добавленный в чат
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Пользователь, который добавил пользователя в чат. Может быть null, если пользователь присоединился к чату по ссылке
    /// </summary>
    public long? InviterId { get; init; }

    /// <summary>
    /// Указывает, был ли пользователь добавлен в канал или нет
    /// </summary>
    public required bool IsChannel { get; init; }
}
