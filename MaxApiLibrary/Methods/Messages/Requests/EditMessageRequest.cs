using MaxApiLibrary.Entities.MessageEntities.Attachments.Response;
using MaxApiLibrary.Methods.Messages.Classes;

namespace MaxApiLibrary.Methods.Messages.Requests;

/// <summary>
/// Запрос для вызова метода <see cref="IMessagesMethods.EditMessageAsync"/>
/// </summary>
public record EditMessageRequest
{
    /// <summary>
    /// Новый текст сообщения. До 4000 символов
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Вложения сообщения. Если пусто, все вложения будут удалены
    /// </summary>
    public BaseAttachment[]? Attachments { get; set; }

    /// <summary>
    /// Ссылка на сообщение
    /// </summary>
    public NewMessageLink? Link { get; set; }

    /// <summary>
    /// Если <c>false</c>, участники чата не будут уведомлены (по умолчанию <c>true</c>)
    /// </summary>
    public bool? Notify { get; set; } = true;

    /// <summary>
    /// Если установлен, текст сообщения будет форматирован данным способом
    /// </summary>
    public TextFormat? Format { get; set; }
}
