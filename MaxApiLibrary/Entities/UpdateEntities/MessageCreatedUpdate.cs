using MaxApiLibrary.Entities.MessageEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record MessageCreatedUpdate : BaseUpdate
{
    /// <summary>
    /// Новое созданное сообщение
    /// </summary>
    public required Message Message { get; init; }

    /// <summary>
    /// Текущий язык пользователя в формате IETF BCP 47. Доступно только в диалогах
    /// </summary>
    public string? UserLocale { get; init; }
}
