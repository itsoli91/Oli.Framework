using System;

namespace Oli.Framework.Domain
{
    public interface IEntityConfiguration
    {
        Type EntityType { get; }
    }
}