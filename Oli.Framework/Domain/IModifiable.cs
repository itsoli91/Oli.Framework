using System;

namespace Oli.Framework.Domain
{
    public interface IModifiable
    {
        DateTime LastModifiedTime { get; set; }
    }
}
