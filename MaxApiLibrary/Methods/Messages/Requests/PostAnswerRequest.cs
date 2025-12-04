namespace MaxApiLibrary.Methods.Messages.Requests;

/// <summary>
/// Запрос для вызова метода <see cref="IMessagesMethods.PostAnswerAsync"/>
/// </summary>
public record PostAnswerRequest
{
    /// <summary>
    /// Заполните это, если хотите изменить текущее сообщение
    /// </summary>
    public SendMessageRequest? Message { get; init; }

    /// <summary>
    /// Заполните это, если хотите просто отправить одноразовое уведомление пользователю
    /// </summary>
    public string? Notification { get; init; }
}
