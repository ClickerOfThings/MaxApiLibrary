using MaxApiLibrary.Entities.UserEntities;
using MaxApiLibrary.Methods.Bots;

namespace MaxApiLibrary.Implementations;

/// <summary>
/// Имлпементация API-методов из группы <c>bots</c>
/// </summary>
public class BotsMethods : BaseApiClient, IBotsMethods
{
    /// <inheritdoc />
    public BotsMethods(string accessToken, HttpClient? httpClient = null, CancellationToken? cancellationToken = null) : base(accessToken, httpClient, cancellationToken)
    {
    }

    /// <inheritdoc />
    public async Task<BotInfo> MeAsync() =>
        await GetFromJsonAsync<BotInfo>("me");
}
