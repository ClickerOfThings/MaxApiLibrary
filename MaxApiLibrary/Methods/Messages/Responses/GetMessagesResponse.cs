using MaxApiLibrary.Entities.MessageEntities;

namespace MaxApiLibrary.Methods.Messages.Responses;

/// <summary>
/// Результат вызова метода <see cref="IMessagesMethods.GetMessagesAsync"/>
/// </summary>
public record GetMessagesResponse
{
    /// <summary>
    /// Массив сообщений
    /// </summary>
    public required Message[] Messages { get; set; }
}
