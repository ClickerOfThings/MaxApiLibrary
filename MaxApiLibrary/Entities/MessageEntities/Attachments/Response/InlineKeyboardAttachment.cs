using System.Text.Json.Serialization;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

public record InlineKeyboardAttachment : BaseAttachment
{
    /// <summary>
    /// Клавиатура - это двумерный массив кнопок
    /// </summary>
    public required InlineKeyboardPayload Payload { get; set; }

    public record InlineKeyboardPayload
    {
        public BaseButton[][] Buttons { get; set; }
    }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(CallbackButton), "callback")]
[JsonDerivedType(typeof(LinkButton), "link")]
[JsonDerivedType(typeof(RequestGeoLocationButton), "request_geo_location")]
[JsonDerivedType(typeof(RequestContactButton), "request_contact")]
[JsonDerivedType(typeof(OpenAppButton), "open_app")]
[JsonDerivedType(typeof(MessageButton), "message")]
public abstract record BaseButton
{
    /// <summary>
    /// Видимый текст кнопки. От 1 до 128 символов
    /// </summary>
    public required string Text { get; set; }
}

public record CallbackButton : BaseButton
{
    /// <summary>
    /// Намерение кнопки
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Intents
    {
        Positive,
        Negative,
        Default
    }

    /// <summary>
    /// Токен кнопки. До 1024 символов
    /// </summary>
    public required string Payload { get; set; }

    /// <summary>
    /// Намерение кнопки. Влияет на отображение клиентом
    /// </summary>
    public Intents? Intent { get; set; }
}

public record LinkButton : BaseButton
{
    /// <summary>
    /// Ссылка. До 2048 символов
    /// </summary>
    public required string Url { get; set; }
}

public record RequestGeoLocationButton : BaseButton
{
    /// <summary>
    /// Если true, отправляет местоположение без запроса подтверждения пользователя
    /// </summary>
    public bool? Quick { get; set; }
}

public record RequestContactButton : BaseButton;

public record OpenAppButton : BaseButton
{
    /// <summary>
    /// Публичное имя (username) бота или ссылка на него, чьё мини-приложение надо запустить
    /// </summary>
    public string? WebApp { get; set; }

    /// <summary>
    /// Идентификатор бота, чьё мини-приложение надо запустить
    /// </summary>
    public long? ContactId { get; set; }

    /// <summary>
    /// Параметр запуска, который будет передан в <a href="https://dev.max.ru/docs/webapps/bridge#WebAppData">initData</a> мини-приложения
    /// </summary>
    public string? Payload { get; set; }
}

public record MessageButton : BaseButton;
