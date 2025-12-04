using MaxApiLibrary.Methods.Subscriptions.Requests;
using MaxApiLibrary.Methods.Subscriptions.Responses;

namespace MaxApiLibrary.Methods.Subscriptions;

/// <summary>
/// API-методы из группы <c>subscriptions</c>
/// </summary>
public interface ISubscriptionMethods
{
    /// <summary>
    /// <para>
    ///     Получение подписок.
    /// </para>
    /// <para>
    ///     Если ваш бот получает данные через WebHook, этот метод возвращает список всех подписок.
    /// </para>
    /// <para>
    ///     Обратите внимание: для отправки вебхуков поддерживается только протокол HTTPS, включая самоподписанные сертификаты. HTTP не поддерживается.
    /// </para>
    /// </summary>
    Task<GetSubscriptionsResponse> GetSubscriptionsAsync();

    /// <summary>
    /// <para>
    ///     Подписка на обновления.
    /// </para>
    /// <para>
    ///     Подписывает бота на получение обновлений через WebHook. После вызова этого метода
    ///     бот будет получать уведомления о новых событиях в чатах на указанный URL. Ваш сервер должен прослушивать
    ///     один из следующих портов: 80, 8080, 443, 8443, 16384-32383
    /// </para>
    /// </summary>
    Task<PostSubscriptionsResponse> PostSubscriptionsAsync(PostSubscriptionsRequest request);

    /// <summary>
    /// <para>
    ///     Отписка от обновлений.
    /// </para>
    /// <para>
    ///     Отписывает бота от получения обновлений через WebHook. После вызова этого метода
    ///     бот перестаёт получать уведомления о новых событиях, и становится доступна доставка уведомлений через API с длительным опросом
    /// </para>
    /// </summary>
    /// <param name="url">URL, который нужно удалить из подписок на WebHook</param>
    Task<DeleteSubscriptionsResponse> DeleteSubscriptionsAsync(string url);

    /// <summary>
    /// <para>
    ///     Получение обновлений.
    /// </para>
    /// <para>
    ///     Этот метод можно использовать для получения обновлений, если ваш бот не подписан на WebHook. Метод использует долгий опрос (long polling).
    /// </para>
    /// <para>
    ///     Каждое обновление имеет свой номер последовательности. Свойство <c>marker</c> в ответе указывает на следующее ожидаемое обновление.
    /// </para>
    /// <para>
    ///     Все предыдущие обновления считаются завершенными после прохождения параметра <c>marker</c>. Если параметр marker <b>не передан</b>, бот получит все обновления, произошедшие после последнего подтверждения.
    /// </para>
    /// </summary>
    /// <param name="limit">Максимальное количество обновлений для получения. По умолчанию: 100 (по API)</param>
    /// <param name="timeout">Тайм-аут в секундах для долгого опроса. По умолчанию: 30 (по API)</param>
    /// <param name="marker">Если передан, бот получит обновления, которые еще не были получены. Если не передан, получит все новые обновления</param>
    /// <param name="types">Список типов обновлений, которые бот хочет получить.</param>
    /// <example>
    ///     Например, если бот хочет получить обновление типа <c>message_callback</c>, то нужно метод вызывать так:
    ///     <code>
    ///         GetUpdatesAsync(types: [typeof(MessageCallbackUpdate)])
    ///     </code>
    /// </example>
    public Task<GetUpdatesResponse> GetUpdatesAsync(int? limit = null, int? timeout = null, long? marker = null, Type[]? types = null);
}
