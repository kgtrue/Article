using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string msg) : base(msg)
        {

        }
    }
}
