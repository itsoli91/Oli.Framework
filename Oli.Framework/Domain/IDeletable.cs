using System;

namespace Oli.Framework.Domain
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime DeleteTime { get; set; }
    }
}