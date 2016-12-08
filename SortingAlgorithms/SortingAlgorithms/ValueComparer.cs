using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms {
    public static class ValueComparer {
        public static bool AlphabeticalCompare(string value1, string value2) {
            value1 = value1.ToLower();
            value2 = value2.ToLower();

            int length;
            if (value1.Length < value2.Length)
                length = value1.Length;
            else
                length = value2.Length;

            for (int i = 0; i < length; i++) {
                if (value1[i] == value2[i])
                    continue;

                if (value1[i] < value2[i]) {
                    return true;
                }
                break;
            }
            return false;
        }

        public static bool LengthCompare(string value1, string value2) {
            return value1.Length < value2.Length;
        }

        public static bool ValueCompare(int value1, int value2) {
            return value1 < value2;
        }
    }
}
