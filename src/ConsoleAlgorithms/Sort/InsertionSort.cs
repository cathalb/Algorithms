using System;
using System.Diagnostics;

namespace ConsoleAlgorithms.Sort
{
    public static class InsertionSort
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

        private static void StartSort(int[] elements)
        {
            var insertValue = elements[elements.Length - 1];

            for (var i = elements.Length - 2; i >= 0; i--)
            {
                var test = (elements[i]);
                if (elements[i] > insertValue && i != 0)
                {
                    elements[i + 1] = elements[i];
                    PrintArray(elements);
                }
                else if (i == 0)
                {
                    elements[i] = insertValue;
                }
                else
                {
                    elements[i] = insertValue;
                    break;
                }
            }
            PrintArray(elements);
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