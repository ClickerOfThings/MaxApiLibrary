using System.Runtime.Serialization;

namespace MaxApiLibrary.Implementations.InternalClasses;

/// <inheritdoc />
[Serializable]
public class AttachmentNotReadyException : Exception
{
    /// <inheritdoc />
    public AttachmentNotReadyException()
    {
    }

    /// <inheritdoc />
    protected AttachmentNotReadyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    /// <inheritdoc />
    public AttachmentNotReadyException(string? message) : base(message)
    {
    }

    /// <inheritdoc />
    public AttachmentNotReadyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
