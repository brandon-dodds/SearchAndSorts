using System;
using System.IO;
namespace SearchAndSorts
{
    class Program
    {
        /// <summary>
        /// This is a function that allows two arrays to be passed in, and for them to be combined.
        /// </summary>
        /// <param name="array1"> The first array to merge. </param>
        /// <param name="array2"> The second array to merge. </param>
        /// <returns> Returns the merged array. </returns>
        public static int[] MergeArray(int[] array1, int[] array2)
        {
            int[] mergedArray = new int[2 * array1.Length];
            for(int i = 0; i < array1.Length; i++)
            {
                mergedArray[i] = array1[i];
                mergedArray[i + array1.Length] = array2[i];
            }
            return mergedArray;
        }
        /// <summary>
        /// Array analysis for the array passed in. 
        /// </summary>
        /// <param name="array"> The array to analyse. </param>
        /// <param name="sortChoice"> The sort chosed. </param>
        public static void ArrayAnalysis(int[] array, string sortChoice)
        {
            Console.Clear();
            int[] sortedArrayAsc;
            int[] sortedArrayDesc;
            switch (sortChoice)
            {
                case "1":
                    sortedArrayAsc = Sorts.Bubblesort(array, "asc");
                    Sorts.innerCounter = 0;
                    Sorts.outerCounter = 0;
                    sortedArrayDesc = Sorts.Bubblesort(array, "desc");
                    break;
                case "2":
                    sortedArrayAsc = Sorts.InsertionSort(array, "asc");
                    Sorts.innerCounter = 0;
                    Sorts.outerCounter = 0;
                    sortedArrayDesc = Sorts.InsertionSort(array, "desc");
                    break;
                case "3":
                    sortedArrayAsc = Sorts.MergeSort(array, "asc");
                    Sorts.innerCounter = 0;
                    Sorts.outerCounter = 0;
                    sortedArrayDesc = Sorts.MergeSort(array, "desc");
                    break;
                case "4":
                    sortedArrayAsc = Sorts.PrintTree(array, "asc");
                    Sorts.innerCounter = 0;
                    Sorts.outerCounter = 0;
                    sortedArrayDesc = Sorts.PrintTree(array, "desc");
                    break;
                default:
                    Console.WriteLine("Merge sort by default...");
                    sortedArrayAsc = Sorts.MergeSort(array, "asc");
                    sortedArrayDesc = Sorts.MergeSort(array, "desc");
                    break;
            }
            Console.WriteLine((array.Length == 2048) ? "Printing every 50th value ascending..." : "printing every 10th value ascending...");
            var intUp = array.Length == 2048 ? 50 : 10;
            for(int i = 0; i <= (10 * (array.Length / 10)); i+=intUp)
            {
                Console.WriteLine($"{i}. {sortedArrayAsc[i]}");
            }
            Console.WriteLine("Press a button to sort descending...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine((array.Length == 2048) ? "Printing every 50th value descending..." : "printing every 10th value descending...");
            for (int i = 0; i <= (10 * (array.Length / 10)); i += intUp)
            {
                Console.WriteLine($"{i}. {sortedArrayDesc[i]}");
            }
            Console.WriteLine("Press a button to continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Search for a value:");
            var userIntSearch = Console.ReadLine();
            Searches.BinarySearch(sortedArrayAsc, int.Parse(userIntSearch));
            Console.WriteLine($"{Sorts.outerCounter},{Sorts.innerCounter}");
            Console.ReadLine();
        }
        static void Main()
        {
            // Parsing the text files.
            var net1String = File.ReadAllLines("Net_1_256.txt");
            var net2String = File.ReadAllLines("Net_2_256.txt");
            var net3String = File.ReadAllLines("Net_3_256.txt");
            var net4String = File.ReadAllLines("Net_1_2048.txt");
            var net5String = File.ReadAllLines("Net_2_2048.txt");
            var net6String = File.ReadAllLines("Net_3_2048.txt");
            int[] net1int = new int[net1String.Length];
            int[] net2int = new int[net2String.Length];
            int[] net3int = new int[net3String.Length];
            int[] net4int = new int[net4String.Length];
            int[] net5int = new int[net5String.Length];
            int[] net6int = new int[net6String.Length];
            for (int i = 0; i < 256; i++)
            {
                net1int[i] = int.Parse(net1String[i]);
                net2int[i] = int.Parse(net2String[i]);
                net3int[i] = int.Parse(net3String[i]);
            }
            for (int i = 0; i < 2048; i++)
            {
                net4int[i] = int.Parse(net4String[i]);
                net5int[i] = int.Parse(net5String[i]);
                net6int[i] = int.Parse(net6String[i]);
            }
            // Start of the user input.
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select sort to use:" +
                    "\n1. BubbleSort." +
                    "\n2. InsertionSort" +
                    "\n3. MergeSort" +
                    "\n4. BinaryTreeSort");
                var userSortChoice = Console.ReadLine();
                Console.WriteLine("Select array to be analysed:" +
                    "\n1. Net_1_256.txt" +
                    "\n2. Net_2_256.txt" +
                    "\n3. Net_3_256.txt" +
                    "\n4. Net_1_2048.txt" +
                    "\n5. Net_2_2048.txt" +
                    "\n6. Net_3_2048.txt" + 
                    "\n7. Merge Net_1_256 and Net_3_256?" + 
                    "\n8. Merge Net_1_2048 and Net_3_2048?");
                var userArrayChoice = Console.ReadLine();
                //Switching in specific values.
                switch (userArrayChoice)
                {
                    case "1":
                        ArrayAnalysis(net1int, userSortChoice);
                        break;
                    case "2":
                        ArrayAnalysis(net2int, userSortChoice);
                        break;
                    case "3":
                        ArrayAnalysis(net3int, userSortChoice);
                        break;
                    case "4":
                        ArrayAnalysis(net4int, userSortChoice);
                        break;
                    case "5":
                        ArrayAnalysis(net5int, userSortChoice);
                        break;
                    case "6":
                        ArrayAnalysis(net6int, userSortChoice);
                        break;
                    case "7":
                        // Calling the MergeArray method.
                        int[] mergedArray = MergeArray(net1int, net3int);
                        ArrayAnalysis(mergedArray, userSortChoice);
                        break;
                    case "8":
                        // Calling the MergeArray
                        int[] mergedArray2 = MergeArray(net4int, net6int);
                        ArrayAnalysis(mergedArray2, userSortChoice);
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
