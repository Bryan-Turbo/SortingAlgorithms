using System;

namespace SortingAlgorithms
{
    public static class QuickSort
    {
        private static Random r { get; set; }

        public static T[] Sort<T>(T[] inputArray, Func<T, T, bool> compare)
        {
            r = new Random();
            T[] newArray = new T[inputArray.Length];
            inputArray.CopyTo(newArray, 0);
            Partition(newArray, 0, inputArray.Length - 1, compare);
            return newArray;
        }

        private static void Partition<T>(T[] input, int startIndex, int endIndex, Func<T, T, bool> compare)
        {
            if (endIndex - startIndex < 1) return;

            Swap(input, startIndex, r.Next(startIndex, endIndex + 1));

            int lowIndex = startIndex + 1;
            int highIndex = endIndex;
            T startValue = input[startIndex];

            while (highIndex - lowIndex > 0)
            {
                bool lowValueSmaller = compare(input[lowIndex], startValue);
                bool highValueBigger = compare(startValue, input[highIndex]);

                if (lowValueSmaller) lowIndex++;
                if (highValueBigger) highIndex--;
                if (lowValueSmaller || highValueBigger) continue;

                Swap(input, lowIndex, highIndex);
                lowIndex++;
                highIndex--;

            }
            if (!compare(input[highIndex], input[startIndex])) highIndex--;
            if (compare(input[highIndex], input[startIndex])) Swap(input, startIndex, highIndex);
            Partition(input, startIndex, highIndex - 1, compare);
            Partition(input, highIndex + 1, endIndex, compare);
        }

        private static void Swap<T>(T[] input, int lowIndex, int highIndex)
        {
            T tempValue = input[lowIndex];
            input[lowIndex] = input[highIndex];
            input[highIndex] = tempValue;
        }
    }
}