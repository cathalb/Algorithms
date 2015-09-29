using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAlgorithms.Tech
{
    internal class ZipCreate
    {
        public int CreateZip(int a, int b)
        {
            var aAsStack = ConvertIntToStack(a);
            var bAsStack = ConvertIntToStack(b);

            var result = 0;
            do
            {
                if (aAsStack.Any())
                {
                    result = CalculateNewValue(result, aAsStack.Pop());
                }
                if (bAsStack.Any() && result != -1)
                {
                    result = CalculateNewValue(result, bAsStack.Pop());
                }
            } while (result != -1 && (aAsStack.Any() || bAsStack.Any()));

            return result;
        }

        private static int CalculateNewValue(int currentValue, int poppedValue)
        {
            if (currentValue * 10 + poppedValue <= 100000000)
            {
                return currentValue * 10 + poppedValue;
            }
            return -1;
        }

        private static Stack<int> ConvertIntToStack(int a)
        {
            var aStack = new Stack<int>();
            if (a == 0)
            {
                aStack.Push(a);
                return aStack;
            }

            for (var i = a; i > 0; i = i / 10)
            {
                aStack.Push(i % 10);
            }

            return aStack;
        }
    }
}