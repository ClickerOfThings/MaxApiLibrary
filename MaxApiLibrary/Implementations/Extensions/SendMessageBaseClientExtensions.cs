using MaxApiLibrary.Entities.MessageEntities.Attachments.Request;
using MaxApiLibrary.Implementations.InternalClasses;
using MaxApiLibrary.Methods.Messages.Requests;
using MaxApiLibrary.Methods.Messages.Responses;
using MaxApiLibrary.Methods.Upload;
using Polly;
using Polly.Retry;

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

namespace MaxApiLibrary.Implementations.Extensions;

/// <summary>
/// Методы-расширения для API-класса <see cref="MaxBotApi.Messages"/>
/// </summary>
public static class SendMessageBaseClientExtensions
{
    /// <summary>
    /// Отправка сообщения вместе с файлами. Для документации к методу отправления сообщения см. <see cref="MessagesMethods.SendMessageAsync"/> (он вызывается в этом методе).<br/>
    /// Для использования этого метода необязательно добавлять в поле <see cref="SendMessageRequest.Attachments"/> файлы (метод добавит файлы к уже существующим вложениям).
    /// </summary>
    /// <param name="files">Пара пути к файлу + его тип, который необходимо отправить</param>
    /// <exception cref="AttachmentNotReadyException">Возникает, если сервер продолжительное время выдаёт ошибку <c>attachment.not.ready</c>, даже когда файлы заливаются снова несколько раз</exception>
    /// <remarks>
    /// Сервер, на который отправляются файлы, иногда (но не редко) может беспричинно выдавать ошибку <c>attachment.not.ready</c> и <c>errors.process.attachment.file.not.processed</c>.
    /// В некоторых случаях это исправляется ожиданием в несколько секунд. Однако обычно даже это не помогает, и сервер начинает выдавать эту ошибку бесконечно.<br/>
    /// Этот метод в таких ситуациях заново пытается загрузить файлы.
    /// </remarks>
    public static async Task<SendMessageResponse> SendMessageAsync(this MaxBotApi client, SendMessageRequest body, FileWithType[] files, long? userId = null, long? chatId = null,
        bool? disableLinkPreview = null)
    {
        var originalBodyAttachments = new List<BaseAttachmentRequest>(body.Attachments ?? []);

        // Лучше не пытаться заливать файлы "до победного" (через while true), если постоянно выходит ошибка AttachmentNotReadyException,
        // во избежание бесконечного цикла при ошибках на стороне сервера
        var retryOptions = new RetryStrategyOptions<SendMessageResponse>()
        {
            Delay = TimeSpan.FromMilliseconds(500),
            MaxRetryAttempts = 10,
            ShouldHandle = new PredicateBuilder<SendMessageResponse>().Handle<AttachmentNotReadyException>()
        };

        var pipeline = new ResiliencePipelineBuilder<SendMessageResponse>()
            .AddRetry(retryOptions)
            .Build();

        return await pipeline.ExecuteAsync(async _ =>
        {
            var tokensList = new List<(string token, UploadTypes type)>();

            foreach (var file in files)
            {
                var uploadedFile = await client.Upload.UploadFileAsync(file.FilePath, file.FileType);
                tokensList.Add((uploadedFile.Token, file.FileType));
            }

            var attachments = new List<BaseAttachmentRequest>(originalBodyAttachments);
            foreach (var tokenPair in tokensList)
            {
                switch (tokenPair.type)
                {
                    case UploadTypes.Image:
                        attachments.Add(new ImageAttachmentRequest()
                        {
                            Payload = new ImageAttachmentRequest.ImagePayloadRequest()
                            {
                                Token = tokenPair.token
                            }
                        });
                        break;
                    case UploadTypes.Video:
                        attachments.Add(new VideoAttachmentRequest()
                        {
                            Payload = new VideoAttachmentRequest.VideoPayloadRequest()
                            {
                                Token = tokenPair.token
                            }
                        });
                        break;
                    case UploadTypes.Audio:
                        attachments.Add(new AudioAttachmentRequest()
                        {
                            Payload = new AudioAttachmentRequest.AudioPayloadRequest()
                            {
                                Token = tokenPair.token
                            }
                        });
                        break;
                    case UploadTypes.File:
                        attachments.Add(new FileAttachmentRequest()
                        {
                            Payload = new FileAttachmentRequest.FilePayloadRequest()
                            {
                                Token = tokenPair.token
                            }
                        });
                        break;
                }
            }

            body.Attachments = attachments.ToArray();

            var sentMessage = await client.Messages.SendMessageAsync(body, userId, chatId, disableLinkPreview);
            return sentMessage;
        });
    }

    /// <summary>
    /// Путь к файлу вместе с его типом
    /// </summary>
    /// <param name="FilePath">Путь к файлу</param>
    /// <param name="FileType">Тип файла</param>
    public record FileWithType(string FilePath, UploadTypes FileType);
}
