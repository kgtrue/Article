using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Common
{
    public interface IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
