using Dapper;
using DapperExtensions;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly string connectionString;

        public Repository(string connection)
        {
            this.connectionString = connection;
        }

        public void Add<T>(T data) where T : class
        {
            var insertQuery = new StringBuilder($"INSERT INTO {typeof(T).Name} ")
                .Append("( ")
                .Append(String.Join(" , ", ListOfPropertiesName(data)))
                .Append(" ) VALUES ( ")
                .Append(String.Join(" , ", ListOfPropertiesName(data).Select(i => "@" + i)))
                .Append(" ) ");
            using var connection = CreateConnection();
            connection.Execute(insertQuery.ToString(), data);
        }

        public T Find<T>(Expression<Func<T, object>> expression, object value) where T : class
        {
            using var connection = CreateConnection();
            return connection.GetList<T>(Predicates.Field<T>(expression, Operator.Eq, value))?.FirstOrDefault();
        }

        public IEnumerable<T> GetBy<T>(Expression<Func<T, object>> expression, object value) where T : class
        {

            using var connection = CreateConnection();
            return connection.GetList<T>(Predicates.Field<T>(expression, Operator.Eq, value)).ToList();
        }

        public void Remove<T>(T data) where T : class
        {
            using var connection = CreateConnection();
            connection.Delete(data);
        }

        public void Remove<T>(IEnumerable<T> data) where T : class
        {
            using var connection = CreateConnection();
            connection.Delete(data);
        }

        public void Update<T>(IEnumerable<T> datas) where T : class
        {
            var updateQuery = new StringBuilder();
            foreach (var data in datas)
            {
                updateQuery.Append($"UPDATE {typeof(T).Name} SET ")
                .Append(String.Join(" , ", ListOfPropertiesNameParam(data)))
                .Append(" where ")
                .Append(String.Join(" and ", KeyListOfProperties<T>(data)))
                .Append("; ");
            }
            using var connection = CreateConnection();
            connection.Execute(updateQuery.ToString(), datas);
        }

        public void Update<T>(T data) where T : class
        {
            var updateQuery = new StringBuilder($"UPDATE {typeof(T).Name} SET ")
                .Append(String.Join(" , ", ListOfPropertiesNameParam(data)))
                .Append(" where ")
                .Append(String.Join(" and ", KeyListOfProperties<T>(data)));
            using var connection = CreateConnection();
            connection.Execute(updateQuery.ToString(), data);
        }

        private IDbConnection CreateConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        private List<string> ListOfPropertiesNameParam<T>(T data)
        {
            return data.GetType().GetProperties()
                .Where(i => !i.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase)
                && !i.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase)
                && CheckType(i, data))
                .Select(i => String.Concat(i.Name, " = @", i.Name))
                .ToList();
        }

        private List<string> ListOfPropertiesName<T>(T data) => data.GetType().GetProperties()
                .Where(i => CheckType<T>(i, data))
                 .Select(i => i.Name).ToList();

        private List<string> KeyListOfProperties<T>(T data)
        {
            return data.GetType().GetProperties()
                .Where(i => i.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase) || i.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase))
                .Select(i => String.Concat(i.Name, " = @", i.Name)).ToList();
        }

        private bool CheckType<T>(PropertyInfo property, T data)
        {
            var name = property.PropertyType;
            if (property.PropertyType == typeof(DateTime))
            {
                return (DateTime)property.GetValue(data) >= new DateTime(1800, 1, 1) && (DateTime)property.GetValue(data) != null;
            }
            else if (property.PropertyType.IsValueType)
            {
                return Convert.ToInt32(property.GetValue(data)) != 0;
            }
            return property.GetValue(data) != null;
        }


    }
}
