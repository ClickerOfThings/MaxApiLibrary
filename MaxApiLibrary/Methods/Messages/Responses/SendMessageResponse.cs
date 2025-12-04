using MaxApiLibrary.Entities.MessageEntities;

namespace MaxApiLibrary.Methods.Messages.Responses;

/// <summary>
/// Результат вызова метода <see cref="IMessagesMethods.SendMessageAsync"/>
/// </summary>
public record SendMessageResponse
{
    /// <summary>
    /// Сообщение в чате
    /// </summary>
    public required Message Message { get; set; }
}
