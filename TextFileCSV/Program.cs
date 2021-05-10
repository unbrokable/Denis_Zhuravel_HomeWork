using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace TextFileCSV
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Write name of properties ");
           string userData = Console.ReadLine();
           var writerCSV = new StreamWriterCSV<Person>(new Parser<Person>());

           if( writerCSV.SaveCSV("file.csv", userData, PersonList.GetListPerson()))
            {
                Console.WriteLine("File save");
            }
        }
      

    }
}
   
