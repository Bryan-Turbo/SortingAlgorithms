using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms {
    public static class InsertionSort {
        public static T[] Sort<T>(this T[] inputList, Func<T, T, bool> condition) {
            T buffer;
            for (int position = 1; position < inputList.Length; position++) {
                int sortingPosition = position;
                for (int i = sortingPosition - 1; i >= 0; i--) {
                    if (!condition(inputList[sortingPosition], inputList[i])) {
                        break;
                    }
                    buffer = inputList[i];
                    inputList[i] = inputList[sortingPosition];
                    inputList[sortingPosition] = buffer;
                    sortingPosition = i;
                }
            }

            return inputList;
        }
    }
}
