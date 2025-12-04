using System.Text.Json.Serialization;

namespace MaxApiLibrary.Entities.MessageEntities;

/// <summary>
/// Разметка текста сообщения
/// </summary>
public record MarkupElement
{
    /// <summary>
    /// Тип разметки сообщения
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MarkupTypes
    {
        /// <summary>
        /// Жирный
        /// </summary>
        Strong,

        /// <summary>
        /// Курсив
        /// </summary>
        Emphasized,

        /// <summary>
        /// Моноширинный
        /// </summary>
        Monospaced,

        /// <summary>
        /// Ссылка
        /// </summary>
        Link,

        /// <summary>
        /// Зачёркнутый
        /// </summary>
        Strikethrough,

        /// <summary>
        /// Подчёркнутый
        /// </summary>
        Underline,

        /// <summary>
        /// Упоминание пользователя
        /// </summary>
        UserMention
    }

    /// <summary>
    /// Тип элемента разметки
    /// </summary>
    public required MarkupTypes Type { get; set; }

    /// <summary>
    /// Индекс начала элемента разметки в тексте. Нумерация с нуля
    /// </summary>
    public int From { get; set; }

    /// <summary>
    /// Длина элемента разметки
    /// </summary>
    public int Length { get; set; }
}
