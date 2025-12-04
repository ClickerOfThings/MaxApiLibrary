using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record BotAddedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, куда был добавлен бот
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, добавивший бота в чат
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Указывает, был ли бот добавлен в канал или нет
    /// </summary>
    public required bool IsChannel { get; init; }
}
