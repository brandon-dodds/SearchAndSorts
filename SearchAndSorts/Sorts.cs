using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSorts
{
    class Sorts
    {
        public static void Bubblesort(int[] x)
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

        public static void InsertionSort(int[] x)
        {
            int n = x.Length;
            for (int i = 1; i < n; i++)
            {

                int insertionValue = x[i];
                int j = i - 1;
                while (j >= 0 && x[j] > insertionValue)
                {
                    x[j + 1] = x[j];
                    j = j - 1;
                }
                x[j + 1] = insertionValue;
            }
        }
    }
}
