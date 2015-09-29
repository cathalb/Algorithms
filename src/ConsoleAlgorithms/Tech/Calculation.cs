using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace ConsoleAlgorithms.Tech
{
    internal class Calculation
    {
        private Stack<int> _numberStack;
        private const char MultiplyOperator = '*';
        private const short ErrorValue = -1;
        private const char SumOperator = '+';

        public int Calculate(string toCalc)
        {
            _numberStack = new Stack<int>();
            foreach (char t in toCalc)
            {
                int number;
                if (int.TryParse(t.ToString(), out number))
                {
                    _numberStack.Push(number);
                }
                else if (t == SumOperator || t == MultiplyOperator)
                {
                    var result = RunOperationOnStack(t);
                    if (result == -1) return result;
                }
            }
            return _numberStack.Pop();
        }

        private int RunOperationOnStack(char operation)
        {
            if (_numberStack.Count < 2) return ErrorValue;

            var firstNumber = _numberStack.Pop();
            var secondNumber = _numberStack.Pop();

            if (operation == SumOperator)
            {
                _numberStack.Push(firstNumber + secondNumber);
            }
            if (operation == MultiplyOperator)
            {
                _numberStack.Push(firstNumber * secondNumber);
            }

            return _numberStack.Peek();
        }
    }
}