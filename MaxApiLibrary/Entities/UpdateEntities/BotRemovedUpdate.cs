using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record BotRemovedUpdate : BaseUpdate
{
    /// <summary>
    /// ID чата, откуда был удалён бот
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, удаливший бота из чата
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Указывает, был ли бот удалён из канала или нет
    /// </summary>
    public required bool IsChannel { get; init; }
}
