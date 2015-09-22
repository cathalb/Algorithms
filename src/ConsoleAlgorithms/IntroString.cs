using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    internal static class IntroString
    {
        public static int? SearchValue { get; set; }

        public static int? NumberOfElements { get; set; }

        private const int LowerBoundArray = 1;
        private const int UpperBoundArray = 1000;
        private const int LowerBoundValue = -10000;
        private const int UpperBoundValue = 10000;

        public static void GetInputFromConsole()
        {
            SearchValue = GetParsedValue(Console.ReadLine(), LowerBoundValue, UpperBoundValue);
            if (!SearchValue.HasValue) return;

            NumberOfElements = GetParsedValue(Console.ReadLine(), LowerBoundArray, UpperBoundArray);
            if (!NumberOfElements.HasValue) return;

            var elements = GetElements(Console.ReadLine(), NumberOfElements.Value);
            if (elements == null) return;

            var postion = GetPositionOfValue(elements, SearchValue.Value);
            if (postion.HasValue)
            {
                Console.WriteLine(elements.ToList().IndexOf(SearchValue.Value));
            }
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
            if (numArray.Count() != numberExpectedElements) return null;

            for (var i = 0; i < numArray.Count(); i++)
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

        private static int? GetPositionOfValue(int[] elements, int value)
        {
            if (elements.Count(x => x == value) != 1) return null;
            return elements.ToList().IndexOf(value);
        }
    }
}