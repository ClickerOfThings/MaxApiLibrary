using MaxApiLibrary.Entities.UpdateEntities;

namespace MaxApiLibrary.Methods.Subscriptions.Responses;

/// <summary>
/// Результат вызова метода <see cref="ISubscriptionMethods.GetUpdatesAsync"/>
/// </summary>
public record GetUpdatesResponse
{
    /// <summary>
    /// Страница обновлений
    /// </summary>
    public required BaseUpdate[] Updates { get; set; }

    /// <summary>
    /// Указатель на следующую страницу данных
    /// </summary>
    public long? Marker { get; set; }
}
