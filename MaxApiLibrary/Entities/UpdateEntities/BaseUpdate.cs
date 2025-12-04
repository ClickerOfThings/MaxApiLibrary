using System.Text.Json.Serialization;

namespace MaxApiLibrary.Entities.UpdateEntities;

/// <summary>
/// Объект Update представляет различные типы событий, произошедших в чате
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "update_type")]
[JsonDerivedType(typeof(MessageCreatedUpdate), "message_created")]
[JsonDerivedType(typeof(MessageCallbackUpdate), "message_callback")]
[JsonDerivedType(typeof(MessageEditedUpdate), "message_edited")]
[JsonDerivedType(typeof(MessageRemovedUpdate), "message_removed")]
[JsonDerivedType(typeof(BotAddedUpdate), "bot_added")]
[JsonDerivedType(typeof(BotRemovedUpdate), "bot_removed")]
[JsonDerivedType(typeof(DialogMutedUpdate), "dialog_muted")]
[JsonDerivedType(typeof(DialogUnmutedUpdate), "dialog_unmuted")]
[JsonDerivedType(typeof(DialogClearedUpdate), "dialog_cleared")]
[JsonDerivedType(typeof(DialogRemovedUpdate), "dialog_removed")]
[JsonDerivedType(typeof(UserAddedUpdate), "user_added")]
[JsonDerivedType(typeof(UserRemovedUpdate), "user_removed")]
[JsonDerivedType(typeof(BotStartedUpdate), "bot_started")]
[JsonDerivedType(typeof(BotStoppedUpdate), "bot_stopped")]
[JsonDerivedType(typeof(ChatTitleChangedUpdate), "chat_title_changed")]
[JsonDerivedType(typeof(MessageChatCreatedUpdate), "message_chat_created")]
public record BaseUpdate
{
    // ChatId не вынесен в базу, поскольку он отсутствует в классе MessageCallbackUpdate

    /// <summary>
    /// Unix-время, когда произошло событие
    /// </summary>
    public required long Timestamp { get; set; }
}
