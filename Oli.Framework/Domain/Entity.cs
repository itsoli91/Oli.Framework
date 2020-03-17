using System;

namespace Oli.Framework.Domain
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public Entity()
        {
            CreationUtcTime = DateTime.UtcNow;
            CreationLocalTime = DateTime.Now;
        }

        public TKey Id { get; protected set; }
        public DateTime CreationUtcTime { get; protected set; }
        public DateTime CreationLocalTime { get; protected set; }
    }
}