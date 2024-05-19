using Laba10;
using Laba12_1_2;
using System.Collections.Generic;
using System.Drawing;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddToBegin()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();
            ControlElement element1 = new ControlElement("Id_1", 12.1, 11.1, 100);
            ControlElement element2 = new ControlElement("Id_2", 12.1, 11.1, 101);
            ControlElement element3 = new ControlElement("Id_3", 12.1, 11.1, 102);

            // Act
            list.AddToBegin(element1);
            list.AddToBegin(element2);
            list.AddToBegin(element3);

            // Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("Id_3", list.GetHead()?.Data.Id);
        }
        [TestMethod]
        public void AddToEnd_WhenAddingFirstItem_EndPointsToNewItem()
        {
            // Arrange
            MyList<ControlElement> yourClass = new MyList<ControlElement>();
            ControlElement item = new ControlElement("Id_1", 12.1, 11.1, 100);

            // Act
            yourClass.AddToEnd(item);

            // Assert
            Assert.AreEqual(item, yourClass.end.Data);
        }

        [TestMethod]
        public void AddToEnd_WhenAddingSecondItem_EndPointsToSecondItem()
        {
            // Arrange
            MyList<ControlElement> yourClass = new MyList<ControlElement>();
            ControlElement firstItem = new ControlElement("Id_1", 12.1, 11.1, 100);
            ControlElement secondItem = new ControlElement("Id_2", 12.1, 11.1, 101);

            // Act
            yourClass.AddToEnd(firstItem);
            yourClass.AddToEnd(secondItem);

            // Assert
            Assert.AreEqual(secondItem, yourClass.end.Data);
        }

        [TestMethod]
        public void FindItem_WhenItemDoesNotExist_ReturnsNull()
        {
            // Arrange
            MyList<ControlElement> yourClass = new MyList<ControlElement>();
            ControlElement itemToFind = new ControlElement("Id_1", 12.1, 11.1, 100);

            // Act
            Point <ControlElement> foundItem = yourClass.FindItem(itemToFind);

            // Assert
            Assert.IsNull(foundItem);
        }

        [TestMethod]
        public void Data_GetAndSet_ShouldReturnSetValue()
        {
            // Arrange
            ControlElement testData = new ControlElement("Id_1", 12.1, 11.1, 100);
            Point < ControlElement > point = new Point<ControlElement>();

            // Act
            point.Data = testData;

            // Assert
            Assert.AreEqual(testData, point.Data);
        }

        [TestMethod]
        public void Next_GetAndSet_ShouldReturnSetValue()
        {
            // Arrange
            Point<ControlElement> nextPoint = new Point<ControlElement>();
            Point<ControlElement> point = new Point<ControlElement>();

            // Act
            point.Next = nextPoint;

            // Assert
            Assert.AreEqual(nextPoint.Data, point.Next.Data);
        }

        [TestMethod]
        public void Pred_GetAndSet_ShouldReturnSetValue()
        {
            // Arrange
            Point<ControlElement> predPoint = new Point<ControlElement>();
            Point<ControlElement> point = new Point<ControlElement>();

            // Act
            point.Pred = predPoint;

            // Assert
            Assert.AreEqual(predPoint.Data, point.Pred.Data);
        }
        [TestMethod]
        public void DefaultConstructor_SetsDefaultValues()
        {
            // Arrange & Act
            Point<ControlElement> point = new Point<ControlElement>();

            // Assert
            Assert.AreEqual(default(ControlElement), point.Data);
            Assert.IsNull(point.Pred);
            Assert.IsNull(point.Next);
        }

        [TestMethod]
        public void ParameterizedConstructor_SetsProvidedDataAndDefaultsLinks()
        {
            // Arrange
            ControlElement testData = new ControlElement("Id_1", 12.1, 11.1, 100);

            // Act
            Point < ControlElement > point = new Point<ControlElement>(testData);

            // Assert
            Assert.AreEqual(testData, point.Data);
            Assert.IsNull(point.Pred);
            Assert.IsNull(point.Next);
        }
        [TestMethod]
        public void ToString_ReturnsDataStringRepresentation_WhenDataIsNotNull()
        {
            // Arrange
            ControlElement testData = new ControlElement("Id_1", 12.1, 11.1, 100);
            Point < ControlElement > point = new Point<ControlElement>(testData);

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual(testData.ToString(), result);
        }

        [TestMethod]
        public void ToString_ReturnsEmptyString_WhenDataIsNull()
        {
            // Arrange
            Point<ControlElement> point = new Point<ControlElement>();

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual("", result);
        }
        [TestMethod]
        public void Constructor_WithSize_CreatesListWithSpecifiedSize()
        {
            // Arrange
            int size = 5;

            // Act
            MyList<ControlElement> list = new MyList<ControlElement>(size);

            // Assert
            Assert.AreEqual(size, list.Count);
        }

        [TestMethod]
        public void Constructor_WithSize_CreatesListWithRandomData()
        {
            // Arrange
            int size = 5;

            // Act
            MyList<ControlElement> list = new MyList<ControlElement>(size);

            // Assert
            Assert.IsNotNull(list.beg);
            Assert.IsNotNull(list.end);
            Assert.IsNotNull(list.beg.Data);
            Assert.IsNotNull(list.end.Data);
            Assert.AreNotEqual(list.beg.Data, list.end.Data);
        }

        [TestMethod]
        public void Constructor_WithCollection_CreatesListWithSameElementsAsCollection()
        {
            // Arrange
            ControlElement[] collection = new ControlElement[]
            {
        new ControlElement("Id_1", 12.1, 11.1, 100),
        new ControlElement("Id_2", 12.1, 11.1, 101),
        new ControlElement("Id_3", 12.1, 11.1, 102)
            };

            // Act
            MyList<ControlElement> list = new MyList<ControlElement>(collection);

            // Assert
            Assert.AreEqual(collection.Length, list.Count);
        }



        [TestMethod]
        public void Clear_ClearsList_WhenListIsNotEmpty()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();
            // Создаем и добавляем элементы в список
            list.AddToEnd(new ControlElement("Id_1", 12.1, 11.1, 100));
            list.AddToEnd(new ControlElement("Id_2", 12.1, 11.1, 101));
            list.AddToEnd(new ControlElement("Id_3", 12.1, 11.1, 102));

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.beg);
            Assert.IsNull(list.end);
        }

        [TestMethod]
        public void Clear_DoesNothing_WhenListIsEmpty()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.beg);
            Assert.IsNull(list.end);
        }
        [TestMethod]
        public void RemoveUntilItem_RemovesElementsBeforeTarget_WhenTargetIsFound()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();
            // Создаем и добавляем элементы в список
            list.AddToEnd(new ControlElement("Id_1", 12.1, 11.1, 100));
            list.AddToEnd(new ControlElement("Id_2", 12.1, 11.1, 101));
            list.AddToEnd(new ControlElement("Id_3", 12.1, 11.1, 102));
            ControlElement targetItem = new ControlElement("Id_2", 12.1, 11.1, 101);

            // Act
            list.RemoveUntilItem(targetItem);

            // Assert
            Point<ControlElement> current = list.beg;
            bool targetFound = false;
            bool itemsBeforeTargetRemoved = true; 

            while (current != null)
            {
                if (current.Data.Equals(targetItem))
                {
                    targetFound = true;
                    break;
                }

                if (!itemsBeforeTargetRemoved)
                {
                    // Если мы находимся за целевым элементом, но все еще видим элементы до него
                    itemsBeforeTargetRemoved = false;
                }
                else
                {
                    // Если мы дошли до целевого элемента, но видим элементы до него
                    itemsBeforeTargetRemoved = false;
                    break;
                }

                current = current.Next;
            }

            Assert.IsTrue(targetFound, "Target item not found in the list after removing elements before it.");
            Assert.IsTrue(itemsBeforeTargetRemoved, "Items before the target were not removed.");
        }


        [TestMethod]
        public void RemoveUntilItem_DoesNothing_WhenListIsEmpty()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();
            ControlElement targetItem = new ControlElement("Id_1", 12.1, 11.1, 100);

            // Act
            list.RemoveUntilItem(targetItem);

            // Assert
            Assert.AreEqual(0, list.Count, "Count should remain 0 when list is empty.");
            Assert.IsNull(list.beg, "Beg should be null when list is empty.");
            Assert.IsNull(list.end, "End should be null when list is empty.");
        }

        [TestMethod]
        public void RemoveUntilItem_DoesNothing_WhenTargetItemIsNotFound()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();
            // Создаем и добавляем элементы в список
            list.AddToEnd(new ControlElement("Id_1", 12.1, 11.1, 100));
            list.AddToEnd(new ControlElement("Id_2", 12.1, 11.1, 101));
            list.AddToEnd(new ControlElement("Id_3", 12.1, 11.1, 102));
            ControlElement targetItem = new ControlElement("Id_4", 12.1, 11.1, 103);

            // Act
            list.RemoveUntilItem(targetItem);

            // Assert
            Assert.AreEqual(3, list.Count, "Count should remain the same when target item is not found.");
        }
        [TestMethod]
        public void Clone_ReturnsClonedList()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();
            list.AddToEnd(new ControlElement("Id_1", 12.1, 11.1, 100));
            list.AddToEnd(new ControlElement("Id_2", 12.1, 11.1, 101));
            list.AddToEnd(new ControlElement("Id_3", 12.1, 11.1, 102));

            // Act
            MyList<ControlElement> clonedList = list.Clone();

            // Assert
            Assert.AreEqual(list.Count, clonedList.Count);
            Assert.AreNotSame(list, clonedList);

            
        }
        [TestMethod]
        public void AddAfterItem_AddsItemAfterTargetItem_WhenTargetItemExists()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();

            // Создаем и добавляем элементы в список
            ControlElement targetItem = new ControlElement("Id_1", 12.1, 11.1, 100);
            ControlElement newItem = new ControlElement("Id_2", 12.1, 11.1, 101);
            list.AddToEnd(targetItem);

            // Act
            list.AddAfterItem(targetItem, newItem);

            // Assert
            Point<ControlElement> current = list.beg;
            bool newItemAdded = false;
            while (current != null)
            {
                if (current.Data.Equals(targetItem) && current.Next != null && current.Next.Data.Equals(newItem))
                {
                    newItemAdded = true;
                    break;
                }
                current = current.Next;
            }

            Assert.IsTrue(newItemAdded, "New item was not added after target item.");
        }

        [TestMethod]
        public void AddAfterItem_DoesNotAddItem_WhenTargetItemDoesNotExist()
        {
            // Arrange
            MyList<ControlElement> list = new MyList<ControlElement>();

            // Создаем и добавляем элементы в список
            ControlElement targetItem = new ControlElement("Id_1", 12.1, 11.1, 100);
            ControlElement newItem = new ControlElement("Id_2", 12.1, 11.1, 101);
            list.AddToEnd(targetItem);

            // Act
            list.AddAfterItem(new ControlElement("Non_Existent_Id", 0, 0, 0), newItem);

            // Assert
            Point<ControlElement> current = list.beg;
            bool newItemAdded = false;
            while (current != null)
            {
                if (current.Data.Equals(newItem))
                {
                    newItemAdded = true;
                    break;
                }
                current = current.Next;
            }

            Assert.IsFalse(newItemAdded, "New item should not have been added when target item does not exist.");
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
    }
}