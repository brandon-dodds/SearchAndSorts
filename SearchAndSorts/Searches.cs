using System;

namespace SearchAndSorts
{
    class Searches
    {
        public static void LinearSearch(int[] array, int key)
        {
            int closestInt = default;
            int lastClosestDiff = int.MaxValue;
            bool valueFound = false;
            for(int i = 0; i < array.Length; i++)
            {
                int diff = array[i] - key;
                if (Math.Abs(diff) < lastClosestDiff)
                {
                    lastClosestDiff = Math.Abs(diff);
                    closestInt = array[i];
                }
                if(array[i] == key)
                { 
                    Console.WriteLine($"{key} found at position {i}");
                    valueFound = true;
                }
            }
            if (!valueFound)
            {
                Console.WriteLine($"The closest value is {closestInt} with a difference of {lastClosestDiff}");
            }
        }
        public static void BinarySearch(int[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;
            bool found = false;
            while (high > low)
            {
                int midpoint = (low + high) / 2;
                if(array[midpoint] == key)
                {
                    int tempMidpoint = midpoint;
                    bool leftSideFound = false;
                    bool rightSideFound = false;
                    found = true;
                    Console.WriteLine($"{key} found at position {midpoint}");
                    while(leftSideFound == false)
                    {
                        if(tempMidpoint == 0)
                            break;
                        else if (array[tempMidpoint - 1] == key)
                        {
                            Console.WriteLine($"{key} found at position {tempMidpoint - 1}");
                            tempMidpoint--;
                        }
                        else
                            leftSideFound = true;
                    }
                    tempMidpoint = midpoint;
                    while (rightSideFound == false)
                    {
                        if(tempMidpoint == array.Length - 1)
                            break;
                        else if (array[tempMidpoint + 1] == key)
                        {
                            Console.WriteLine($"{key} found at position {tempMidpoint + 1}");
                            tempMidpoint++;
                        }
                        else
                            rightSideFound = true;
                    }
                    break;
                }
                else if (array[midpoint] > key)
                    high = midpoint - 1;
                else
                    low = midpoint + 1;
            }
            if (found == false)
            {
                Console.WriteLine("The value you wanted to search for was not found.");
                Console.WriteLine($"The closest value is at {high} with a value of {array[high]}");
            }
        }
    }
}
