using System;

namespace Oli.Framework.Domain
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
        DateTime CreationUtcTime { get; }
        DateTime CreationLocalTime { get; }


    }
}