using System;
using System.IO;

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
            for (int amount = 0; amount < 2500; amount++)
            {
                Sorts.mergesortcounter = 0;
                int[] array = new int[amount + 1];
                Random random = new Random();
                for (int i = 0; i <= amount; i++)
                {
                    array[i] = random.Next(0, 100);
                }
                int[] sortedArray = Sorts.PrintTree(array, "asc");
                var writer = File.AppendText("./test.csv");
                writer.WriteLine($"{sortedArray.Length - 1},{Sorts.mergesortcounter}");
                writer.Close();
            }
            
        }
    }
}
