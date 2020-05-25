using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Common
{
    public abstract class BaseEntity<TType, TId> : IEntity
    {    
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
