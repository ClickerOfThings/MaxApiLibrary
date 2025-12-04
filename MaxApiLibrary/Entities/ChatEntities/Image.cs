namespace MaxApiLibrary.Entities.ChatEntities;

/// <summary>
/// Объект изображения
/// </summary>
/// <remarks>
/// В документации не выведен в отдельный объект, и присутствует только в классе <see cref="Chat"/>
/// </remarks>
public record Image
{
    /// <summary>
    /// URL изображения
    /// </summary>
    public required string Url { get; set; }
}
