using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record BotStartedUpdate : BaseUpdate
{
    /// <summary>
    /// ID диалога, где произошло событие
    /// </summary>
    public required long ChatId { get; init; }

    /// <summary>
    /// Пользователь, который нажал кнопку 'Start'
    /// </summary>
    public required User User { get; init; }

    /// <summary>
    /// Дополнительные данные из дип-линков, переданные при запуске бота. До 512 символов.
    /// </summary>
    public string? Payload { get; init; }

    /// <summary>
    /// Текущий язык пользователя в формате IETF BCP 47
    /// </summary>
    public string? UserLocale { get; init; }
}
