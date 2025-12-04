namespace MaxApiLibrary.Entities;

/// <summary>
/// Команды, поддерживаемые ботом
/// </summary>
public record BotCommand
{
    /// <summary>
    /// Название команды. От 1 до 64 символов
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Описание команды. От 1 до 128 символов
    /// </summary>
    public string? Description { get; set; }
}
