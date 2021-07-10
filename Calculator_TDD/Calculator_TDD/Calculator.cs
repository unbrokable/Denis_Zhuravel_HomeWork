using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator_TDD
{
    public class Calculator
    {
        private int countOfCallMethodAdd;
        public event Action<string, int> AddOccured;

        public Calculator() { }
        public Calculator(Action<string, int> action)
        {
            this.AddOccured = action;
        }

        public int Add(string numbers)
        {
            countOfCallMethodAdd++;

            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<string> collection = new List<string>();

            foreach (Match match in Regex.Matches(numbers,@"\[.*?\]"))
            {
                collection.Add(match.Value);
            }

            foreach (Match match in Regex.Matches(numbers, @"^[^0-9]*\n"))
            {
                collection.Add(match.Value);
            }

            Regex regexInvalidSymbols = new Regex(@"(\[)|(\])|(\/\/)|(\n)");
            string delimiter = regexInvalidSymbols
                .Replace(String.Join("|", collection), "")
                .Replace("*", @"\*");

            if(delimiter.Length == 0)
            {
                var regexDelimiter = new Regex(@",| |\n");
                numbers = regexDelimiter.Replace(numbers, " ");
            }
            else
            {
                var regexDelimiter = new Regex(delimiter);
                numbers = regexDelimiter.Replace(numbers.Substring(numbers.IndexOf("\n") == -1 ? 0 : numbers.IndexOf("\n")), " ");
            }
            
            var arr = numbers.Split(" ").Select(i => int.Parse(i));
            if (arr.Where(i => i < 0).Any())
            {
                throw new ArgumentException($"negatives not allowed {String.Join(',', arr.Where(i => i < 0))}");
            }

            AddOccured?.Invoke(numbers, numbers.Length);
            return arr.Where(i => i < 1000).Sum();
        }

        public int GetCalledCount() => countOfCallMethodAdd;
    }
}
