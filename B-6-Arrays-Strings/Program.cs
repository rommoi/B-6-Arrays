using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    class Program
    {

        static Random rnd = new Random();

        static void Main(string[] args)
        {

            //Create3_3Array();
            Pyatnashki();
            //CutString();
            //ReplacePoem();
            //ЗDMassiveMaxInRow();
            //_1DMassiveSort();

            Console.WriteLine("press enter...");
            Console.ReadLine();
        }

        public static void Pyatnashki()
        {
            Piatnashki p = new Piatnashki();
            p.Play();

        }

        public static void PoemExample()
        {

        }


        public static int[,] CreateArray(int items)
        {

            int[,] arrTemp = new int[items, items];

            //PrintArray(arr, arrX, arrY);
            int counter = 0;

            for (int i = 0; i < items; i++)
            {
                for (int j = 0; j < items; j++)
                {
                    arrTemp[i, j] = counter++;
                }
            }
            //PrintArray(arr, arrX, arrY);
            return arrTemp;

        }

        private static void PrintArray(int[,] arr, int arrX, int arrY)
        {
            //var c = arr.Length / arr.Rank;

            for (int i = 0; i < arrX; i++)
            {
                for (int j = 0; j < arrY; j++)
                {
                    Console.Write("\t" + arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static void CutString()
        {
            Console.WriteLine("Enter string, please:");
            string s = Console.ReadLine();

            Console.WriteLine($"String length is {s.Length}");
            int length = 0;
            for (int i = 0; i < s.Length; i++)
            {
                length++;
            }

            if (s.Length > 13)
            {
                char[] newStr = new char[13];
                for (int i = 0; i < 13; i++)
                {
                    newStr[i] = s[i];
                }
                //string subString = newStr.ToString();
                Console.WriteLine($"Cutted string: {new string(newStr)}...");
            }
        }

        private static void ReplacePoem()
        {
            Console.WriteLine("Enter your poem:");
            string s = Console.ReadLine();

            if (String.IsNullOrEmpty(s))
            {
                s = "жили были старик со старухой;у самого синего моря;пошел старик ловить рыбку;и поймал...";
            }
            Console.WriteLine(s);

            string[] arr = s.Split(';');

            Console.WriteLine("\nReplaced String:\n");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].ToUpper().Replace('О', 'А').Replace("Л", "ЛЬ").Replace("ТЬ", "Т").ToLower());
            }
            Console.WriteLine();



        }

        private static void ЗDMassiveMaxInRow()
        {
            int[,] arr = new int[3, 3];

            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = rnd.Next(int.MinValue, int.MaxValue);
                }
            }

            PrintArray(arr, 3, 3);

            for (int i = 0; i < 3; i++)
            {
                int maxValue = int.MinValue;
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] > maxValue) maxValue = arr[i, j];
                }
                Console.WriteLine($"{i + 1} row max value: {maxValue}");
            }

        }

        private static void _1DMassiveSort()
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
            }
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

            BubbleSort(arr);

            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

        }

        //sort int array funcs
        private static int[] BubbleSort(int[] arr)
        {
            bool _isSorted = false;
            while (!_isSorted)
            {
                int tempVar;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1]) SwapItems(ref arr[i], ref arr[i + 1]);
                }
                _isSorted = true;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1]) _isSorted = false;
                }
            }


            return arr;
        }
        private static void SwapItems(ref int first, ref int second)
        {
            int tempVar = first;
            first = second;
            second = tempVar;
        }


    }
}
