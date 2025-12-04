namespace MaxApiLibrary.Entities.UserEntities;

/// <summary>
/// Объект, описывающий пользователя
/// </summary>
public record User
{
    /// <summary>
    /// ID пользователя
    /// </summary>
    public required long UserId { get; set; }

    /// <summary>
    /// Отображаемое имя пользователя
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Отображаемая фамилия пользователя
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// <c>true</c>, если пользователь является ботом
    /// </summary>
    public required bool IsBot { get; set; }

    /// <summary>
    /// Время последней активности пользователя в MAX (Unix-время в миллисекундах)
    /// Может быть неактуальным, если пользователь отключил статус "онлайн" в настройках
    /// </summary>
    public required long LastActivityTime { get; set; }
}
