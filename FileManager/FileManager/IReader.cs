using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace FileManager
{
    interface IReader
    {
        string Read(string location);
    }

    class ReaderJson : IReader
    {
        public string Read(string location)
        {
            string json = File.ReadAllText(location);
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }

        }
    }

    class ReaderXml : IReader
    {
        public string Read(string location)
        {
            string xml = File.ReadAllText(location);
            return XDocument.Parse(xml).ToString();
        }
    }

    class ReaderText : IReader
    {
        public string Read(string location)
        {
            var data = File.ReadAllText(location);
            return data;
        }
    }

    class ReaderAnorher : IReader
    {
        public string Read(string location)
        {
            return File.ReadAllBytes(location).Aggregate(new StringBuilder(),(a, b) => a.Append(b)).ToString();
        }
    }
}
