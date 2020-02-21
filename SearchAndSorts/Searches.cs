using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSorts
{
    class Searches
    {
        public static void LinearSearch(int[] array, int key)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == key)
                    Console.WriteLine($"{key} found at position {i}");
            }
        }
        public static void BinarySearch(int[] array, int key)
        {
            int low = 0;
            int high = array.Length;
            while (high > low)
            {
                int midpoint = (low + high) / 2;
                if(array[midpoint] == key)
                {
                    int tempMidpoint = midpoint;
                    bool leftSideFound = false;
                    bool rightSideFound = false;
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
                }
                else if (array[midpoint] > key)
                    high = midpoint - 1;
                else
                    low = midpoint;
            }
        }
    }
}
