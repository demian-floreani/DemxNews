using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Exceptions
{
    public class AppException : Exception
    {
        public ExceptionType _type { get; private set; }

        public AppException(ExceptionType type)
        {
            _type = type;
        }

        public AppException(ExceptionType type, Exception ex) : base("Application exception.", ex)
        {
            _type = type;
        }
    }
}
