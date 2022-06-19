using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2projekt
{
    /// <summary>
    /// Exceptionklass för nullhantering
    /// </summary>
    class NullValueException : ApplicationException
    {
        public NullValueException(string message) : base(message)
        {

        }
    }
}
