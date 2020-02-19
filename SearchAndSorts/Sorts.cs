using System;
using System.Diagnostics;

namespace SearchAndSorts
{
    class Sorts
    {
        /// <summary>
        /// This is a simple bubblesort. 
        /// Each value is compared to the value adjacent.
        /// If the value is greater to the one next to it, switch.
        /// </summary>
        /// <param name="x"> The array. </param>
        /// <param name="ascOrDesc"> To tell the prog if you want to asc or desc </param>
        public static void Bubblesort(int[] x, string ascOrDesc)
        {
            for (int i = 0; i < x.Length - 1; i++)
            {
                for (int j = 0; j < x.Length - 1; j++)
                {
                    int temp;
                    if (ascOrDesc == "asc" ? x[j] > x[j + 1] : x[j] < x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }
            }


        }
        /// <summary>
        /// This does a simple insertion sort. It gets the value at index x[i] as an insertionValue
        /// It then checks if the value to the left of it is greater than the value, if it is,
        /// it moves the value up one index until the value can be inserted.
        /// </summary>
        /// <param name="x"> The array to be passed.</param>
        /// <param name="ascOrDesc"> If the user wants ascending or descending order.</param>
        public static void InsertionSort(int[] x, string ascOrDesc)
        {
            for (int i = 1; i < x.Length; i++)
            {
                int insertionValue = x[i];
                int j = i;
                while (ascOrDesc == "asc" ? j >= 1 && x[j - 1] > insertionValue : j >= 1 && x[j - 1] < insertionValue)
                {
                    x[j] = x[j - 1];
                    j--;
                }
                x[j] = insertionValue;
            }
        }
        /// <summary>
        /// Splits the array into two different arrays, left and right. until it can no longer be split.
        /// The smaller arrays are then sorted in the Merge function.
        /// </summary>
        /// <param name="x">The array to be sorted</param>
        /// <param name="ascOrDesc">Which way you want to asc or desc.</param>
        /// <returns> Returns a so</returns>
        public static int[] MergeSort(int[] x, string ascOrDesc)
        {
            if (x.Length <= 1)
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
                for (int i = midpoint; i < x.Length; i++)
                {
                    rightSide[y] = x[i];
                    y++;
                }
                leftSide = MergeSort(leftSide, ascOrDesc);
                rightSide = MergeSort(rightSide, ascOrDesc);
                int[] result = Merge(leftSide, rightSide, ascOrDesc);
                return result;
            }
        }

        /// <summary>
        /// Takes the Left side and the right side array. Compares the two and sorts them accordingly.
        /// </summary>
        /// <param name="leftSide">The left side of the two arrays passed.</param>
        /// <param name="rightSide">The right side of the two arrays passed.</param>
        /// <param name="ascOrDesc">Whichever way you want to sort it.</param>
        /// <returns>A resultant, sorted array</returns>
        private static int[] Merge(int[] leftSide, int[] rightSide, string ascOrDesc)
        {
            int resultLength = leftSide.Length + rightSide.Length;
            int[] resultArray = new int[resultLength];
            int indexLeft = 0;
            int indexRight = 0;
            int indexResult = 0;
            while (indexLeft < leftSide.Length || indexRight < rightSide.Length)
            {
                // If the left and right indexes are still not at length, comparisons can be made between the two.
                if (indexLeft < leftSide.Length && indexRight < rightSide.Length)
                {
                    if (ascOrDesc == "asc" ? leftSide[indexLeft] <= rightSide[indexRight] : leftSide[indexLeft] >= rightSide[indexRight])
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
                // No comparison can be done here as the right or left length is too large, thus fill.
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
        private class Node<T>
        {
            public Node<T> Left, Right, parentNode;
            public T Value;
            public Node(T x)
            {
                Value = x;
            }
        }
        private static Node<int> MakeTree(int[] x)
        {
            Node<int> firstNode = new Node<int>(x[0]);
            Node<int> currentNode;
            int start = 1;
            while (start < x.Length)
            {
                currentNode = firstNode;
                bool inserted = false;
                while (inserted == false)
                {
                    if (x[start] > currentNode.Value && currentNode.Right == null)
                    {
                        currentNode.Right = new Node<int>(x[start]);
                        currentNode.Right.parentNode = currentNode;
                        inserted = true;
                        start++;
                    }
                    else if (x[start] > currentNode.Value && inserted == false)
                    {
                        currentNode = currentNode.Right;
                    }
                    else if (x[start] < currentNode.Value && currentNode.Left == null)
                    {
                        currentNode.Left = new Node<int>(x[start]);
                        currentNode.Left.parentNode = currentNode;
                        inserted = true;
                        start++;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
            }
            return firstNode;
        }

        public static void PrintTree(int[] x, string ascOrDesc)
        {
            Node<int> y = MakeTree(x);
            Node<int> currentNode = y;
            while(currentNode.Right != null || currentNode.Left != null)
            {
                while (currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }

                while (currentNode.parentNode != null)
                {
                    Console.WriteLine(currentNode.Value);
                    currentNode = currentNode.parentNode;
                }
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Right;
                if(currentNode != null)
                {
                    currentNode.parentNode = null;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
