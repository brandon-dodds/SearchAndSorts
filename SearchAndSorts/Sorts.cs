﻿using System.Linq;
using System.Collections.Generic;

namespace SearchAndSorts
{
    class Sorts
    {
        public static int outerCounter = 0;
        public static int innerCounter = 0;
        /// <summary>
        /// This is a simple bubblesort. 
        /// Each value is compared to the value adjacent.
        /// If the value is greater to the one next to it, switch.
        /// </summary>
        /// <param name="x"> The array. </param>
        /// <param name="ascOrDesc"> To tell the prog if you want to asc or desc </param>
        public static int[] Bubblesort(int[] x, string ascOrDesc)
        {
            int[] sortedArray = x.ToArray();
            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                outerCounter++;
                for (int j = 0; j < sortedArray.Length - 1; j++)
                {
                    innerCounter++;
                    int temp;
                    if (ascOrDesc == "asc" ? sortedArray[j] > sortedArray[j + 1] : sortedArray[j] < sortedArray[j + 1])
                    {
                        temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }
            return sortedArray;
        }
        /// <summary>
        /// This does a simple insertion sort. It gets the value at index x[i] as an insertionValue
        /// It then checks if the value to the left of it is greater than the value, if it is,
        /// it moves the value up one index until the value can be inserted.
        /// </summary>
        /// <param name="x"> The array to be passed.</param>
        /// <param name="ascOrDesc"> If the user wants ascending or descending order.</param>
        public static int[] InsertionSort(int[] x, string ascOrDesc)
        {
            int[] sortedArray = x.ToArray();

            for (int i = 1; i < sortedArray.Length; i++)
            {
                outerCounter++;
                int insertionValue = sortedArray[i];
                int j = i;
                while (ascOrDesc == "asc" ? j >= 1 && sortedArray[j - 1] > insertionValue : j >= 1 && sortedArray[j - 1] < insertionValue)
                {
                    innerCounter++;
                    sortedArray[j] = sortedArray[j - 1];
                    j--;
                }
                sortedArray[j] = insertionValue;
            }
            return sortedArray;
        }
        /// <summary>
        /// Splits the array into two different arrays, left and right. until it can no longer be split.
        /// The smaller arrays are then sorted in the Merge function.
        /// </summary>
        /// <param name="x">The array to be sorted</param>
        /// <param name="ascOrDesc">Which way you want to asc or desc.</param>
        /// <returns> Returns a sorted array</returns>
        public static int[] MergeSort(int[] x, string ascOrDesc)
        {
            if (x.Length <= 1)
                return x;
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
                    leftSide[i] = x[i];
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
            outerCounter++;
            while (indexLeft < leftSide.Length || indexRight < rightSide.Length)
            {
                innerCounter++;
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
        /// <summary>
        /// The nodes needed for the tree.
        /// </summary>
        /// <typeparam name="T"> The type for the nodes.</typeparam>
        public class Node<T>
        {
            public Node<T> Left, Right, parentNode;
            public T Value;
            public Node(T x)
            {
                Value = x;
            }
        }
        /// <summary>
        /// This prints the tree.
        /// </summary>
        /// <param name="x"> The array passed.</param>
        /// <param name="ascOrDesc"> If you want to sort in ascending or descending order. </param>
        /// <returns> It returns the parent node. </returns>
        public static int[] PrintTree(int[] x, string ascOrDesc)
        {
            Node<int> y = MakeTree(x);
            List<int> sortedList = new List<int>();
            BinarySort(y, sortedList, ascOrDesc);
            return sortedList.ToArray();
        }
        /// <summary>
        /// This makes the binary tree from an array.
        /// </summary>
        /// <param name="x"> takes in an array as parameter.</param>
        /// <returns> Returns a Node of type int that is the root node.</returns>
        private static Node<int> MakeTree(int[] x)
        {
            Node<int> firstNode = new Node<int>(x[0]);
            Node<int> currentNode;
            int start = 1;
            outerCounter++;
            while (start < x.Length)
            {
                currentNode = firstNode;
                bool inserted = false;
                while (inserted == false)
                {
                    innerCounter++;
                    if (x[start] > currentNode.Value && currentNode.Right == null)
                    {
                        currentNode.Right = new Node<int>(x[start])
                        {
                            parentNode = currentNode
                        };
                        inserted = true;
                        start++;
                    }
                    else if (x[start] > currentNode.Value && inserted == false)
                    {
                        currentNode = currentNode.Right;
                    }
                    else if (x[start] <= currentNode.Value && currentNode.Left == null)
                    {
                        currentNode.Left = new Node<int>(x[start])
                        {
                            parentNode = currentNode
                        };
                        inserted = true;
                        start++;
                    }
                    else
                        currentNode = currentNode.Left;
                }
            }
            return firstNode;
        }
        /// <summary>
        /// This does the sort of the binary tree.
        /// </summary>
        /// <param name="startNode"> The parent node.</param>
        /// <param name="listToAdd"> The list to add the sorted array to.</param>
        /// <param name="ascOrDesc"> Ascending or descending. </param>
        private static void BinarySort(Node<int> startNode, List<int> listToAdd, string ascOrDesc)
        {
            if (ascOrDesc == "asc")
            {
                if (startNode.Left != null)
                    BinarySort(startNode.Left, listToAdd, ascOrDesc);
                listToAdd.Add(startNode.Value);
                if (startNode.Right != null)
                    BinarySort(startNode.Right, listToAdd, ascOrDesc);
            }
            else
            {
                if (startNode.Right != null)
                    BinarySort(startNode.Right, listToAdd, ascOrDesc);
                listToAdd.Add(startNode.Value);
                if (startNode.Left != null)
                    BinarySort(startNode.Left, listToAdd, ascOrDesc);
            }
        }
    }
}
