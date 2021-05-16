using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
            };

            PrintRange(10, 50);
            PrintRangeDividing3(10, 50);
            PrintWordnTimes(10);
            PrintWordsContain("aaa;abb;ccc;dap");
            PrintAmountChar("aaa;abb;ccc;dap");
            PrintContainSubstring("aaa;xabbx;abb;ccc;dap");
            PrintMaxLengthWord("aaa;xabbx;abb;ccc;dap");
            PrintAvgLengthWord("aaa;xabbx;abb;ccc;dap");
            PrintMinLengthWordReverse("aaa;xabbx;abb;ccc;dap;zh");
            PrintFilterWords("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh");
            PrintAllWordExcept(new string[] { "qweqwbb", "cool", "coolbb", "bbbbb" });

            Console.WriteLine("\nPart 2 ");
            var controller = new ArtObjectController(data);
            controller.RunAllMethod();
        }

        static void PrintRange(int start, int end)
        {
            StringBuilder @string = new StringBuilder();
            Enumerable.Range(start, end - start).ToList().ForEach(i => @string.Append(i).Append(','));
            Console.WriteLine(@string.ToString().Remove(@string.Length - 1));
        }

        static void PrintRangeDividing3(int start, int end)
        {
            Enumerable.Range(start, end - start)
                .Where(i => i % 3 == 0)
                .ToList().ForEach(i => Console.Write($"{i} "));
            Console.WriteLine();
        }

        static void PrintWordnTimes(int time)
        {
            Console.WriteLine(
                    Enumerable.Repeat("Linq", time)
                        .Aggregate((a, b) => String.Concat(a, " ", b)).ToString());
        }

        static void PrintWordsContain(string data)
        {
            var words = data.Split(';')
                .Where(i => i.Contains('a'))
                .Aggregate((a, b) => String.Concat(a, " ", b));
            Console.WriteLine(words);
        }

        static void PrintAmountChar(string data)
        {
            var info = data.Split(";")
                .Select(i => String.Concat(i, ":", i.Where(j => j.CompareTo('a') == 0).Count()))
                .Aggregate((a, b) => String.Concat(a, ",", b));
            Console.WriteLine(info);
        }

        static void PrintContainSubstring(string data, string substring = "abb")
        {
            var info = data.Split(";")
                .Select(i => String.Concat(i, ":", i.Contains(substring).ToString()))
                .Aggregate((a, b) => String.Concat(a, " , ", b));
            Console.WriteLine(info);
        }

        static void PrintMaxLengthWord(string data)
        {
            Console.WriteLine(data.Split(";").OrderByDescending(i => i.Length).FirstOrDefault());
        }

        static void PrintAvgLengthWord(string data)
        {
            Console.WriteLine(data.Split(";").Average(i => i.Length));
        }

        static void PrintMinLengthWordReverse(string data)
        {
            var word = data.Split(";")
                .OrderBy(i => i.Length)
                .FirstOrDefault()
                .Reverse()
                .Aggregate(new StringBuilder(), (a, b) => a.Append(b));
            Console.WriteLine(word.ToString());
        }

        static void PrintFilterWords(string data)
        {
            var info = data.Split(";")
                .Select(i => string.Concat(i, ":", (i.StartsWith("aa") && i.Skip(2).All(j => j.CompareTo('b') == 0)).ToString()))
                .Aggregate((a, b) => String.Concat(a, ",", b));
            Console.WriteLine(info);
        }

        static void PrintAllWordExcept(string[] data)
        {
            var info = data.Except(data.Where(j => j.EndsWith("bb")).Take(2))
                .Aggregate((a, b) => String.Concat(a, " ", b));
            Console.WriteLine(info);
        }
    }
}
