using ADO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO
{
    class CommanderADO: ICommanderADO
    {
        private readonly string connectionString;
        private readonly IParser<string[]> parser;
        public CommanderADO( string connectionSring, IParser<string[]> parser)
        {
            this.connectionString = connectionSring;
            this.parser = parser;
        }

        public IEnumerable<T> Execute<T>(string sqlExpression, Dictionary<string, object> parameters) where T: class, new()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            string[] parametersName = parser.Parse(sqlExpression);
            for (int i = 0; i < parametersName.Length; i++)
            {
                SqlParameter param = new SqlParameter(parametersName[i], parameters[parametersName[i]]);
                command.Parameters.Add(param);
            }
            SqlDataReader reader = command.ExecuteReader();
            List<T> result = new List<T>();
            while (reader.Read())
            {
                result.Add(GetClass(reader));
            }
            return result;

            T GetClass(SqlDataReader reader) 
            {
                T data = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(data, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                }
                return data;
            }
        }
    }
}
