namespace MaxApiLibrary.Methods.Subscriptions.Requests;

/// <summary>
/// Запрос для вызова метода <see cref="ISubscriptionMethods.PostSubscriptionsAsync"/>
/// </summary>
public record PostSubscriptionsRequest
{
    /// <summary>
    /// URL HTTP(S)-эндпойнта вашего бота. Должен начинаться с http(s)://
    /// </summary>
    public required string Url { get; init; }

    /// <summary>
    /// Список типов обновлений, которые ваш бот хочет получать.
    /// </summary>
    public List<Type>? UpdateTypes { get; init; }

    /// <summary>
    /// Секрет, который должен быть отправлен в заголовке X-Max-Bot-Api-Secret в каждом запросе Webhook.
    /// Разрешены только символы A-Z, a-z, 0-9, и дефис. Заголовок рекомендован, чтобы запрос поступал из установленного веб-узла
    /// </summary>
    public string? Secret { get; init; }
}

/// <summary>
/// Класс для конструирования POST-запроса к методу <see cref="ISubscriptionMethods.GetSubscriptionsAsync"/>. Необходим, поскольку
/// в классе <see cref="PostSubscriptionsRequest"/> поле <see cref="PostSubscriptionsRequest.UpdateTypes"/> должен иметь тип string.
/// TODO перенести в отдельный конвертер
/// </summary>
internal record PostSubscriptionsRequestInternal
{
    /// <inheritdoc cref="PostSubscriptionsRequest.Url"/>
    public required string Url { get; init; }

    /// <inheritdoc cref="PostSubscriptionsRequest.UpdateTypes"/>
    public List<string>? UpdateTypes { get; set; }

    /// <inheritdoc cref="PostSubscriptionsRequest.Secret"/>
    public string? Secret { get; init; }
}
