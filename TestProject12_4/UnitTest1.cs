using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using MyCollection_HashTable;
using ClassLibrary1;
using Laba10;
namespace TestProject12_4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_AddPoint_IncreasesCount()
        {
            var collection = new MyCollection<ControlElement>();
            var item = new ControlElement();
            item.IRandomInit();

            collection.AddPoint(item);

            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void Test_RemoveData_DecreasesCount()
        {
            var collection = new MyCollection<ControlElement>();
            var item = new ControlElement();
            item.IRandomInit();

            collection.AddPoint(item);
            bool removed = collection.RemoveData(item);

            Assert.IsTrue(removed);
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void Test_ConstructorWithLength_CreatesCollectionWithInitializedItems()
        {
            int length = 5;
            var collection = new MyCollection<ControlElement>(length);

            Assert.AreEqual(length, collection.Count);

            foreach (var item in collection)
            {
                Assert.IsNotNull(item);
                Assert.IsInstanceOfType(item, typeof(ControlElement));
                
            }
        }

        

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_CopyTo_NullArray_ThrowsException()
        {
            var collection = new MyCollection<ControlElement>();
            collection.CopyTo(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CopyTo_InvalidIndex_ThrowsException()
        {
            var collection = new MyCollection<ControlElement>();
            var array = new ControlElement[2];
            collection.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_CopyTo_IndexGreaterThanArrayLength_ThrowsException()
        {
            var collection = new MyCollection<ControlElement>();
            var array = new ControlElement[2];
            collection.CopyTo(array, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CopyTo_InsufficientSpaceInArray_ThrowsException()
        {
            var collection = new MyCollection<ControlElement>();
            var item = new ControlElement();
            item.IRandomInit();

            collection.AddPoint(item);
            var array = new ControlElement[0];

            collection.CopyTo(array, 0);
        }

        

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_CopyConstructor_NullArgument_ThrowsException()
        {
            
            MyCollection<ControlElement> nullCollection = null;
            var copy = new MyCollection<ControlElement>(nullCollection);
        }

        [TestMethod]
        public void Test_CopyConstructor_EmptyCollection_CreatesEmptyCollection()
        {
            var original = new MyCollection<ControlElement>();

            var copy = new MyCollection<ControlElement>(original);

            Assert.AreEqual(0, original.Count);
            Assert.AreEqual(0, copy.Count);
        }

        [TestMethod]
        public void Test_Contains_ItemExists_ReturnsTrue()
        {
            var collection = new MyCollection<ControlElement>();
            var item = new ControlElement();
            item.IRandomInit();

            collection.AddPoint(item);

            bool contains = collection.Contains(item);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void Test_Contains_ItemDoesNotExist_ReturnsFalse()
        {
            var collection = new MyCollection<ControlElement>();
            var item = new ControlElement();
            item.IRandomInit();

            bool contains = collection.Contains(item);

            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Test_Contains_ItemWithSameValue_ReturnsTrue()
        {
            var collection = new MyCollection<ControlElement>();
            var item1 = new ControlElement ();
            var item2 = new ControlElement ();

            collection.AddPoint(item1);

            bool contains = collection.Contains(item2);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void Test_Contains_EmptyCollection_ReturnsFalse()
        {
            var collection = new MyCollection<ControlElement>();
            var item = new ControlElement();
            item.IRandomInit();

            bool contains = collection.Contains(item);

            Assert.IsFalse(contains);
        }
    }
}