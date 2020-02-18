using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSorts
{
    class Sorts
    {
        public static void Bubblesort(int[] x, string ascOrDesc)
        {
            if (ascOrDesc == "asc")
            {
                for (int i = 0; i < x.Length - 1; i++)
                {
                    for (int j = 0; j < x.Length - 1; j++)
                    {
                        //Starting at the bottom value, if the value above is is larger. Swap them.
                        int temp;
                        if (x[j] > x[j + 1])
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
            else
            {
                for (int i = 0; i < x.Length - 1; i++)
                {
                    for (int j = 0; j < x.Length - 1; j++)
                    {
                        //Starting at the bottom value, if the value above is is larger. Swap them.
                        int temp;
                        if (x[j] < x[j + 1])
                        {
                            /* This assigns the temporary to the first value,
                             * it then switches the value with the value above
                             * and then the value above to the temp value */

                            temp = x[j + 1];
                            x[j + 1] = x[j];
                            x[j] = temp;
                        }
                    }
                }
            }
        }

        public static void InsertionSort(int[] x, string ascOrDesc)
        {
            if(ascOrDesc == "asc")
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
            else
            {
                for (int i = 1; i < x.Length; i++)
                {
                    /* Starting at the x[1] value as the "insertion value" with "index" being the index
                     * to the left of the value.
                     * While the index is greater than 0 and the value is greater than the insertion value.
                     * Move the value to the left of itself. */
                    int insertionValue = x[i];
                    int j = i - 1;
                    while (j >= 0 && x[j] < insertionValue)
                    {
                        x[j + 1] = x[j];
                        j--;
                    }
                    x[j + 1] = insertionValue;
                }
            }
        }
        public static int[] mergeSort(int[] x)
        {
            if ( x.Length <= 1)
            {
                return x;
            }
            else
            {
                int midpoint = x.Length / 2;
                int[] leftSide = new int[midpoint];
                int[] rightSide;
                if (x.Length % 2 == 0)
                    rightSide = new int[midpoint];
                else
                    rightSide = new int[midpoint + 1];
                for (int i = 0; i < midpoint; i++)
                {
                    leftSide[i] = x[i];
                }
                int y = 0;
                for(int i = midpoint; i < x.Length; i++)
                {
                    rightSide[y] = x[i];
                    y++;
                }
                Program.printArray(leftSide);
                Program.printArray(rightSide);
                leftSide = mergeSort(leftSide);
                rightSide = mergeSort(rightSide);
                int[] result = merge(leftSide, rightSide);
                return result;
            }
        }

        public static int[] merge(int[] leftSide, int[] rightSide)
        {
            int resultLength = leftSide.Length + rightSide.Length;
            int[] resultArray = new int[resultLength];
            int indexLeft = 0;
            int indexRight = 0;
            int indexResult = 0;
            while (indexLeft < leftSide.Length || indexRight < rightSide.Length)
            {
                if (indexLeft < leftSide.Length && indexRight < rightSide.Length)
                {
                    if (leftSide[indexLeft] <= rightSide[indexRight])
                    {
                        resultArray[indexResult] = leftSide[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        resultArray[indexResult] = rightSide[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < leftSide.Length)
                {
                    resultArray[indexResult] = leftSide[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < rightSide.Length)
                {
                    resultArray[indexResult] = rightSide[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return resultArray;
        }
    }
}
