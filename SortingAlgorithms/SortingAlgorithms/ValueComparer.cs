using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms {
    public static class ValueComparer {
        public static bool AlphabeticalCompare(string value1, string value2) {
            char[] char1 = value1.ToLower().ToCharArray();
            char[] char2 = value2.ToLower().ToCharArray();

            int length;
            if (char1.Length < char2.Length)
                length = char1.Length;
            else
                length = char2.Length;

            for (int i = 0; i < length; i++) {
                if (char1[i] == char2[i])
                    continue;

                if (char1[i] < char2[i]) {
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
