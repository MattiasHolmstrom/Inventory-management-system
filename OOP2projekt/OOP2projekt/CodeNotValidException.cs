using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2projekt
{
    /// <summary>
    /// Exceptionklass
    /// </summary>
    class CodeNotValidException : ApplicationException
    {
        public CodeNotValidException(string message) : base(message)
        {

        }
    }
}