using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAlgorithms.Sort;

namespace ConsoleApplication2
{
    internal class Program
    {
        private const int LowerBoundArray = 1;
        private const int UpperBoundArray = 10;
        private const int UpperPowerOf = 10;

        private static void Main(string[] args)
        {
            //var numElements = GetNumberOfElements(Console.ReadLine());
            //if (numElements.HasValue)
            //{
            //    var numbers = GetElements(Console.ReadLine(), numElements.Value);
            //    if (numbers != null)
            //    {
            //        Console.WriteLine(numbers.Sum(x => x));
            //    }
            //}

            //
            //IntroString.GetInputFromConsole();
            InsertionSort.PerformSort();

            Console.ReadKey();
        }

        private static IEnumerable<long> GetElements(string readLine, int numberExpectedElements)
        {
            var resultList = new List<long>();

            var numArray = readLine.Split(' ');
            if (numArray.Count() != numberExpectedElements) return resultList;

            foreach (var num in numArray)
            {
                var number = ValidateEnterNumber(num);
                if (number.HasValue)
                {
                    resultList.Add(number.Value);
                }
            }
            return resultList;
        }

        private static int? ValidateEnterNumber(string num)
        {
            int parsedNumber;
            if (!int.TryParse(num, out parsedNumber)) return null;
            if (parsedNumber >= 0 && parsedNumber <= Math.Pow(10, UpperPowerOf))
            {
                return parsedNumber;
            }
            throw new Exception("Invalid Number!");
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
    }
}