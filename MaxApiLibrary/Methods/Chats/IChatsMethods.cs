using MaxApiLibrary.Entities.ChatEntities;
using MaxApiLibrary.Entities.MessageEntities;
using MaxApiLibrary.Entities.UserEntities;
using MaxApiLibrary.Methods.Chats.Request;
using MaxApiLibrary.Methods.Chats.Responses;

namespace MaxApiLibrary.Methods.Chats;

/// <summary>
/// API-методы из группы <c>chats</c>
/// </summary>
public interface IChatsMethods
{
    /// <summary>
    /// <para>
    ///     Получение списка всех чатов.
    /// </para>
    /// <para>
    ///     Возвращает информацию о чатах, в которых участвовал бот. Результат включает список чатов и маркер для перехода к следующей странице.
    /// </para>
    /// </summary>
    /// <param name="count">Количество запрашиваемых чатов. По умолчанию: 50 (по API)</param>
    /// <param name="marker">Указатель на следующую страницу данных. Для первой страницы передайте <c>null</c></param>
    public Task<GetChatsResponse> GetChatsAsync(int? count = null, long? marker = null);

    /// <summary>
    /// <para>
    ///     Получение чата по ссылке.
    /// </para>
    /// <para>
    ///     Возвращает информацию о чате по его публичной ссылке, либо информацию о диалоге с пользователем по его <c>username</c>.
    /// </para>
    /// </summary>
    /// <param name="chatLink">Публичная ссылка на чат или username пользователя. Должна соответствовать регулярному выражению <c>@?[a-zA-Z]+[a-zA-Z0-9-_]*</c></param>
    public Task<Chat> GetChatByLinkAsync(string chatLink);

    /// <summary>
    /// <para>
    ///     Получение информации о групповом чате.
    /// </para>
    /// <para>
    ///     Возвращает информацию о групповом чате по его ID.
    /// </para>
    /// </summary>
    /// <param name="chatId">ID запрашиваемого чата</param>
    public Task<Chat> GetChatByIdAsync(string chatId);

    /// <summary>
    /// <para>
    ///     Изменение информации о групповом чате.
    /// </para>
    /// <para>
    ///     Позволяет редактировать информацию о групповом чате, включая название, иконку и закреплённое сообщение.
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    /// <param name="body">Тело PATCH-запроса</param>
    public Task<Chat> PatchChatAsync(long chatId, PatchChatRequest body);

    /// <summary>
    /// <para>
    ///     Удаление группового чата.
    /// </para>
    /// <para>
    ///     Удаляет групповой чат для всех участников.
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    public Task<DeleteChatResponse> DeleteChatAsync(long chatId);

    /// <summary>
    /// <para>
    ///     Отправка действия бота в групповой чат.
    /// </para>
    /// <para>
    ///     Позволяет отправлять в групповой чат такие действия бота, как например: «набор текста» или «отправка фото».
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    /// <param name="body">Тело POST-запроса</param>
    public Task<PostChatActionResponse> PostChatActionAsync(long chatId, PostChatActionRequest body);

    /// <summary>
    /// <para>
    ///     Получение закреплённого сообщения в групповом чате.
    /// </para>
    /// <para>
    ///     Возвращает закреплённое сообщение в групповом чате
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    public Task<Message?> GetChatPinAsync(long chatId);

    /// <summary>
    /// <para>
    ///     Закрепление сообщения в групповом чате.
    /// </para>
    /// <para>
    ///     Закрепляет сообщение в групповом чате
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата, где должно быть закреплено сообщение</param>
    /// <param name="body">Тело запроса</param>
    public Task<PinChatMessageResponse> PinChatMessageAsync(long chatId, PinChatMessageRequest body);

    /// <summary>
    /// <para>
    ///     Удаление закреплённого сообщения в групповом чате.
    /// </para>
    /// <para>
    ///     Удаляет закреплённое сообщение в групповом чате
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата, из которого нужно удалить закреплённое сообщение</param>
    public Task<DeleteChatPinResponse> DeleteChatPinAsync(long chatId);

    /// <summary>
    /// <para>
    ///     Получение информации о членстве бота в групповом чате.
    /// </para>
    /// <para>
    ///     Возвращает информацию о членстве текущего бота в групповом чате. Бот идентифицируется с помощью токена доступа
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    public Task<ChatMember> GetMeMemberInfoAsync(long chatId);

    /// <summary>
    /// <para>
    ///     Удаление бота из участников группового чата.
    /// </para>
    /// <para>
    ///     Удаляет бота из участников группового чата
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    public Task<DeleteMeFromGroupChatResponse> DeleteMeFromGroupChatAsync(long chatId);

    /// <summary>
    /// <para>
    ///     Получение списка администраторов группового чата.
    /// </para>
    /// <para>
    ///     Получение списка администраторов группового чата
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    public Task<GetChatAdminsResponse> GetChatAdminsAsync(long chatId);

    /// <summary>
    /// <para>
    ///     Назначить администратора группового чата.
    /// </para>
    /// <para>
    ///     Возвращает значение true, если в групповой чат добавлены все администраторы
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    /// <param name="body">Тело запроса</param>
    public Task<AssignAdminToChatResponse> AssignAdminToChatAsync(long chatId, AssignAdminToChatRequest body);

    /// <summary>
    /// <para>
    ///     Отменить права администратора в групповом чате.
    /// </para>
    /// <para>
    ///     Отменяет права администратора у пользователя в групповом чате, лишая его административных привилегий.
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    /// <param name="userId">Идентификатор пользователя</param>
    public Task<DeleteChatAdminResponse> DeleteChatAdminAsync(long chatId, long userId);

    /// <summary>
    /// <para>
    ///     Получение участников группового чата.
    /// </para>
    /// <para>
    ///     Возвращает список участников группового чата.
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    /// <param name="userIds">Список ID пользователей, чье членство нужно получить. Когда этот параметр передан, параметры <c>count</c> и <c>marker</c> игнорируются</param>
    /// <param name="marker">Указатель на следующую страницу данных</param>
    /// <param name="count">Количество участников, которых нужно вернуть. От 1 до 100. По умолчанию - 20</param>
    public Task<GetChatMembersResponse> GetChatMembersAsync(long chatId, List<long>? userIds, long? marker, int? count);

    /// <summary>
    /// <para>
    ///     Добавление участников в групповой чат.
    /// </para>
    /// <para>
    ///     Добавляет участников в групповой чат. Для этого могут потребоваться дополнительные права
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    /// <param name="body">Тело запроса</param>
    public Task<AddChatMembersResponse> AddChatMembersAsync(long chatId, AddChatMembersRequest body);

    /// <summary>
    /// <para>
    ///     Удаление участника из группового чата.
    /// </para>
    /// <para>
    ///     Удаляет участника из группового чата. Для этого могут потребоваться дополнительные права
    /// </para>
    /// </summary>
    /// <param name="chatId">ID чата</param>
    /// <param name="userId">ID пользователя, которого нужно удалить из чата</param>
    /// <param name="block">Если установлено в <c>true</c>, пользователь будет заблокирован в чате. Применяется только для чатов с публичной или приватной ссылкой. Игнорируется в остальных случаях</param>
    public Task<DeleteChatMemberResponse> DeleteChatMemberAsync(long chatId, long userId, bool? block);
}
