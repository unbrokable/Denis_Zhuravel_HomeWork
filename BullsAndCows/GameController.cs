using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    interface IGameController
    {
        bool DataCheck(string data);
        void LoadGame(string userData);
    }
    class GameController:IGameController
    { 
        readonly int amountOfNumbers; 
        public GameController(int amountOfNumbers)
        {
            this.amountOfNumbers = amountOfNumbers;
        }
        public void LoadGame(string userString)
        {
            List<int> userNumber = userString.ToCharArray().Select(i => Int32.Parse(i.ToString())).ToList();
            List<History> computerAnswers = new List<History>();
            List<List<int>> answers = GenerateAllPosibleAnswers();
            while (true)
            {
                Random random = new Random();
                var  temp = new List<int>(answers[random.Next(0,answers.Count)]);
                FindBullCows(userNumber,temp,  out int bulls, out int  cows);
                computerAnswers.Add(new History(temp, cows, bulls));
                RemoveInvalidOption(ref answers, computerAnswers.Last().Answer, computerAnswers.Last().Bulls, computerAnswers.Last().Cows);
                Console.WriteLine(computerAnswers.Last().ToString());
                if (bulls == amountOfNumbers) break;
            }
            Console.WriteLine("Computer win");
        }  
        public bool DataCheck(string data)
        {
            if (string.IsNullOrEmpty(data) || data.Length > amountOfNumbers || !Regex.IsMatch(data, @"^[0-9]{" + amountOfNumbers + "}$"))
            {
                Console.WriteLine($"Your data must contain only {amountOfNumbers} unique numbers");
                return false;
            }
            return true;
        }  
        public List<List<int>> GenerateAllPosibleAnswers()
        {
            List<List<int>> answers = new List<List<int>>();
            int amountOfShift = Convert.ToInt32(Math.Pow(10, amountOfNumbers));
            for (int i = 0; i < amountOfShift; i++)
            {
                answers.Add(GenerateSet(i));
            }
            return answers;
            List<int> GenerateSet(int data)
            {
                List<int> set = data.ToString().ToCharArray().Select(i => Int32.Parse(i.ToString())).ToList();
                if (set.Count < amountOfNumbers)
                {
                    int add = amountOfNumbers - set.Count;
                    var temp = new List<int>();
                    for (int i = 0; i < add; i++)
                    {
                        temp.Add(0);
                    }
                    set.ForEach(i => temp.Add(i));
                    return temp;
                }
                return set;
            }
        }
        public void RemoveInvalidOption(ref List<List<int>> answers, List<int> attempt, int bulls, int cows)
        {
            var newanswers = new List<List<int>>();
            
            for (int i = 0; i < answers.Count; i++)
            {
                if (Check(answers[i] ,attempt, bulls, cows) )
                {
                    newanswers.Add(answers[i]);
                }
            }
            answers = newanswers;
            bool Check(List<int> answer, List<int> attempt, int bulls, int cows)
            {
                FindBullCows(answer, attempt, out int localbulls, out int localcows);
                return bulls == localbulls && cows == localcows;
            }
        }
        public void FindBullCows(List<int> answer, List<int> attempt, out int bulls, out int cows)
        {
            List<int> copyanswer = new List<int>(answer);
            List<int> copyattempt = new List<int>(attempt);
            bulls = FindBulls(copyanswer, copyattempt);
            cows = FindCows(copyanswer, copyattempt);
            int FindBulls(List<int> answer, List<int> attempt)
            {
                int bulls = 0;
                var listindex = new List<int>();
                for (int i = 0; i < attempt.Count; i++)
                {
                    if (answer[i] == attempt[i])
                    {
                        bulls++;
                        listindex.Add(i);
                        
                    }
                }
                listindex.Sort();
                int count = 0;
                listindex.ForEach(i => {
                    answer.RemoveAt(i-count);
                    attempt.RemoveAt(i-count);
                    count++;
                });
                return bulls;
            }
            int FindCows(List<int> answer, List<int> attempt)
            {
                int cows = 0;
                for (int i = 0; i < attempt.Count; i++)
                {
                    for (int j = 0; j < answer.Count; j++)
                    {
                        if (attempt[i] == answer[j])
                        {
                            cows++;
                            attempt.RemoveAt(i);
                            answer.RemoveAt(j);
                            i = 0;
                            break;
                        }
                    }  
                }
                return cows;
            }
        }   
        public class History
        {
            public List<int> Answer { get; set; }
            public int Cows { get; set; }
            public int Bulls { get; set; }

            public History(List<int> answer, int cows, int bulls)
            {
                Answer = answer;
                Cows = cows;
                Bulls = bulls;
            }
            public override string ToString()
            {
                StringBuilder @string = new StringBuilder();
                Answer.ForEach(i => @string.Append(i.ToString()));

                return $"Bulls {Bulls} Cows {Cows } Attemption {@string}";
            }
        }
    }
}
