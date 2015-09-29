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
    internal class ZipCreateTests
    {
        [TestCase(12, 123, 11223)]
        [TestCase(56233, 123, 51622333)]
        [TestCase(56233, 123456, -1)]
        [TestCase(1234, 0, 10234)]
        [TestCase(1000, 0, 10000)]

        public void TestZipCreate(int a, int b, int expectedResult)
        {
            var zip = new ZipCreate();
            var result = zip.CreateZip(a, b);

            Assert.AreEqual(expectedResult, result);
        }
    }
}