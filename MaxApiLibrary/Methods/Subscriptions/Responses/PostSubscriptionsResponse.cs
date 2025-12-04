namespace MaxApiLibrary.Methods.Subscriptions.Responses;

/// <summary>
/// Результат вызова метода <see cref="ISubscriptionMethods.PostSubscriptionsAsync"/>
/// </summary>
public record PostSubscriptionsResponse
{
    /// <summary>
    /// <c>true</c>, если запрос был успешным, <c>false</c> в противном случае
    /// </summary>
    public required bool Success { get; init; }

    /// <summary>
    /// Объяснительное сообщение, если результат не был успешным
    /// </summary>
    public string? Message { get; init; }
}
