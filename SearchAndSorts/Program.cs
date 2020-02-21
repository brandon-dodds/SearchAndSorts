using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SearchAndSorts
{
    class Program
    {
        public static void printArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {
            string lines = File.ReadAllText("Net_1_256.txt");
            var result = Regex.Split(lines, "\r\n|\r|\n");
            int[] unsorted = new int[result.Length - 1];
            for (int i = 0; i < result.Length - 1; i++)
            {
                unsorted[i] = int.Parse(result[i]);

            }
            var x = File.AppendText("TextFile1.txt");
            x.Flush();
            for (int i = 0; i < unsorted.Length; i++)
            {
                string y = unsorted[i].ToString();
                x.WriteLine(y);
            }
            x.Close();
            printArray(unsorted);
            var sorted2 = Sorts.PrintTree(unsorted, "asc");
            printArray(sorted2);
            Searches.BinarySearch(sorted2, 3);
        }
    }
}
