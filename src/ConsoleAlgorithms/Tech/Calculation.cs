using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace ConsoleAlgorithms.Tech
{
    internal class Calculation
    {
        private Stack<int> _numberStack;

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
                else if (t == '+' || t == '*')
                {
                    var result = RunOperationOnStack(t);
                    if (result == -1) return result;
                }
            }
            return _numberStack.Pop();
        }

        private int RunOperationOnStack(char operation)
        {
            if (_numberStack.Count < 2) return -1;

            var firstNumber = _numberStack.Pop();
            var secondNumber = _numberStack.Pop();

            if (operation == '+')
            {
                _numberStack.Push(firstNumber + secondNumber);
            }
            if (operation == '*')
            {
                _numberStack.Push(firstNumber * secondNumber);
            }

            return _numberStack.Peek();
        }
    }
}