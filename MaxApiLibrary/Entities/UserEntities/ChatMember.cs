using System.Text.Json.Serialization;

namespace MaxApiLibrary.Entities.UserEntities;

/// <summary>
/// Объект, описывающий участника чата
/// </summary>
public record ChatMember : UserWithPhoto
{
    /// <summary>
    /// Перечень прав пользователя
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChatAdminPermissions
    {
        /// <summary>
        /// Читать все сообщения
        /// </summary>
        ReadAllMessages = 1 << 0,

        /// <summary>
        /// Добавлять/удалять участников
        /// </summary>
        AddRemoveMembers = 1 << 1,

        /// <summary>
        /// Добавлять администраторов
        /// </summary>
        AddAdmins = 1 << 2,

        /// <summary>
        /// Изменять информацию о чате
        /// </summary>
        ChangeChatInfo = 1 << 3,

        /// <summary>
        /// Закреплять сообщения
        /// </summary>
        PinMessage = 1 << 4,

        /// <summary>
        /// Писать сообщения
        /// </summary>
        Write = 1 << 5,

        /// <summary>
        /// Изменять ссылку на чат
        /// </summary>
        EditLink = 1 << 6
    }

    /// <summary>
    /// Время последней активности пользователя в чате. Может быть устаревшим для суперчатов (равно времени вступления)
    /// </summary>
    public long LastAccessTime { get; init; }

    /// <summary>
    /// Является ли пользователь владельцем чата
    /// </summary>
    public bool IsOwner { get; init; }

    /// <summary>
    /// Является ли пользователь администратором чата
    /// </summary>
    public bool IsAdmin { get; init; }

    /// <summary>
    /// Дата присоединения к чату в формате Unix time
    /// </summary>
    public long JoinTime { get; init; }

    /// <summary>
    /// Перечень прав пользователя. Может быть null
    /// </summary>
    public ChatAdminPermissions? Permissions { get; init; }

    /// <summary>
    /// Заголовок, который будет показан на клиенте
    /// Если пользователь администратор или владелец и ему не установлено это название, то поле не передается,
    /// клиенты на своей стороне подменят на "владелец" или "админ"
    /// </summary>
    public string? Alias { get; init; }
}
