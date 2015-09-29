using System;
using System.Diagnostics;

namespace ConsoleAlgorithms.Sort
{
    public static class InsertionSort2
    {
        //public static int? SearchValue { get; set; }

        public static int? NumberOfElements { get; set; }

        private const int LowerBoundArray = 1;
        private const int UpperBoundArray = 1000;

        public static void PerformSort()
        {
            NumberOfElements = GetParsedValue(Console.ReadLine(), LowerBoundArray, UpperBoundArray);
            if (!NumberOfElements.HasValue) return;

            var elements = GetElements(Console.ReadLine(), NumberOfElements.Value);
            if (elements == null) return;

            StartSort(elements);
        }

        public static int StartSort(int[] ar)
        {
            var shiftCount = 0;

            for (var i = 1; i < ar.Length; i++)
            {
                for (var k = i; k > 0; k--)
                {
                    if (ar[k] < ar[k - 1])
                    {
                        var store = ar[k];
                        ar[k] = ar[k - 1];
                        ar[k - 1] = store;
                        shiftCount++;
                    }
                }
                PrintArray(ar);
            }
            Console.WriteLine(shiftCount);
            return shiftCount;
        }

        private static void PrintArray(int[] elements)
        {
            Console.WriteLine(string.Join(" ", elements));
            Debug.Print(string.Join(" ", elements));
        }

        private static int? GetParsedValue(string inputString, int lowerValue, int upperValue)
        {
            int numberElements;

            if (!Int32.TryParse(inputString, out numberElements)) return null;
            if (numberElements >= lowerValue && numberElements <= upperValue)
            {
                return numberElements;
            }
            return null;
        }

        private static int[] GetElements(string readLine, int numberExpectedElements)
        {
            var numberArray = new int[numberExpectedElements];

            var numArray = readLine.Split(' ');
            if (numArray.Length != numberExpectedElements) return null;

            for (var i = 0; i < numArray.Length; i++)
            {
                var number = ValidateEnteredNumber(numArray[i]);
                if (number.HasValue)
                {
                    numberArray[i] = number.Value;
                }
            }
            return numberArray;
        }

        private static int? ValidateEnteredNumber(string num)
        {
            int parsedNumber;
            if (!int.TryParse(num, out parsedNumber)) return null;
            if (parsedNumber >= -100 && parsedNumber <= 100)
            {
                return parsedNumber;
            }
            return null;
        }

        private static bool IsArrayItemsValid(int[] arr, int lowerB, int upperB)
        {
            foreach (var i in arr)
            {
                if (i < lowerB && i > upperB) return false;
            }
            return true;
        }
    }
}