using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TextFileCSV
{
    interface IParser<T> {

        T Parse(string data);
    }

    class Parser<T> : IParser<List<PropertyInfo>> where T: class
    {
        public List<PropertyInfo> Parse(string data)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();
            var stringProperties = data.Split(",");
            foreach (var property in stringProperties)
            {
                Type type = typeof(T);
                if (type.GetProperty(property) != null)
                {
                    properties.Add(type.GetProperty(property));
                }
            }
            return properties;
        }
    }
    
}
