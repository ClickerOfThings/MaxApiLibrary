namespace MaxApiLibrary.Implementations.InternalClasses;

/// <summary>
/// Ответ от сервера по запросу ссылки на загрузку файла
/// </summary>
internal record UploadLinkRequestResponse
{
    /// <summary>
    /// Ссылка, по которой необходимо загрузить файл
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Токен файла. Может вернуться, если загружается видео или аудио. Все остальные типы файлов возвращают токен после загрузки файла
    /// </summary>
    public string? Token { get; set; }
}
