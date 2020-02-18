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
            int[] array = { 2, 1, 6, 4, 3, 2 };
            Sorts.split(array);
        }
    }
}
