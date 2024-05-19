using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Laba10;
using Laba12_3;
using System.Text;

namespace Laba12_3.Tests
{
    //public class CustomData : IInit, IComparable
    //{
    //    private static Random rand = new Random();
    //    public int Value { get; set; }

    //    public void IRandomInit()
    //    {
    //        Value = rand.Next(100);
    //    }

    //    public int CompareTo(object obj)
    //    {
    //        if (obj is CustomData other)
    //        {
    //            return Value.CompareTo(other.Value);
    //        }
    //        throw new ArgumentException("Object is not a CustomData");
    //    }

    //    public override string ToString()
    //    {
    //        return Value.ToString();
    //    }

    //    public void Init()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    [TestClass]
    public class MyTreeTests
    {
        [TestMethod]
        public void Constructor_CreatesBalancedTree()
        {
            // Arrange & Act
            var tree = new MyTree<ControlElement>(7);

            // Assert
            Assert.AreEqual(7, tree.Count);
        }

        [TestMethod]
        public void CountLeaves_ReturnsCorrectNumberOfLeaves()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(7);

            // Act
            var leafCount = tree.CountLeaves();

            // Assert
            Assert.AreEqual(4, leafCount); // В сбалансированном двоичном дереве с 7 узлами должно быть 4 листа
        }

        [TestMethod]
        public void AddPoint_AddsNewPointCorrectly()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(0);
            var newData = new ControlElement();
            newData.IRandomInit();

            // Act
            tree.AddPoint(newData);

            // Assert
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void Remove_RemovesElementCorrectly()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(1);
            var element = tree.root.Data;

            // Act
            var removed = tree.Remove(element);

            // Assert
            Assert.IsTrue(removed);
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Remove_ElementNotFound_ReturnsFalse()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(1);
            var nonExistentElement = new ControlElement ();

            // Act
            var removed = tree.Remove(nonExistentElement);

            // Assert
            Assert.IsFalse(removed);
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void TransformToFindTree_TransformsCorrectly()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(7);
            tree.TransformToFindTree();

            // Act & Assert
            Assert.AreEqual(7, tree.Count);
        }

        [TestMethod]
        public void ClearTree_ClearsTreeCorrectly()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(7);

            // Act
            tree.ClearTree();

            // Assert
            Assert.AreEqual(0, tree.Count);
            Assert.IsNull(tree.root);
        }

        [TestMethod]
        public void Remove_FromEmptyTree_ReturnsFalse()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(0);
            var dataToRemove = new ControlElement ();

            // Act
            var result = tree.Remove(dataToRemove);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_LeafNode_ReturnsTrue()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(1);
            var dataToRemove = tree.root.Data;

            // Act
            var result = tree.Remove(dataToRemove);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(tree.root);
            Assert.AreEqual(0, tree.Count);
        }

        

        [TestMethod]
        public void Remove_NodeWithTwoChildren_ReturnsTrue()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(3);
            var rootData = tree.root.Data;

            // Act
            var result = tree.Remove(rootData);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(2, tree.Count);

            var newRoot = tree.root.Data;
            Assert.AreNotEqual(rootData, newRoot);
        }

        [TestMethod]
        public void Remove_NonExistentNode_ReturnsFalse()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(3);
            var nonExistentData = new ControlElement ();

            // Act
            var result = tree.Remove(nonExistentData);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void PrintTreeByLevels_EmptyTree_PrintsEmptyMessage()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(0);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            tree.PrintTreeByLevels();
            var result = output.ToString().Trim();

            // Assert
            Assert.AreEqual("The tree is empty.", result);
        }

        [TestMethod]
        public void PrintTreeByLevels_SingleNodeTree_PrintsSingleNode()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(1);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            tree.PrintTreeByLevels();
            var result = output.ToString().Trim();

            // Assert
            Assert.IsTrue(result.Contains(tree.root.Data.ToString()));
        }

        [TestMethod]
        public void ShowTree_EmptyTree_PrintsEmptyMessage()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(0);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            tree.ShowTree();
            var result = output.ToString().Trim();

            // Assert
            Assert.AreEqual("The tree is empty.", result);
        }

        [TestMethod]
        public void ShowTree_SingleNodeTree_PrintsSingleNode()
        {
            // Arrange
            var tree = new MyTree<ControlElement>(1);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            tree.ShowTree();
            var result = output.ToString().Trim();

            // Assert
            Assert.IsTrue(result.Contains(tree.root.Data.ToString()));
        }

        

        [TestMethod]
        public void ToString_NullData_ReturnsEmptyString()
        {
            // Arrange
            var point = new Point<ControlElement>();

            // Act
            var result = point.ToString();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void CompareTo_OtherPointIsNull_ReturnsOne()
        {
            // Arrange
            var data = new ControlElement();
            var point = new Point<ControlElement>(data);

            // Act
            var result = point.CompareTo(null);

            // Assert
            Assert.AreEqual(1, result);
        }

        

        [TestMethod]
        public void CompareTo_OtherPointHasGreaterData_ReturnsNegative()
        {
            // Arrange
            var data1 = new ControlElement();
            var data2 = new ControlElement("Eshkere", 12.1, 11.1, 152);
            var point1 = new Point<ControlElement>(data1);
            var point2 = new Point<ControlElement>(data2);

            // Act
            var result = point1.CompareTo(point2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_OtherPointHasEqualData_ReturnsZero()
        {
            // Arrange
            var data1 = new ControlElement();
            var data2 = new ControlElement();
            var point1 = new Point<ControlElement>(data1);
            var point2 = new Point<ControlElement>(data2);

            // Act
            var result = point1.CompareTo(point2);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
