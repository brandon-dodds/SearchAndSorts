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
            PrintArray(sortedArray);
            Searches.BinarySearch(sortedArray, 3);
        }
    }
}
