using System;

namespace Oli.Framework.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
        long SequentialId { get; }
        DateTime CreationUtcTime { get; }
        DateTime CreationLocalTime { get; }


    }
}