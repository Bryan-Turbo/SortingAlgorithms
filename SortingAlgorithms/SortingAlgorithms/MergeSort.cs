using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms {
    public static class MergeSort {
        private static T[] MergeLists<T>(T[] firstHalf, T[] secondHalf, Func<T, T, bool> sortCondition) {
            int firstHalfLength = firstHalf.Length;
            int secondHalfLength = secondHalf.Length;

            T[] list = new T[firstHalfLength + secondHalfLength];

            int firstHalfIndex = 0;
            int secondHalfIndex = 0;
            int index = 0;
            
            for (; index < firstHalfLength + secondHalfLength && firstHalfIndex < firstHalfLength && secondHalfIndex < secondHalfLength; index++) {
                if (sortCondition(firstHalf[firstHalfIndex], secondHalf[secondHalfIndex])) {
                    list[index] = firstHalf[firstHalfIndex];
                    firstHalfIndex++;
                    continue;
                }
                list[index] = secondHalf[secondHalfIndex];
                secondHalfIndex++;
            }

            if (firstHalfIndex < firstHalfLength)
                return AddFromList(list, firstHalf, firstHalfLength, firstHalfIndex, index);
            return AddFromList(list, secondHalf, secondHalfLength, secondHalfIndex, index);
        }

        private static T[] AddFromList<T>(T[] list, T[] half, int halfLength, int halfIndex, int generalIndex) {
            for (int i = halfIndex; i < halfLength; i++) {
                list[generalIndex] = half[i];
                generalIndex++;
            }
            return list;
        }

        private static T[] Sorter<T>(T[] elementList, int lower, int upper, Func<T, T, bool> sortCondition) {
            if (upper - lower <= 1)
                return GetElementsFrom(elementList, lower, upper);

            int length = upper - lower;
            int middle = lower + length / 2;

            return MergeLists(Sorter(elementList, lower, middle, sortCondition), Sorter(elementList, middle, upper, sortCondition), sortCondition);
        }

        public static T[] Sort<T>(T[] elementList, Func<T, T, bool> sortCondition) {
            return Sorter(elementList, 0, elementList.Length, sortCondition);
        }

        private static T[] GetElementsFrom<T>(this T[] elementList, int lower, int upper) {
            T[] list = new T[upper - lower];

            for (int i = lower; i < upper; i++)
                list[i - lower] = elementList[i];

            return list;
        }
    }
}