using MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

namespace MaxApiLibrary.Methods.Chats.Request;

/// <summary>
/// Запрос для вызова метода <see cref="IChatsMethods.PatchChatAsync"/>
/// </summary>
public record PatchChatRequest
{
    /// <summary>
    /// Запрос на прикрепление изображения (все поля являются взаимоисключающими)
    /// </summary>
    public ImageAttachmentRequest.ImagePayloadRequest? Icon { get; init; }

    /// <summary>
    /// От 1 до 200 символов
    /// </summary>
    /// <remarks>
    /// В API отсутствует описание поля
    /// </remarks>
    public string? Title { get; init; }

    /// <summary>
    /// ID сообщения для закрепления в чате. Чтобы удалить закреплённое сообщение, используйте метод <c>unpin</c> (<c>https://dev.max.ru/docs-api/methods/DELETE/chats/{chatId}/pin</c>)
    /// </summary>
    public string? Pin { get; init; }

    /// <summary>
    /// По умолчанию: <c>true</c>. Если <c>true</c>, участники получат системное уведомление об изменении
    /// </summary>
    public bool? Notify { get; init; }
}
