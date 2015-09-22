using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    internal static class DiagonalDifference
    {
        private static int? _numberOfElements;

        private const int LowerBoundArray = 1;
        private const int UpperBoundArray = 100;

        public static void GetInputFromConsole()
        {
            var elementsMatrix = new List<int[]>();

            _numberOfElements = GetNumberOfElements(Console.ReadLine());
            if (!_numberOfElements.HasValue) return;

            for (var i = 0; i < _numberOfElements.Value; i++)
            {
                var elements = GetElements(Console.ReadLine(), _numberOfElements.Value);
                if (elements != null)
                {
                    elementsMatrix.Add(elements);
                }
            }
            if (elementsMatrix.Count != _numberOfElements) return;

            Console.WriteLine(CalculateDiagonals(elementsMatrix));
        }

        private static int CalculateDiagonals(IEnumerable<int[]> matrix)
        {
            var postion = 0;
            var sumLeft = 0;
            var sumRight = 0;

            var items = matrix as int[][] ?? matrix.ToArray();
            foreach (var item in items)
            {
                sumLeft += item[postion];
                postion++;
            }

            foreach (var item in items)
            {
                postion--;
                sumRight += item[postion];
            }

            return Math.Abs(sumLeft - sumRight);
        }

        private static int? GetNumberOfElements(string inputString)
        {
            var numberElements = 0;

            if (!Int32.TryParse(inputString, out numberElements)) return null;
            if (numberElements >= LowerBoundArray && numberElements <= UpperBoundArray)
            {
                return numberElements;
            }
            throw new Exception("Invalid Number of Elements!");
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
            throw new Exception("Invalid Number!");
        }
    }
}