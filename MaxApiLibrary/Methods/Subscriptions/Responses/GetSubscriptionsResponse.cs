namespace MaxApiLibrary.Methods.Subscriptions.Responses;

/// <summary>
/// Результат вызова метода <see cref="ISubscriptionMethods.GetSubscriptionsAsync"/>
/// </summary>
public record GetSubscriptionsResponse
{
    /// <summary>
    /// Список текущих подписок
    /// </summary>
    public required List<Subscription> Subscriptions { get; init; }
}

/// <summary>
/// Описание подписки вебхука
/// </summary>
public record Subscription
{
    /// <summary>
    /// URL вебхука
    /// </summary>
    public required string Url { get; init; }

    /// <summary>
    /// Unix-время, когда была создана подписка
    /// </summary>
    public required long Time { get; init; }

    /// <summary>
    /// Типы обновлений, на которые подписан бот. Пример: ["message_created", "bot_started"]
    /// </summary>
    public List<string>? UpdateTypes { get; init; } // TODO конвертировать в типы (Type) внутри проекта
}
