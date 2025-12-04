namespace MaxApiLibrary.Entities.UserEntities;

/// <summary>
/// Объект пользователя с фотографией
/// </summary>
public record UserWithPhoto : User
{
    /// <summary>
    /// Описание пользователя. Может быть null, если пользователь его не заполнил. До 160000 символов
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// URL аватара
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// URL аватара большего размера
    /// </summary>
    public string? FullAvatarUrl { get; set; }
}
