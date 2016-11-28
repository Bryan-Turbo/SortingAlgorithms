using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms {
    public static class MergeSort {
        private static T[] MergeLists<T>(T[] firstHalf, T[] secondHalf, Func<T, T, bool> sortCondition) {
            T[] list = new T[firstHalf.Length + secondHalf.Length];

            int firstHalfIndex = 0;
            int secondHalfIndex = 0;

            for (int i = 0; i < firstHalf.Length + secondHalf.Length; i++) {
                if (firstHalfIndex < firstHalf.Length && secondHalfIndex < secondHalf.Length) {
                    if (sortCondition(firstHalf[firstHalfIndex], secondHalf[secondHalfIndex])) {
                        list[i] = firstHalf[firstHalfIndex];
                        firstHalfIndex++;
                    } else {
                        list[i] = secondHalf[secondHalfIndex];
                        secondHalfIndex++;
                    }
                } else {
                    if (firstHalfIndex >= firstHalf.Length) {
                        list[i] = secondHalf[secondHalfIndex];
                        secondHalfIndex++;
                    } else if (secondHalfIndex >= secondHalf.Length) {
                        list[i] = firstHalf[firstHalfIndex];
                        firstHalfIndex++;
                    }
                }
            }
            return list;
        }

        public static T[] Sort<T>(T[] elementList, Func<T, T, bool> sortCondition) {
            if (elementList.Length <= 1)
                return elementList;

            int length = elementList.Length;
            int middle = length / 2;

            T[] firstarray = elementList.GetElementsFrom(0, middle);
            T[] secondArray = elementList.GetElementsFrom(middle, length);

            return MergeLists(Sort(firstarray, sortCondition), Sort(secondArray, sortCondition), sortCondition);
        }

        private static T[] GetElementsFrom<T>(this T[] elementList, int lower, int upper) {
            T[] list = new T[upper - lower];

            for (int i = lower; i < upper; i++)
                list[i - lower] = elementList[i];

            return list;
        }
    }
}
