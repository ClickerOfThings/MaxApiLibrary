using System.Text.Json.Serialization;

namespace MaxApiLibrary.Methods.Chats.Request;

/// <summary>
/// Запрос для вызова метода <see cref="IChatsMethods.PostChatActionAsync"/>
/// </summary>
public record PostChatActionRequest
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChatActions
    {
        TypingOn,
        SendingPhoto,
        SendingVideo,
        SendingAudio,
        SendingFile,
        MarkSeen
    }

    /// <summary>
    /// Действие, отправляемое участникам чата.
    /// </summary>
    public required ChatActions Action { get; init; }
}
