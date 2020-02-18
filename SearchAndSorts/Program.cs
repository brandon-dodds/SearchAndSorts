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
            Random random = new Random();
            int amount = 5;
            int[] unsorted = new int[amount];
            for(int i = 0; i < amount; i++)
            {
                unsorted[i] = random.Next(0, 100);
            }
            printArray(unsorted);
            Sorts.Bubblesort(unsorted, "asc");
            printArray(unsorted);
        }
    }
}
