using System;
using System.Diagnostics;

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
            int amount = 10;
            int[] unsorted = { 6, 5, 4, 8, 7, 7, 0, 0, 3, 7 };
            printArray(unsorted);

            int[] sorted = Sorts.MergeSort(unsorted, "asc");
            printArray(sorted);
            printArray(Sorts.PrintTree(unsorted, "asc"));
        }
    }
}
