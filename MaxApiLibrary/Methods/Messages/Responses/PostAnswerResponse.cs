namespace MaxApiLibrary.Methods.Messages.Responses;

/// <summary>
/// Результат вызова метода <see cref="IMessagesMethods.PostAnswerAsync"/>
/// </summary>
public record PostAnswerResponse
{
    /// <summary>
    /// <c>true</c>, если запрос был успешным, <c>false</c> в противном случае
    /// </summary>
    public required bool Success { get; init; }

    /// <summary>
    /// Объяснительное сообщение, если результат не был успешным
    /// </summary>
    public string? Message { get; init; }
}
