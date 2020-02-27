using DataStruct.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDataStruct
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void AddTest()
        {
            int[] testArray = { 5, 4, 2, 8, 7, 10 };
            BinaryTree binaryTree = new BinaryTree();

            for (int i = 0; i < testArray.Length; i++)
            {
                binaryTree.Add(testArray[i]);
            }

            Assert.AreEqual(testArray.Length, binaryTree.Count);

        }

        [TestMethod]
        public void ContainsTest()
        {
            int[] testArray = { 5, 4, 2, 8, 7, 10 };
            BinaryTree binaryTree = new BinaryTree();

            for (int i = 0; i < testArray.Length; i++)
            {
                binaryTree.Add(testArray[i]);
            }

            for (int i = 0; i < testArray.Length; i++)
            {
                Assert.IsTrue(binaryTree.Contains(testArray[i]));
            }

            Assert.IsFalse(binaryTree.Contains(1000));
            Assert.IsFalse(binaryTree.Contains(-80));
        }

        [TestMethod]
        public void ToArrayTest()
        {
            int[] testArray = { 5, 4, 2, 8, 7, 10 };
            BinaryTree binaryTree = new BinaryTree();

            for (int i = 0; i < testArray.Length; i++)
            {
                binaryTree.Add(testArray[i]);
            }

            object[] expected = { 2, 4, 5, 7, 8, 10 };
            var result = binaryTree.ToArray();

            Assert.AreEqual(expected.Length, result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
