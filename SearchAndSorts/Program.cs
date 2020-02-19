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
            int[] unsorted = { 5,4,7,2,11,14,6 };
            printArray(unsorted);

            int[] sorted = Sorts.MergeSort(unsorted, "asc");
            printArray(sorted);
            Sorts.PrintTree(unsorted, "asc");
        }
    }
}
