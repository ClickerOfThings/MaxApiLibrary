using MaxApiLibrary.Entities.MessageEntities;
using MaxApiLibrary.Entities.UpdateEntities;
using MaxApiLibrary.Methods.Messages.Requests;
using MaxApiLibrary.Methods.Messages.Responses;

namespace MaxApiLibrary.Methods.Messages;

/// <summary>
/// API-методы из группы <c>messages</c>
/// </summary>
public interface IMessagesMethods
{
    /// <summary>
    /// <para>Получение сообщений.</para>
    /// <para>
    ///     Возвращает сообщения в чате: страницу с результатами и маркер, указывающий на следующую страницу.
    ///     Сообщения возвращаются в обратном порядке, то есть последние сообщения в чате будут первыми в массиве.
    ///     Поэтому, если вы используете параметры <c>from</c> и <c>to</c>, то <c>to</c> должно быть меньше, чем <c>from</c>.
    ///
    ///     Для выполнения запроса нужно указать один из двух параметров: <c>chat_id</c> — если нужно получить сообщения из чата,
    ///     или <c>message_ids</c> — если нужны конкретные сообщения по их ID
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата, чтобы получить сообщения из определённого чата. Обязательный параметр, если не указан <c>message_ids</c></param>
    /// <param name="messageIds">Список ID сообщений, которые нужно получить (через запятую). Обязательный параметр, если не указан <c>chat_id</c></param>
    /// <param name="from">Время начала для запрашиваемых сообщений (в формате Unix timestamp)</param>
    /// <param name="to">Время окончания для запрашиваемых сообщений (в формате Unix timestamp)</param>
    /// <param name="count">Максимальное количество сообщений в ответе. От 1 до 100. По умолчанию 50.</param>
    public Task<GetMessagesResponse> GetMessagesAsync(long? chatId = null, long[]? messageIds = null, long? from = null, long? to = null, int? count = null);

    /// <summary>
    /// <para>
    ///     Отправить сообщение.
    /// </para>
    /// <para>
    ///     Отправляет сообщение в чат.
    /// </para>
    /// </summary>
    /// <param name="body">Тело POST-запроса</param>
    /// <param name="userId">Если вы хотите отправить сообщение пользователю, укажите его ID</param>
    /// <param name="chatId">Если сообщение отправляется в чат, укажите его ID</param>
    /// <param name="disableLinkPreview">Если <c>false</c>, сервер не будет генерировать превью для ссылок в тексте сообщения</param>
    public Task<SendMessageResponse> SendMessageAsync(SendMessageRequest body, long? userId = null, long? chatId = null, bool? disableLinkPreview = null);

    /// <summary>
    /// <para>
    ///     Редактировать сообщение.
    /// </para>
    /// <para>
    ///     Редактирует сообщение в чате.
    ///     Если поле <c>attachments</c> равно <c>null</c>, вложения текущего сообщения не изменяются.
    ///     Если в этом поле передан пустой список, все вложения будут удалены.
    /// </para>
    /// </summary>
    /// <param name="messageId">ID редактируемого сообщения (от 1 символа)</param>
    /// <param name="body">Тело запроса для редактирования сообщения</param>
    public Task<EditMessageResponse> EditMessageAsync(string messageId, EditMessageRequest body);

    /// <summary>
    /// <para>
    ///     Удалить сообщение.
    /// </para>
    /// <para>
    ///     Удаляет сообщение в диалоге или чате, если бот имеет разрешение на удаление сообщений.
    /// </para>
    /// </summary>
    /// <param name="messageId">ID удаляемого сообщения (от 1 символа)</param>
    Task<DeleteMessageResponse> DeleteMessageAsync(string messageId);

    /// <summary>
    /// <para>
    ///     Получить сообщение.
    /// </para>
    /// <para>
    ///     Возвращает сообщение по его ID
    /// </para>
    /// </summary>
    /// <param name="messageId">ID сообщения (mid), чтобы получить одно сообщение в чате</param>
    Task<Message> GetMessageAsync(string messageId);

    /// <summary>
    /// <para>
    ///     Получить информацию о видео.
    /// </para>
    /// <para>
    ///     Возвращает подробную информацию о прикреплённом видео. URL-адреса воспроизведения и дополнительные метаданные
    /// </para>
    /// </summary>
    /// <param name="videoToken">Токен видео-вложения</param>
    Task<GetVideoResponse> GetVideoAsync(string videoToken);

    /// <summary>
    /// <para>
    ///     Ответ на callback.
    /// </para>
    /// <para>
    ///     Этот метод используется для отправки ответа после того, как пользователь нажал на кнопку.
    ///     Ответом может быть обновленное сообщение и/или одноразовое уведомление для пользователя
    /// </para>
    /// </summary>
    /// <param name="callbackId">
    ///     Идентификатор кнопки, по которой пользователь кликнул. Бот получает идентификатор как часть
    ///     <c>Update</c> с типом <c>message_callback</c> (см. <see cref="MessageCallbackUpdate"/>.
    ///     Можно получить из <a href="https://dev.max.ru/docs-api/methods/GET/updates">GET:/updates</a> через поле <c>updates[i].callback.callback_id</c>
    ///     (<see cref="Callback.CallbackId"/>)</param>
    /// <param name="body">Тело запроса</param>
    Task<PostAnswerResponse> PostAnswerAsync(string callbackId, PostAnswerRequest body);
}
