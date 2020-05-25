using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Exceptions
{
    public class CoreValidationException : Exception
    {
        public CoreValidationException(string msg) : base(msg)
        {

        }
    }
}
