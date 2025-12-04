namespace MaxApiLibrary.Implementations;

/// <summary>
/// Клиент MAX-бота для работы с API
/// </summary>
public class MaxBotApi
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="accessToken">Токен бота, генерируемый в <a href="https://business.max.ru/self/#/bot-settings">платформе</a></param>
    /// <param name="httpClient">HTTP-клиент, который будет взят за основу для дальнейших вызовов методов API</param>
    /// <param name="cancellationToken">Токен отмены для асинхронных HTTP запросов</param>
    public MaxBotApi(string accessToken, HttpClient? httpClient = null, CancellationToken? cancellationToken = null)
    {
        Bots = new BotsMethods(accessToken, httpClient, cancellationToken);
        Messages = new MessagesMethods(accessToken, httpClient, cancellationToken);
        Subscriptions = new SubscriptionMethods(accessToken, httpClient, cancellationToken);
        Upload = new UploadMethods(accessToken, httpClient, cancellationToken);
        Chats = new ChatsMethods(accessToken, httpClient, cancellationToken);
    }

    /// <summary>
    /// Методы для работы с API-методами из группы <c>bots</c>
    /// </summary>
    public BotsMethods Bots { get; set; }

    /// <summary>
    /// Методы для работы с API-методами из группы <c>messages</c>
    /// </summary>
    public MessagesMethods Messages { get; set; }

    /// <summary>
    /// Методы для работы с API-методами из группы <c>subscriptions</c>
    /// </summary>
    public SubscriptionMethods Subscriptions { get; set; }

    /// <summary>
    /// Методы для работы с API-методами из группы <c>upload</c>
    /// </summary>
    public UploadMethods Upload { get; set; }

    /// <summary>
    /// Методы для работы с API-методами из группы <c>chats</c>
    /// </summary>
    public ChatsMethods Chats { get; set; }
}
