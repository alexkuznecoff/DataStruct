using System;
using DataStruct.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDataStruct
{
    [TestClass]
    public class ListTest
    {
        [TestMethod]
        public void AddTest()
        {
            List list = new List();
            Assert.AreEqual(0, list.Count);

            list.Add(223);
            list.Add(45);
            list.Add(12);
            list.Add(75);
            list.Add(154);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(223, list[0]);

        }

        [TestMethod]
        public void Test_ToArray()
        {
            object[] expected = { 1, 2, 3, 4, 5 };
            List list = new List();

            for (int i = 0; i < expected.Length; i++)
            {
                list.Add(expected[i]);
            }

            var result = list.ToArray();

            Assert.AreEqual(5, list.Count);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
