using System.Text.Json.Serialization;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Response;

/// <summary>
/// Базовый класс для вложений
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ImageAttachment), "image")]
[JsonDerivedType(typeof(VideoAttachment), "video")]
[JsonDerivedType(typeof(AudioAttachment), "audio")]
[JsonDerivedType(typeof(FileAttachment), "file")]
[JsonDerivedType(typeof(StickerAttachment), "sticker")]
[JsonDerivedType(typeof(ContactAttachment), "contact")]
[JsonDerivedType(typeof(InlineKeyboardAttachment), "inline_keyboard")]
[JsonDerivedType(typeof(ShareAttachment), "share")]
[JsonDerivedType(typeof(LocationAttachment), "location")]
public abstract record BaseAttachment;
