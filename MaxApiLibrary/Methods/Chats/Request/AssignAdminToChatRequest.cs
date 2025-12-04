using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Methods.Chats.Request;

/// <summary>
/// Запрос для вызова метода <see cref="IChatsMethods.AssignAdminToChatAsync"/>
/// </summary>
public record AssignAdminToChatRequest
{
    /// <summary>
    /// Массив администраторов чата
    /// </summary>
    public required List<ChatAdmin> Admins { get; init; }

    /// <summary>
    /// Указатель на следующую страницу данных
    /// </summary>
    public long? Marker { get; init; }

    /// <summary>
    /// Администратор чата
    /// </summary>
    public record ChatAdmin
    {
        /// <summary>
        /// Идентификатор администратора с правами доступа
        /// </summary>
        public required long UserId { get; init; }

        /// <summary>
        /// Перечень прав пользователя.
        /// </summary>
        public required ChatMember.ChatAdminPermissions Permissions { get; init; }

        /// <summary>
        /// Заголовок, который будет показан на клиенте.
        /// Если пользователь администратор или владелец и ему не установлено это название, то поле не передаётся, клиенты на своей стороне подменят на "владелец" или "админ"
        /// </summary>
        public string? Alias { get; init; }
    }
}
