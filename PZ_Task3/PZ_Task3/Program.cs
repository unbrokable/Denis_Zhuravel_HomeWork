using System;
using System.Text.RegularExpressions;

namespace PZ_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers("adf124jfj35");
            DivideNumber(4, 6);
            ReadNumber();
            ShowDateISO(DateTime.Now);
            Console.WriteLine(ParseDate("2016 21-07"));
            Console.WriteLine(ParseArrayNumbers("12,23,4,2,4,12"));
            Console.WriteLine(FindSubString("abc1212121212"));
            Console.WriteLine(ValidatePassword("1Ab2bfc"));

        }
        public static void PrintNumbers(string str)
        {
            foreach (var item in str)
            {
                Regex rgx = new Regex("[0-9]");
                if (rgx.IsMatch(item.ToString()))
                {
                    Console.Write(item);
                }
                
            }
            Console.WriteLine();
        }
        public static void DivideNumber(int first, int second)
        {
            Console.WriteLine(Math.Round((decimal)first/second, 2));
        }
        public static void ReadNumber()
        {
            decimal  enterNumber;
            var userPrint = Console.ReadLine();
            decimal.TryParse(userPrint, out enterNumber);
            int pow = 0;
            while (enterNumber > 9)
            {
                pow++;
                enterNumber /= 10;
            }
            Console.WriteLine($"{enterNumber}*10^{pow}");


        }
        public static void ShowDateISO(DateTime date)
        {
            Console.WriteLine(date.ToString("o"));
        }
        public static DateTime ParseDate(string data)
        {
            var date = data.Split(new char[] { ' ', '-' });
            int.TryParse(date[0], out int year);
            int.TryParse(date[1], out int day);
            int.TryParse(date[2], out int month);
            return new DateTime(year, month,day);
        }
        public static int ParseArrayNumbers(string data)
        {
            var strArray = data.Split(',');
            int sum = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                int.TryParse(strArray[i], out int temp);
                sum += temp;
            }
            return sum;
        }
        public static int FindSubString(string str)
        {
            var match = Regex.Matches(str, "[a-zA-Z]+[0-9]+");
            return match.Count;
        }
        public static bool ValidatePassword(string password)
        {
            Regex regex = new Regex("^((?=.*[A-Z])(?=.*[0-9])){6,}$");
            return regex.IsMatch(password);
        }
        public static bool ValidatePostCode(string postcode)
        {
            Regex regex = new Regex("^[0-9]{3}-[0-9]{3}$");
            return regex.IsMatch(postcode);
        }
        public static bool ValidatePhone(string phonenumber)
        {
            Regex regex = new Regex("^/+380-[9][0-9]-[0-9]{3}-[0-9]{2}-[0-9]{2}$");
            return regex.IsMatch(phonenumber);
        }
        public static string ReplacePhoneNumbers(string str)
        {
            Regex regex = new Regex("/+380-[9][0-9]-[0-9]{3}-[0-9]{2}-[0-9]{2}");
            return regex.Replace(str, "+XXX-XX-XXX-XX-XX");
        }
        public static string[] ToUpperArray(string[] names)
        {
            string[] upperNames = new string[names.Length];
            for(int i = 0; i < names.Length; i++)
            {
                var namePerson = names[i].Split(' ');
                var firstname = FirstCharToUpper(namePerson[0]);
                string secondname;
                if (namePerson[1].Contains('-'))
                {
                    var temp = namePerson[1].Split('-');
                    secondname = FirstCharToUpper(temp[0])+'-'+ FirstCharToUpper(temp[1]);
                }
                else
                {
                   secondname = FirstCharToUpper(namePerson[1]);
                }
                upperNames[i] = String.Concat(firstname," ", secondname);
            }
            return upperNames;
        }
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input[0].ToString().ToUpper() + input.Substring(1);
        }
    }


}
