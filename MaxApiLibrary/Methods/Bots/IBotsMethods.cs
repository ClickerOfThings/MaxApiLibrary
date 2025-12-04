using MaxApiLibrary.Entities.UserEntities;

namespace MaxApiLibrary.Methods.Bots;

/// <summary>
/// API-методы из группы <c>bots</c>
/// </summary>
public interface IBotsMethods
{
    /// <summary>
    /// <para>
    ///     Получение информации о текущем боте.
    /// </para>
    /// <para>
    ///     Возвращает информацию о текущем боте, который идентифицируется с помощью токена доступа
    /// </para>
    /// </summary>
    public Task<BotInfo> MeAsync();
}
