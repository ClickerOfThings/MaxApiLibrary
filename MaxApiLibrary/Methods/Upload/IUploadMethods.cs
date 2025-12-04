using MaxApiLibrary.Methods.Upload.Responses;

namespace MaxApiLibrary.Methods.Upload;

/// <summary>
/// API-методы из группы <c>upload</c>
/// </summary>
public interface IUploadMethods
{
    /// <summary>
    /// <para>
    ///     Загрузка файлов.
    /// </para>
    /// <para>
    ///     Возвращает URL для последующей загрузки файла.
    /// </para>
    /// <remarks>
    /// Полные детали необходимой имлементации см. <a href="https://dev.max.ru/docs-api/methods/POST/uploads">здесь</a>.<br/>
    /// Имплементация должна внутри метода выполнять сразу все этапы загрузки файлов, в ответ отдавая только токен файла.
    /// Запросы и ответы из сервера выглядят примерно следующим образом:<br/>
    /// Отправка файла:
    /// <code>
    /// $ curl -X POST "https://platform-api.max.ru/uploads?type=file" -H "Authorization: ТОКЕН_БОТА"
    /// {"url":"https://fu.oneme.ru/api/upload.do?sig=ХХХ&amp;expires=NNN&amp;..."}
    /// </code>
    /// <code>
    /// $ curl -X POST "https://fu.oneme.ru/api/upload.do?sig=ХХХ&amp;expires=NNN&amp;..." -H "Authorization: ТОКЕН_БОТА" -F "data=@file.txt"
    /// {"fileId":YYY,"token":"JJJ"}
    /// </code>
    ///
    /// Отправка видео:
    /// <code>
    /// $ curl -X POST "https://platform-api.max.ru/uploads?type=video" -H "Authorization: ТОКЕН_БОТА"
    /// {"url":"https://vu.okcdn.ru/upload.do?sig=XXX&amp;...","token":"JJJ"}
    /// </code>
    /// <code>
    /// $ curl -X POST "https://vu.okcdn.ru/upload.do?sig=XXX&amp;..." -H "Authorization: ТОКЕН_БОТА" -F "data=@file.mp4"
    /// &lt;retval&gt;1&lt;/retval&gt;
    /// </code>
    /// </remarks>
    /// <param name="filePath">Путь к загружаемому файлу</param>
    /// <param name="type">Тип загружаемого файла</param>
    /// </summary>
    Task<UploadFileResponse> UploadFileAsync(string filePath, UploadTypes type);
}
