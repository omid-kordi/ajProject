using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Core.Exceptions
{
    public class SYException : Exception
    {

        public SYException(string message)
            : base(message)
        {
        }
    }

    public class SYInvalidAccessException : Exception
    {

        public SYInvalidAccessException(string message)
            : base(message)
        {
        }
    }
}
