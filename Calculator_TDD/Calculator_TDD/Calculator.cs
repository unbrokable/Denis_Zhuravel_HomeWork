using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator_TDD
{
    public class Calculator
    {
        private int countOfCallMethodAdd;
        public event Action<string, int> AddOccured;      
        
        public Calculator() { }
        public Calculator(Action<string,int> action)
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
            int[] arr;
            
            if (numbers.StartsWith("//") && !numbers.StartsWith("//["))
            {
                var delimiter = numbers.Substring(0,numbers.IndexOf("\n"))
                    .Replace("//","");
                var arrayOfnumbers = numbers.Remove(0, numbers.IndexOf("\n")+1);
                arr = arrayOfnumbers.Split(delimiter).Select(i => int.Parse(i)).ToArray();
            }
            else if (numbers.StartsWith("//["))
            {
                var delimiter = numbers.Substring(0, numbers.IndexOf("\n"))
                   .Replace("//", "").Replace("][", " ")
                   .Replace("[", "")
                   .Replace("]", "").Split(" ");
                var arrayOfnumbers = numbers.Remove(0, numbers.IndexOf("\n") + 1);
                for (int i = 0; i < delimiter.Length; i++)
                {
                    arrayOfnumbers = arrayOfnumbers.Replace(delimiter[i], " ");
                }
                arr = arrayOfnumbers.Split(" ").Select(i => int.Parse(i)).ToArray();
            }
            else
            {
                arr = numbers.Split(new char[] { ',', ' ', '\n' }).Select(i => int.Parse(i)).ToArray();
            }
            
            var arrNegativeNumbers = arr.Where(i => i < 0);
            
            if (arrNegativeNumbers.Count() == 1)
            {
                throw new ArgumentException("negatives not allowed");
            }
            else if (arrNegativeNumbers.Count() >  1)
            {
                throw new ArgumentException($"negatives not allowed {String.Join(',', arrNegativeNumbers)}");
            }

            AddOccured?.Invoke(numbers, numbers.Length);
            return arr.Where(i => i < 1000).Sum();
        }

        public int GetCalledCount() => countOfCallMethodAdd;  
    }
}
