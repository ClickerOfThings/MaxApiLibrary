using MaxApiLibrary.Entities.MessageEntities;
using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record MessageCallbackUpdate : BaseUpdate
{
    public required Callback Callback { get; init; }

    /// <summary>
    /// Изначальное сообщение, содержащее встроенную клавиатуру. Может быть null, если оно было удалено к моменту, когда бот получил это обновление
    /// </summary>
    public Message? Message { get; init; }

    /// <summary>
    /// Текущий язык пользователя в формате IETF BCP 47
    /// </summary>
    public string? UserLocale { get; init; }
}

public record Callback
{
    /// <summary>
    /// Unix-время, когда пользователь нажал кнопку
    /// </summary>
    public required long Timestamp { get; set; }

    /// <summary>
    /// Текущий ID клавиатуры
    /// </summary>
    public required string CallbackId { get; set; }

    /// <summary>
    /// Токен кнопки
    /// </summary>
    public string? Payload { get; set; }

    /// <summary>
    /// Пользователь, нажавший на кнопку
    /// </summary>
    public required User User { get; set; }
}
