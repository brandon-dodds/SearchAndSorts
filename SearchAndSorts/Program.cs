using System;

namespace SearchAndSorts
{
    class Program
    {
        static void printArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 7, 3, 5, 1 };
            Sorts.insertionSort(array);
            printArray(array);
        }
    }
}
