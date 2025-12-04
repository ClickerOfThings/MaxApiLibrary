namespace MaxApiLibrary.Entities.UserEntities;

/// <summary>
/// Объект, описывающий информацию о боте
/// </summary>
public record BotInfo : UserWithPhoto
{
    /// <summary>
    /// Команды, поддерживаемые ботом. До 32 элементов
    /// </summary>
    public BotCommand[]? Commands { get; set; }
}
