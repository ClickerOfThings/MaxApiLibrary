using System.Text.Json.Serialization;
using MaxApiLibrary.Entities.MessageEntities;
using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Entities.ChatEntities;

/// <summary>
/// Объект чата
/// </summary>
public record Chat
{
    /// <summary>
    /// Статус чата
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChatStatus
    {
        /// <summary>
        /// Бот является активным участником чата
        /// </summary>
        Active,

        /// <summary>
        /// Бот был удалён из чата
        /// </summary>
        Removed,

        /// <summary>
        /// Бот покинул чат
        /// </summary>
        Left,

        /// <summary>
        /// Чат был закрыт
        /// </summary>
        Closed
    }

    /// <summary>
    /// Тип чата
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChatType
    {
        /// <summary>
        /// Групповой чат
        /// </summary>
        Chat,

        /// <summary>
        /// Диалог (не упоминается в API)
        /// </summary>
        Dialog
    }

    /// <summary>
    /// ID чата
    /// </summary>
    public required long ChatId { get; set; }

    /// <summary>
    /// Тип чата
    /// </summary>
    public required ChatType Type { get; set; }

    /// <summary>
    /// Статус чата
    /// </summary>
    public required ChatStatus Status { get; set; }

    /// <summary>
    /// Отображаемое название чата. Может быть <c>null</c> для диалогов
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Иконка чата
    /// </summary>
    public Image? Icon { get; set; }

    /// <summary>
    /// Время последнего события в чате
    /// </summary>
    public required long LastEventTime { get; set; }

    /// <summary>
    /// Количество участников чата. Для диалогов всегда <c>2</c>
    /// </summary>
    public required int ParticipantsCount { get; set; }

    /// <summary>
    /// ID владельца чата
    /// </summary>
    public long? OwnerId { get; set; }

    /// <summary>
    /// Участники чата с временем последней активности. Может быть <c>null</c>, если запрашивается список чатов
    /// </summary>
    public object? Participants { get; set; } // TODO выяснить, что за тип на самом деле присылается, ибо в доках это не уточняется

    /// <summary>
    /// Доступен ли чат публично (для диалогов всегда <c>false</c>)
    /// </summary>
    public required bool IsPublic { get; set; }

    /// <summary>
    /// Ссылка на чат
    /// </summary>
    public string? Link { get; set; }

    /// <summary>
    /// Описание чата
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Данные о пользователе в диалоге (только для чатов типа <c>"dialog"</c>)
    /// </summary>
    public UserWithPhoto? DialogWithUser { get; set; }

    /// <summary>
    /// ID сообщения, содержащего кнопку, через которую был инициирован чат
    /// </summary>
    public string? ChatMessageId { get; set; }

    /// <summary>
    /// Закреплённое сообщение в чате (возвращается только при запросе конкретного чата)
    /// </summary>
    public Message? PinnedMessage { get; set; }
}
