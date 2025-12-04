using System.Text.Json.Serialization;

namespace MaxApiLibrary.Entities.MessageEntities.Attachments.Request;

/// <summary>
/// Базовый класс для вложений
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ImageAttachmentRequest), "image")]
[JsonDerivedType(typeof(VideoAttachmentRequest), "video")]
[JsonDerivedType(typeof(AudioAttachmentRequest), "audio")]
[JsonDerivedType(typeof(FileAttachmentRequest), "file")]
[JsonDerivedType(typeof(StickerAttachmentRequest), "sticker")]
[JsonDerivedType(typeof(ContactAttachmentRequest), "contact")]
[JsonDerivedType(typeof(InlineKeyboardAttachmentRequest), "inline_keyboard")]
[JsonDerivedType(typeof(ShareAttachmentRequest), "share")]
[JsonDerivedType(typeof(LocationAttachmentRequest), "location")]
public abstract record BaseAttachmentRequest;
