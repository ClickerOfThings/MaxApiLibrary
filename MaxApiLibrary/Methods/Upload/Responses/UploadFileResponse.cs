namespace MaxApiLibrary.Methods.Upload.Responses;

/// <summary>
/// Результат вызова метода <see cref="IUploadMethods.UploadFileAsync"/>
/// </summary>
public record UploadFileResponse
{
    /// <summary>
    /// Токен файла для использования во вложениях сообщений
    /// </summary>
    public required string Token { get; set; }
}
