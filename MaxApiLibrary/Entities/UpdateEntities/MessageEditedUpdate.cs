using MaxApiLibrary.Entities.MessageEntities;

namespace MaxApiLibrary.Entities.UpdateEntities;

public record MessageEditedUpdate : BaseUpdate
{
    /// <summary>
    /// Отредактированное сообщение
    /// </summary>
    public required Message Message { get; init; }
}
