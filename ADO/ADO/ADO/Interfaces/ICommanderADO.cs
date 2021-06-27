using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.Interfaces
{
    interface ICommanderADO
    {
        public IEnumerable<T> Execute<T>(string sqlExpression, Dictionary<string, object> parameters) where T : class,new();
    }
}
