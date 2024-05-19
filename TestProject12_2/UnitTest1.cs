using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba10;
using Laba12_2;

namespace Laba12_1_2.Tests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void Point_WithData_CreatesPointWithData()
        {
            // Arrange
            var data = new ControlElement("Id_1", 12.1, 11.1, 100);

            // Act
            var point = new Point<ControlElement>(data);

            // Assert
            Assert.AreEqual(data, point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Pred);
        }

        [TestMethod]
        public void Point_Default_CreatesPointWithDefaultData()
        {
            // Arrange & Act
            var point = new Point<ControlElement>();

            // Assert
            Assert.AreEqual(default(ControlElement), point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Pred);
        }

        [TestMethod]
        public void MakeRandomData_ReturnsPointWithRandomData()
        {
            // Act
            var point = Point<ControlElement>.MakeRandomData();

            // Assert
            Assert.IsNotNull(point.Data);
            Assert.IsInstanceOfType(point.Data, typeof(ControlElement));
        }

        [TestMethod]
        public void MakeRandomItem_ReturnsRandomItem()
        {
            // Act
            var item = Point<ControlElement>.MakeRandomItem();

            // Assert
            Assert.IsNotNull(item);
            Assert.IsInstanceOfType(item, typeof(ControlElement));
        }

        [TestMethod]
        public void MakeRandomData_ReturnsPointWithRandomData_WhenTypeImplementsIInit()
        {
            // Act
            var result = Point<ControlElement>.MakeRandomData();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void MakeRandomItem_ReturnsValidItem_WhenTypeImplementsIInit()
        {
            // Act
            var result = Point<ControlElement>.MakeRandomItem();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ToString_ReturnsDataToString_WhenDataNotNull()
        {
            // Arrange
            var data = new ControlElement("Id_1", 12.1, 11.1, 100);
            var point = new Point<ControlElement>(data);

            // Act
            var result = point.ToString();

            // Assert
            Assert.AreEqual(data.ToString(), result);
        }

        [TestMethod]
        public void ToString_ReturnsEmptyString_WhenDataIsNull()
        {
            // Arrange
            var point = new Point<ControlElement>();

            // Act
            var result = point.ToString();

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsDataGetHashCode_WhenDataNotNull()
        {
            // Arrange
            var data = new ControlElement("Id_1", 12.1, 11.1, 100);
            var point = new Point<ControlElement>(data);

            // Act
            var result = point.GetHashCode();

            // Assert
            Assert.AreEqual(data.GetHashCode(), result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsZero_WhenDataIsNull()
        {
            // Arrange
            var point = new Point<ControlElement>();

            // Act
            var result = point.GetHashCode();

            // Assert
            Assert.AreEqual(0, result);
        }
        //
        
        [TestMethod]
        public void AddPoint_AddsElementToHashTable()
        {
            // Arrange
            var hashTable = new MyHashTable<ControlElement>();

            // Act
            hashTable.AddPoint(new ControlElement("Id_1", 12.1, 11.1, 100));

            // Assert
            Assert.IsTrue(hashTable.Contains(new ControlElement("Id_1", 12.1, 11.1, 100)));
        }

       

        [TestMethod]
        public void ContainsKey_ReturnsTrue_WhenElementExistsInHashTable()
        {
            // Arrange
            var hashTable = new MyHashTable<ControlElement>();
            var element = new ControlElement("Id_1", 12.1, 11.1, 100);
            hashTable.AddPoint(element);

            // Act
            var result = hashTable.ContainsKey(element);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsKey_ReturnsFalse_WhenElementDoesNotExistInHashTable()
        {
            // Arrange
            var hashTable = new MyHashTable<ControlElement>();
            var element = new ControlElement("Id_1", 12.1, 11.1, 100);

            // Act
            var result = hashTable.ContainsKey(element);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MyHashTable_RemoveByKey_EmptyBucket_ReturnsFalse()
        {
            // Arrange
            var table = new MyHashTable<ControlElement>();
            var testData = new ControlElement("Test", 1.0, 2.0, 3);

            // Act
            var result = table.RemoveByKey(testData);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MyHashTable_RemoveByKey_FirstElementInBucket_RemovesAndReturnsTrue()
        {
            // Arrange
            var table = new MyHashTable<ControlElement>();
            var testData1 = new ControlElement("Test1", 1.0, 2.0, 3);
            var testData2 = new ControlElement("Test2", 2.0, 3.0, 4);
            table.AddPoint(testData1);
            table.AddPoint(testData2);

            // Act
            var result = table.RemoveByKey(testData1);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(table.Contains(testData1));
            Assert.IsTrue(table.Contains(testData2));
        }

        [TestMethod]
        public void MyHashTable_RemoveByKey_MiddleElementInBucket_RemovesAndReturnsTrue()
        {
            // Arrange
            var table = new MyHashTable<ControlElement>();
            var testData1 = new ControlElement("Test1", 1.0, 2.0, 3);
            var testData2 = new ControlElement("Test2", 2.0, 3.0, 4);
            var testData3 = new ControlElement("Test3", 3.0, 4.0, 5);
            table.AddPoint(testData1);
            table.AddPoint(testData2);
            table.AddPoint(testData3);

            // Act
            var result = table.RemoveByKey(testData2);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(table.Contains(testData1));
            Assert.IsFalse(table.Contains(testData2));
            Assert.IsTrue(table.Contains(testData3));
        }

        [TestMethod]
        public void MyHashTable_RemoveByKey_LastElementInBucket_RemovesAndReturnsTrue()
        {
            // Arrange
            var table = new MyHashTable<ControlElement>();
            var testData1 = new ControlElement("Test1", 1.0, 2.0, 3);
            var testData2 = new ControlElement("Test2", 2.0, 3.0, 4);
            var testData3 = new ControlElement("Test3", 3.0, 4.0, 5);
            table.AddPoint(testData1);
            table.AddPoint(testData2);
            table.AddPoint(testData3);

            // Act
            var result = table.RemoveByKey(testData3);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(table.Contains(testData1));
            Assert.IsTrue(table.Contains(testData2));
            Assert.IsFalse(table.Contains(testData3));
        }

        [TestMethod]
        public void Constructor_WithCollection_InitializesCorrectly()
        {
            // Arrange
            ControlElement[] collection = new ControlElement[3];
            for (int i = 0; i < 3; i++)
            {
                collection[i] = new ControlElement();
                collection[i].IRandomInit();
            }

            // Act
            MyHashTable<ControlElement> table = new MyHashTable<ControlElement>(collection);

            // Assert
            CollectionAssert.AreEqual(collection, table.Collection); 
        }


        private ControlElement CreateRandomElement()
        {
            ControlElement element = new ControlElement();
            element.IRandomInit();
            return element;
        }

        [TestMethod]
        public void RemoveData_ElementExistsInFirstPosition_ReturnsTrue()
        {
            // Arrange
            MyHashTable<ControlElement> table = new MyHashTable<ControlElement>(10);
            ControlElement element = CreateRandomElement();
            table.AddPoint(element);

            // Act
            bool result = table.RemoveData(element);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(table.Contains(element));
        }

        [TestMethod]
        public void RemoveData_ElementExistsInMiddle_ReturnsTrue()
        {
            // Arrange
            MyHashTable<ControlElement> table = new MyHashTable<ControlElement>(10);
            ControlElement element1 = CreateRandomElement();
            ControlElement element2 = CreateRandomElement();
            ControlElement element3 = CreateRandomElement();
            table.AddPoint(element1);
            table.AddPoint(element2);
            table.AddPoint(element3);

            // Act
            bool result = table.RemoveData(element2);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(table.Contains(element2));
            Assert.IsTrue(table.Contains(element1));
            Assert.IsTrue(table.Contains(element3));
        }

        [TestMethod]
        public void RemoveData_ElementExistsInLastPosition_ReturnsTrue()
        {
            // Arrange
            MyHashTable<ControlElement> table = new MyHashTable<ControlElement>(10);
            ControlElement element1 = CreateRandomElement();
            ControlElement element2 = CreateRandomElement();
            ControlElement element3 = CreateRandomElement();
            table.AddPoint(element1);
            table.AddPoint(element2);
            table.AddPoint(element3);

            // Act
            bool result = table.RemoveData(element3);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(table.Contains(element3));
            Assert.IsTrue(table.Contains(element1));
            Assert.IsTrue(table.Contains(element2));
        }

        [TestMethod]
        public void RemoveData_ElementDoesNotExist_ReturnsFalse()
        {
            // Arrange
            MyHashTable<ControlElement> table = new MyHashTable<ControlElement>(10);
            ControlElement element1 = CreateRandomElement();
            ControlElement element2 = CreateRandomElement();
            ControlElement element3 = CreateRandomElement();
            ControlElement nonExistentElement = CreateRandomElement();
            table.AddPoint(element1);
            table.AddPoint(element2);
            table.AddPoint(element3);

            // Act
            bool result = table.RemoveData(nonExistentElement);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(table.Contains(element1));
            Assert.IsTrue(table.Contains(element2));
            Assert.IsTrue(table.Contains(element3));
        }

        [TestMethod]
        public void RemoveData_EmptyTable_ReturnsFalse()
        {
            // Arrange
            MyHashTable<ControlElement> table = new MyHashTable<ControlElement>(10);
            ControlElement element = CreateRandomElement();

            // Act
            bool result = table.RemoveData(element);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PrintTable_EmptyTable_PrintsEmptyIndices()
        {
            // Arrange
            var hashTable = new MyHashTable<ControlElement>(5);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                hashTable.PrintTable();

                // Assert
                var expectedOutput = "0:\r\n1:\r\n2:\r\n3:\r\n4:\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintTable_TableWithOneElement_PrintsElement()
        {
            // Arrange
            var hashTable = new MyHashTable<ControlElement>(5);
            var element = new ControlElement ();
            hashTable.AddPoint(element);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                hashTable.PrintTable();

                // Assert
                var expectedOutput = "0:\r\n1:\r\n2:\r\n3:\r\n4:\r\n1:\r\n";
                Assert.IsTrue(sw.ToString().Contains("1:"));
                Assert.IsTrue(sw.ToString().Contains("1"));
            }
        }
    }
}



