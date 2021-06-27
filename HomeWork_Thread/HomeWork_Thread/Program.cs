using System;
using System.Threading;
using System.Linq;
namespace HomeWork_Thread
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            int amountOfThread = Environment.ProcessorCount;
            Console.WriteLine("Hello World!");
            var list =  CreateArray(20, amountOfThread).ToList();
            list.ForEach(i => Console.Write(i + " "));
            Console.WriteLine("\nTask 2");
            CopyArray(list.ToArray(), amountOfThread, 4, 10).ToList().ForEach(i => Console.Write(i + " "));
            Console.WriteLine("\nMin");
            Console.WriteLine(FindMinimumNumber(list.ToArray(), amountOfThread));
            Console.WriteLine("Avg");
            Console.WriteLine(FindAvgNumber(list.ToArray(), amountOfThread));
        }
  
        static int[] CopyArray(int[] arr,int amountOfThread,int start, int end)
        {
            int[] copyArr = new int[end-start]; 
            Thread[] arrThread = new Thread[(copyArr.Length < amountOfThread) ? copyArr.Length : amountOfThread];
            int amountOfElemOnThread = copyArr.Length / amountOfThread;
            int modul = copyArr.Length % amountOfThread;
            
            for (int i = 0, arrIndex = start, copyIndex=0; arrIndex < end; i++)
            {
                int index = arrIndex;
                int copyIndexTemp = copyIndex;
                if (arrThread.Length - modul <= i)
                {
                    arrThread[i] = new Thread(i => Copy(arr,copyArr, index, index + amountOfElemOnThread + 1, copyIndexTemp));
                    arrIndex += amountOfElemOnThread+1;
                    copyIndex += amountOfElemOnThread+1;
                }
                else
                {
                    arrThread[i] = new Thread(i => Copy(arr, copyArr, index, index + amountOfElemOnThread , copyIndexTemp));
                    arrIndex += amountOfElemOnThread;
                    copyIndex += amountOfElemOnThread;
                } 
                arrThread[i].Start();
            }
            for (int i = 0; i < arrThread.Length; i++)
            {
                arrThread[i].Join();
            }
            return copyArr;

            void Copy(int[] arrMain, int[] arrCopy,int indexStartMain, int indexEndMain, int indexStartCopy)
            {
                for (int i = indexStartMain, c = indexStartCopy; i < indexEndMain; i++,c++)
                {
                    arrCopy[c] = arrMain[i];
                }
            }

        }   

        static int[] CreateArray(int length,int amountOfThread)
        {
            int[] arr = new int[length];
            Thread[] arrThread = new Thread[(length < amountOfThread) ? length : amountOfThread];
            int amountOfElemOnThread = length / amountOfThread;
            int modul = length % amountOfThread;
            for (int i = 0,indexArr=0; i < arrThread.Length; i++)
            {
                int temp = amountOfElemOnThread;
                int index = indexArr;
                if (arrThread.Length - modul <= i) { 
                    arrThread[i] = new Thread(i => FillArr(arr, index, index + temp+1));
                    indexArr += amountOfElemOnThread+1;
                }
                else
                {
                    arrThread[i] = new Thread(i => FillArr(arr, index, index + temp));
                    indexArr += amountOfElemOnThread;
                }
                arrThread[i].Start();
            }
            for (int i = 0; i < arrThread.Length; i++)
            {
                arrThread[i].Join();
            }
            return arr;

            void FillArr(int[] arr,int startindex, int endindex)
            {
                for (int i = startindex; i < endindex; i++)
                {
                    arr[i] = new Random().Next(10, 100);
                   
                }
            }

        } 

        static int FindMinimumNumber(int[] arr, int amountOfThread)
        {
            Thread[] arrThread = new Thread[(arr.Length < amountOfThread) ? arr.Length : amountOfThread];
            int amountOfElemOnThread = arr.Length / amountOfThread;
            int modul = arr.Length % amountOfThread;
            int minimum = arr[0];

            for (int i = 0, indexArr = 0; i < arrThread.Length; i++)
            {
                int temp = amountOfElemOnThread;
                int index = indexArr;
                if (arrThread.Length - modul <= i)
                {
                    arrThread[i] = new Thread(i => Min(arr, index, index + temp + 1));
                    indexArr += amountOfElemOnThread + 1;
                }
                else
                {
                    arrThread[i] = new Thread(i => Min(arr, index, index + temp));
                    indexArr += amountOfElemOnThread;
                }
                arrThread[i].Start();
            }

            for (int i = 0; i < arrThread.Length; i++)
            {
                arrThread[i].Join();
            }
            return minimum;

            void Min(int[] arr, int startindex, int endindex)
            {
                for (int i = startindex; i < endindex;i++)
                {
                    lock (locker)
                    {
                        if(minimum > arr[i])
                        {
                            minimum = arr[i];
                        }
                    }
                }
            }
        }

        static double FindAvgNumber(int[] arr, int amountOfThread)
        {
            Thread[] arrThread = new Thread[(arr.Length < amountOfThread) ? arr.Length : amountOfThread];
            int amountOfElemOnThread = arr.Length / amountOfThread;
            int modul = arr.Length % amountOfThread;
            double avg = 0;

            for (int i = 0, indexArr = 0; i < arrThread.Length; i++)
            {
                int temp = amountOfElemOnThread;
                int index = indexArr;
                if (arrThread.Length - modul <= i)
                {
                    arrThread[i] = new Thread(i => Avg(arr, index, index + temp + 1));
                    indexArr += amountOfElemOnThread + 1;
                }
                else
                {
                    arrThread[i] = new Thread(i => Avg(arr, index, index + temp));
                    indexArr += amountOfElemOnThread;
                }
                arrThread[i].Start();
            }

            for (int i = 0; i < arrThread.Length; i++)
            {
                arrThread[i].Join();
            }
            return avg/arr.Length;

            void Avg(int[] arr, int startindex, int endindex)
            {
                double avglocal = 0;
                for (int i = startindex; i < endindex; i++)
                {
                    avglocal += arr[i];
                }
                lock (locker)
                {
                    avg += avglocal;
                }
            }
        }


    }
}
