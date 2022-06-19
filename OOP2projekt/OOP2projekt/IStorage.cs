using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2projekt
{
    /// <summary>
    /// Interface som används för våra lagringsklasser
    /// </summary>
    interface IStorage
    {
        void serializejson();
        void deserializejson();

    }
}
