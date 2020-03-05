using System;

namespace SearchAndSorts
{
    class Searches
    {
        public static int searchCounter = 0;
        /// <summary>
        /// Linear search of the array.
        /// </summary>
        /// <param name="array"> Passes in the array. </param>
        /// <param name="key"> Searches for the key.</param>
        public static void LinearSearch(int[] array, int key)
        {
            int lastClosestDiff = int.MaxValue;
            bool valueFound = false;
            for(int i = 0; i < array.Length; i++)
            {
                searchCounter++;
                int diff = array[i] - key;
                if (Math.Abs(diff) < lastClosestDiff)
                {
                    lastClosestDiff = Math.Abs(diff);
                }
                if(array[i] == key)
                { 
                    Console.WriteLine($"{key} found at position {i}");
                    valueFound = true;
                }
            }
            if (!valueFound)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == key + lastClosestDiff || array[i] == key - lastClosestDiff)
                    {
                        Console.WriteLine($"The closest value is {array[i]} with a difference of {lastClosestDiff} " +
                            $"at position {i}");
                    }
                }
            }
        }
        /// <summary>
        /// Binary search of the array.
        /// </summary>
        /// <param name="array"> Passes in an array. </param>
        /// <param name="key"> Searches for the key. </param>
        public static void BinarySearch(int[] array, int key)
        {
            int lastClosestDiff = int.MaxValue;
            int low = 0;
            int high = array.Length - 1;
            bool found = false;
            while (high >= low)
            {
                searchCounter++;
                int midpoint = (low + high) / 2;
                int diff = array[midpoint] - key;
                if (Math.Abs(diff) < lastClosestDiff)
                {
                    lastClosestDiff = Math.Abs(diff);
                }
                if (array[midpoint] == key)
                {
                    int tempMidpoint = midpoint;
                    bool leftSideFound = false;
                    bool rightSideFound = false;
                    found = true;
                    Console.WriteLine($"{key} found at position {midpoint}");
                    while (leftSideFound == false)
                    {
                        if (tempMidpoint == 0)
                        {
                            break;
                        }
                        else if (array[tempMidpoint - 1] == key)
                        {
                            Console.WriteLine($"{key} found at position {tempMidpoint - 1}");
                            tempMidpoint--;
                        }
                        else
                        {
                            leftSideFound = true;
                        }
                    }
                    tempMidpoint = midpoint;
                    while (rightSideFound == false)
                    {
                        if (tempMidpoint == array.Length - 1)
                        {
                            break;
                        }
                        else if (array[tempMidpoint + 1] == key)
                        {
                            Console.WriteLine($"{key} found at position {tempMidpoint + 1}");
                            tempMidpoint++;
                        }
                        else
                        {
                            rightSideFound = true;
                        }
                    }
                    break;
                }
                else if (array[midpoint] > key)
                {
                    high = midpoint - 1;
                }
                else
                {
                    low = midpoint + 1;
                }
            }
            if (!found)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == key + lastClosestDiff || array[i] == key - lastClosestDiff)
                    {
                        Console.WriteLine($"The closest value is {array[i]} with a difference of {lastClosestDiff} " +
                            $"at position {i}");
                    }
                }
            }
        }
    }
}
