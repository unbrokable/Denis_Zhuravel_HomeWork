using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Interfaces
{
    interface IParser<T>
    {
        T Parse(string data);
    }
}
