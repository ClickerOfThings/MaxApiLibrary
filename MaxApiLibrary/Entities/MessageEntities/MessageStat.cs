namespace MaxApiLibrary.Entities.MessageEntities;

/// <summary>
/// Статистика сообщения
/// </summary>
public record MessageStat
{
    /// <summary>
    /// Количество просмотров
    /// </summary>
    public required int Views { get; set; }
}
