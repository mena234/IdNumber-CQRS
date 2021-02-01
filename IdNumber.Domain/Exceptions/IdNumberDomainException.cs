using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdNumber.Domain.Exceptions
{
    public class IdNumberDomainException : Exception
    {
        public IdNumberDomainException()
        {
            
        }

        public IdNumberDomainException(string message) : base(message)
        {
            
        }

        public IdNumberDomainException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
