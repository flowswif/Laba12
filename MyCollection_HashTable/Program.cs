using System;
using ClassLibrary1;
using Laba10;

namespace MyCollection_HashTable
{

    class Program
    {
        static void Main(string[] args)
        {
            // Создание коллекции с 10 случайными элементами
            MyCollection<ControlElement> collection = new MyCollection<ControlElement>(10);
            Console.WriteLine("Initial collection:");
            collection.PrintTable();

            // Добавление элемента
            ControlElement newItem = new ControlElement();
            newItem.IRandomInit();
            collection.AddPoint(newItem);
            Console.WriteLine("\nAfter adding a new item:");
            collection.PrintTable();

            // Проверка наличия элемента
            bool containsNewItem = collection.Contains(newItem);
            Console.WriteLine($"\nCollection contains the new item: {containsNewItem}");

            // Удаление элемента
            collection.RemoveData(newItem);
            Console.WriteLine("\nAfter removing the new item:");
            collection.PrintTable();

            // Копирование элементов в массив
            ControlElement[] array = new ControlElement[collection.Count];
            collection.CopyTo(array, 0);
            Console.WriteLine("\nElements copied to array:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            // Использование конструктора копирования
            MyCollection<ControlElement> copiedCollection = new MyCollection<ControlElement>(collection);
            Console.WriteLine("\nCopied collection:");
            copiedCollection.PrintTable();

            // Демонстрация перечисления элементов
            Console.WriteLine("\nEnumerating elements in the collection:");
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
