using System;
using System.Collections.Generic;

namespace Dz1
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = @"Text: file.txt(6B); Some string content
                            Image: img.bmp(19MB); 1920х1080
                            Text:data.txt(12B); Another string
                            Text:data1.txt(7B); Yet another string
                            Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";

            Dictionary<FileType, IParser<File>> parsers = new Dictionary<FileType, IParser<File>>();
            parsers.Add(FileType.Image, new ParserImg());
            parsers.Add(FileType.Text, new ParserText());
            parsers.Add(FileType.Movie, new ParserVideo());

            Parser parser = new Parser(parsers);
            FileControl control = new FileControl(parser,new ComparerFileBySize());
            control.Parse(text);
            Console.WriteLine(control.ToString());
            
        }
    }
}
