using System;
using System.Text;
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
            Console.WriteLine(FindSubString("текст1232"));
            Console.WriteLine(ValidatePassword("Affef2bbfc"));
            Console.WriteLine(ValidatePostCode("123-123"));
            Console.WriteLine(ValidatePhone("+380-98-433-45-67"));
            Console.WriteLine(ReplacePhoneNumbers("Phone: +380-98-433-45-67 My phone +380-98-433-45-67 Another phone: +380-93-045-27-80"));
            foreach (var item in ToUpperArray(new string[] { "иван иванов", "светлана иванова-петренко" }))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(From64ToDefault("0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10L" +
                "rRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C/0L7Qu9C90LXQvdC+INCy0LXRgNC90L4gOik="));

            int[] arr = { 4, 2, 5, 1, 54, 7, 2, 5, -2, -24 };
            QuickSort<int>(arr);
            foreach (var item in arr)
            {
                Console.Write(String.Concat(item, " "));
            }
            Console.ReadKey();
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
            Console.WriteLine(Math.Round((decimal)first / second, 2));
        }

        public static void ReadNumber()
        {
            int enterNumber;
            var userPrint = Console.ReadLine();
            int.TryParse(userPrint, out enterNumber);
            // int pow = 0;
            // while (enterNumber > 9)
            // {
            //    pow++;
            //    enterNumber /= 10;
            // }
            // Console.WriteLine($"{enterNumber}*10^{pow}");
            Console.WriteLine(enterNumber.ToString("E"));

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
            return new DateTime(year, month, day);
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
            var match = Regex.Matches(str, @"\w+[0-9]+");
            return match.Count;
        }

        public static bool ValidatePassword(string password)
        {
            Regex regex = new Regex("^(?=.*[A-Z].*)(?=.*[a-z].*)(.*[0-9].*).{3,}$");
            return regex.IsMatch(password);
        }

        public static bool ValidatePostCode(string postcode)
        {
            Regex regex = new Regex("^[0-9]{3}-[0-9]{3}$");
            return regex.IsMatch(postcode);
        }

        public static bool ValidatePhone(string phonenumber)
        {
            Regex regex = new Regex(@"^\+380-[9][0-9]-[0-9]{3}-[0-9]{2}-[0-9]{2}$");
            return regex.IsMatch(phonenumber);
        }

        public static string ReplacePhoneNumbers(string str)
        {
            Regex regex = new Regex(@"\+380-[9][0-9]-[0-9]{3}-[0-9]{2}-[0-9]{2}");
            return regex.Replace(str, "+XXX-XX-XXX-XX-XX");
        }

        public static string[] ToUpperArray(string[] names)
        {
            string[] upperNames = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                var namePerson = names[i].Split(' ');
                var firstname = FirstCharToUpper(namePerson[0]);
                string secondname;
                if (namePerson[1].Contains('-'))
                {
                    var temp = namePerson[1].Split('-');
                    secondname = FirstCharToUpper(temp[0]) + '-' + FirstCharToUpper(temp[1]);
                }
                else
                {
                    secondname = FirstCharToUpper(namePerson[1]);
                }
                upperNames[i] = String.Concat(firstname, " ", secondname);
            }
            return upperNames;
        }

        public static string FirstCharToUpper(string input)
        {
            return input[0].ToString().ToUpper() + input.Substring(1);
        }

        public static string From64ToDefault(string data)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(data)).ToString();
        }

        public static void QuickSort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
            void Sort(T[] arr, int left, int right)
            {
                if (left.CompareTo(right) < 0)
                {
                    int pivot = Partition(arr, left, right);

                    if (pivot > 1)
                    {
                        Sort(arr, left, pivot - 1);
                    }
                    if (pivot + 1 < right)
                    {
                        Sort(arr, pivot + 1, right);
                    }
                }

            }
            int Partition(T[] arr, int left, int right)
            {
                T pivot = arr[left];
                while (true)
                {

                    while (arr[left].CompareTo(pivot) < 0)
                    {
                        left++;
                    }

                    while (arr[right].CompareTo(pivot) > 0)
                    {
                        right--;
                    }

                    if (left < right)
                    {
                        if (arr[left].CompareTo(arr[right]) == 0) return right;

                        T temp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = temp;
                    }
                    else
                    {
                        return right;
                    }
                }

            }
        }
    }
}
