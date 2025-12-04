using System.Text.Json.Serialization;
using MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

namespace MaxApiLibrary.Methods.Messages.Responses;

/// <summary>
/// Результат вызова метода <see cref="IMessagesMethods.GetVideoAsync"/>
/// </summary>
public record GetVideoResponse
{
    /// <summary>
    /// Токен видео-вложения
    /// </summary>
    public required string Token { get; init; }

    /// <summary>
    /// URL-ы для скачивания или воспроизведения видео. Может быть null, если видео недоступно
    /// </summary>
    public VideoUrls? Urls { get; init; }

    /// <summary>
    /// Миниатюра видео
    /// </summary>
    public ImageAttachment.ImagePayload? Thumbnail { get; init; }

    /// <summary>
    /// Ширина видео
    /// </summary>
    public required int Width { get; init; }

    /// <summary>
    /// Высота видео
    /// </summary>
    public required int Height { get; init; }

    /// <summary>
    /// Длина видео в секундах
    /// </summary>
    public required int Duration { get; init; }

    /// <summary>
    /// URL-ы для скачивания или воспроизведения видео
    /// </summary>
    public record VideoUrls
    {
        /// <summary>
        /// URL видео в разрешении 1080p, если доступно
        /// </summary>
        [JsonPropertyName("mp4_1080")] // Автоматическая конвертация наименования JSON-полей не поймёт, что после "Mp4" должно быть "_"
        public string? Mp41080 { get; init; }

        /// <summary>
        /// URL видео в разрешении 720p, если доступно
        /// </summary>
        [JsonPropertyName("mp4_720")]
        public string? Mp4720 { get; init; }

        /// <summary>
        /// URL видео в разрешении 480p, если доступно
        /// </summary>
        [JsonPropertyName("mp4_480")]
        public string? Mp4480 { get; init; }

        /// <summary>
        /// URL видео в разрешении 360p, если доступно
        /// </summary>
        [JsonPropertyName("mp4_360")]
        public string? Mp4360 { get; init; }

        /// <summary>
        /// URL видео в разрешении 240p, если доступно
        /// </summary>
        [JsonPropertyName("mp4_240")]
        public string? Mp4240 { get; init; }

        /// <summary>
        /// URL видео в разрешении 144p, если доступно
        /// </summary>
        [JsonPropertyName("mp4_144")]
        public string? Mp4144 { get; init; }

        /// <summary>
        /// URL трансляции (HLS), если доступна
        /// </summary>
        [JsonPropertyName("hls")]
        public string? Hls { get; init; }
    }
}
