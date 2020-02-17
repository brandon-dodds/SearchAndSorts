using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSorts
{
    class Sorts
    {
        public static void bubblesort(int[] x)
        {
            for(int i = 0; i < x.Length - 1; i++)
            {
                for(int j = 0; j < x.Length - 1; j++)
                {
                    int temp;
                    if(x[j] > x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }
            }
        }

        public static void insertionSort(int[] x)
        {
            for(int i = 1; i < x.Length; i++)
            {
                int temp;
                int index = i;
                while(x[index] < x[index - 1] && index > 0)
                {
                    temp = x[index - 1];
                    x[index - 1] = x[index];
                    x[index] = temp;
                    index--;
                }
            }
        }
    }
}
