using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAlgorithms.Tech;
using NUnit.Framework;

namespace ConsoleAlgorithms.Test
{
    [TestFixture]
    internal class CalculateStringTests
    {
        [TestCase("12+", 3)]
        [TestCase("12+*", -1)]
        [TestCase("11++11", -1)]
        [TestCase("111++11++", 5)]
        [TestCase("123**", 6)]
        [TestCase("123***", -1)]
        [TestCase("1*23", -1)]
        [TestCase("1234", 4)]
        [TestCase("1234****", -1)]
        [TestCase("+", -1)]
        [TestCase("+", -1)]
        [TestCase("10+", 1)]
        [TestCase("01+", 1)]
        [TestCase("13+62*7+*", 76)]
        public void CalculateStringTest(string str, int expected)
        {
            var calc = new Calculation();
            var result = calc.Calculate(str);
            Assert.AreEqual(expected, result);
        }
    }
}