using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace TextFileCSV
{
    class StreamWriterCSV<T>
    {
        IParser<List<PropertyInfo>> parser;
        public StreamWriterCSV(IParser<List<PropertyInfo>> parser)
        {
            this.parser = parser;
        }
        public bool SaveCSV(string filename,string data, List<T> people)
        {
            List<PropertyInfo> properties = parser.Parse(data);
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Default))
                {   
                    for (int i = 0; i < properties.Count; i++)
                    {
                        sw.Write(String.Concat($"\"{ properties[i].Name }\""));
                        if (i != properties.Count - 1)
                        {
                            sw.Write(String.Concat($","));
                        }
                    }
                    sw.WriteLine();
                    foreach (var item in people)
                    {
                        for (int i = 0; i < properties.Count; i++)
                        {
                            var value = properties[i].GetValue(item);
                            value = (Convert.ToBoolean(value?.Equals(0)) || Convert.ToBoolean(value?.Equals(null))) ? "" : value;
                            sw.Write(String.Concat($"\"{ value }\""));
                            if (i != properties.Count - 1)
                            {
                                sw.Write(String.Concat($","));
                            }
                        }
                        sw.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }
    }
}
