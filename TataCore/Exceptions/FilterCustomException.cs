using System;
using System.Collections.Generic;
using System.Text;

namespace TataCore.Exceptions
{
    [Serializable]
    public class FilterCustomException : Exception
    {
        public FilterCustomException()
        {

        }

        public FilterCustomException(string message)
            : base(String.Format("Error: {0}", message))
        {

        }
    }
}
