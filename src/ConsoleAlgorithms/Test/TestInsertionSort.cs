using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAlgorithms.Sort;
using NUnit.Framework;

namespace ConsoleAlgorithms.Test
{
    [TestFixture]
    public class TestInsertionSort
    {
        [TestCase(new[] { 2, 1, 3, 1, 2 }, 4)]
        public void TestNumberOfMovements(int[] arr, int expected)
        {
            var result = InsertionSort2.StartSort(arr);
            Assert.AreEqual(expected, result);
        }
    }
}