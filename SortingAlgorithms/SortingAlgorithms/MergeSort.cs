using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms {
    public static class MergeSort {
        private static int[] MergeLists(int[] firstHalf, int[] secondHalf) {
            int[] list = new int[firstHalf.Length + secondHalf.Length];

            int firstHalfIndex = 0;
            int secondHalfIndex = 0;

            for (int i = 0; i < firstHalf.Length + secondHalf.Length; i++) {
                if (firstHalfIndex < firstHalf.Length && secondHalfIndex < secondHalf.Length) {
                    if (firstHalf[firstHalfIndex] < secondHalf[secondHalfIndex]) {
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

        public static int[] Sort(int[] elementList) {
            if (elementList.Length <= 1)
                return elementList;

            int length = elementList.Length;
            int middle = length / 2;

            int[] firstarray = elementList.GetElementsFrom(0, middle);
            int[] secondArray = elementList.GetElementsFrom(middle, length);

            return MergeLists(Sort(firstarray), Sort(secondArray));
        }

        private static int[] GetElementsFrom(this int[] elementList, int lower, int upper) {
            int[] list = new int[upper - lower];

            for (int i = lower; i < upper; i++)
                list[i - lower] = elementList[i];

            return list;
        }
    }
}
