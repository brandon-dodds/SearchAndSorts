using System;

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
            int[] array = { 1, 2, 3, 4, 5 };
            var sorted = Sorts.MergeSort(array, "asc");
            printArray(sorted);
            Searches.BinarySearch(sorted, 3);
        }
    }
}
