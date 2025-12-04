namespace MaxApiLibrary.Methods.Chats.Request;

/// <summary>
/// Запрос для вызова метода <see cref="IChatsMethods.PinChatMessageAsync"/>
/// </summary>
public record PinChatMessageRequest
{
    /// <summary>
    /// ID сообщения, которое нужно закрепить. Соответствует полю <c>Message.body.mid</c>
    /// </summary>
    public required string MessageId { get; init; }

    /// <summary>
    /// Если <c>true</c>, участники получат уведомление с системным сообщением о закреплении. По умолчанию: <c>true</c>
    /// </summary>
    public bool? Notify { get; init; }
}
