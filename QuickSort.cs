using System;

namespace SortingAlgorithms
{
    public static class QuickSort
    {
        private static Random r { get; set; }

        public static int[] Sort(int[] inputArray)
        {
            r = new Random();
            int[] newArray = new int[inputArray.Length];
            inputArray.CopyTo(newArray, 0);
            Partition(newArray, 0, inputArray.Length - 1);
            return newArray;
        }

        private static void Partition(int[] input, int startIndex, int endIndex)
        {
            if (endIndex - startIndex < 1) return;

            Swap(input, startIndex, r.Next(startIndex, endIndex + 1));

            int lowIndex = startIndex + 1;
            int highIndex = endIndex;
            int startValue = input[startIndex];

            while (highIndex - lowIndex > 0)
            {
                bool lowValueSmaller = input[lowIndex] < startValue;
                bool highValueBigger = input[highIndex] > startValue;

                if (lowValueSmaller) lowIndex++;
                if (highValueBigger) highIndex--;
                if (lowValueSmaller || highValueBigger) continue;

                Swap(input, lowIndex, highIndex);
                lowIndex++;
                highIndex--;

            }
            if (!(input[startIndex] > input[highIndex])) highIndex--;
            if (input[startIndex] > input[highIndex]) Swap(input, startIndex, highIndex);
            Partition(input, startIndex, highIndex - 1);
            Partition(input, highIndex + 1, endIndex);
        }

        private static void Swap(int[] input, int lowIndex, int highIndex)
        {
            int tempValue = input[lowIndex];
            input[lowIndex] = input[highIndex];
            input[highIndex] = tempValue;
        }
    }
}