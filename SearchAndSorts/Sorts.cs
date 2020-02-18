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
                    //Starting at the bottom value, if the value above is is larger. Swap them.
                    int temp;
                    if(x[j] > x[j + 1])
                    {
                        /* This assigns the temporary to the first value,
                         * it then switches the value with the value above
                         * and then the value above to the temp value */

                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] x)
        {
            for (int i = 1; i < x.Length; i++)
            {
                /* Starting at the x[1] value as the "insertion value" with "index" being the index
                 * to the left of the value.
                 * While the index is greater than 0 and the value is greater than the insertion value.
                 * Move the value to the left of itself. */
                int insertionValue = x[i];
                int j = i - 1;
                while (j >= 0 && x[j] > insertionValue)
                {
                    x[j + 1] = x[j];
                    j--;
                }
                x[j + 1] = insertionValue;
            }
        }
    }
}
