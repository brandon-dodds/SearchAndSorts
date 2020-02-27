using System;
using System.IO;

namespace SearchAndSorts
{
    class Program
    {
        public static void ArrayAnalysis(int[] array)
        {
            Console.Clear();
            var sortedArrayAsc = Sorts.MergeSort(array, "asc");
            var sortedArrayDesc = Sorts.MergeSort(array, "desc");
            Console.WriteLine("Printing every 10th value ascending...");
            for(int i = 0; i <= 250; i+=10)
            {
                Console.WriteLine($"{i}. {sortedArrayAsc[i]}");
            }
            Console.WriteLine("Press a button to sort descending...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Printing every 10th value descending...");
            for (int i = 0; i <= 250; i += 10)
            {
                Console.WriteLine($"{i}. {sortedArrayDesc[i]}");
            }
            Console.WriteLine("Press a button to continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Search for a value:");
            var userIntSearch = Console.ReadLine();
            Searches.BinarySearch(sortedArrayAsc, int.Parse(userIntSearch));
            Console.ReadLine();
        }
        static void Main()
        {
            var net1String = File.ReadAllLines("Net_1_256.txt");
            var net2String = File.ReadAllLines("Net_2_256.txt");
            var net3String = File.ReadAllLines("Net_3_256.txt");
            int[] net1int = new int[net1String.Length];
            int[] net2int = new int[net2String.Length];
            int[] net3int = new int[net3String.Length];
            for (int i = 0; i < 256; i++)
            {
                net1int[i] = int.Parse(net1String[i]);
                net2int[i] = int.Parse(net2String[i]);
                net3int[i] = int.Parse(net3String[i]);
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select array to be analysed:" +
                    "\n1. Net_1_256.txt" +
                    "\n2. Net_2_256.txt" +
                    "\n3. Net_3_256.txt");
                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ArrayAnalysis(net1int);
                        break;
                    case "2":
                        ArrayAnalysis(net2int);
                        break;
                    case "3":
                        ArrayAnalysis(net3int);
                        break;
                    default:
                        Console.WriteLine("Please enter a correct value.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
