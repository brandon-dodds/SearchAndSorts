using System;

namespace SearchAndSorts
{
    class Program
    {
        public static void PrintArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {
            int amount = 20;
            int[] array = new int[amount];
            Random random = new Random();
            for(int i = 0; i < amount; i++)
            {
                array[i] = random.Next(0, 100);
            }
            int[] sortedArray = Sorts.InsertionSort(array, "asc");
            int[] sortedArray2 = Sorts.PrintTree(array, "asc");
            int[] sortedArray3 = Sorts.MergeSort(array, "asc");
            int[] sortedArray4 = Sorts.Bubblesort(array, "asc");
            PrintArray(sortedArray);
            PrintArray(sortedArray2);
            PrintArray(sortedArray3);
            PrintArray(sortedArray4);
        }
    }
}
