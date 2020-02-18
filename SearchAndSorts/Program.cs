using System;
using System.Threading;
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
            int[] array = { 2, 1, 4, 3 };
            Sorts.InsertionSort(array);
            Program.printArray(array);
            Console.ReadKey();
        }
    }
}
