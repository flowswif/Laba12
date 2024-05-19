using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Laba10;

namespace Laba12_1_2
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T> beg = null;
        public Point<T> end = null;

        int count = 0;

        public int Count => count;

        

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }


        public Point<T> FindItem(T item)
        {
            Point<T> current = beg;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data is null");
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }
        //public Point<T> FindItem(T item)
        //{
        //    Point<T> current = beg;
        //    while (current != null)
        //    {
        //        //Console.WriteLine(current.Data.Equals(item));
        //        if (current.Data is ControlElement p && p.Id.Equals(item)) // Правильно сравниваем объекты с помощью Equals
        //                return current;
        //        current = current.Next;
        //    }
        //    return null;
        //}
        public void AddAfterItem(T targetItem, T newItem)
        {
            // Создаем копию нового элемента
            T newData = (T)newItem.Clone();
            Point<T> newItemNode = new Point<T>(newData);
            count++;

            // Ищем элемент с заданным информационным полем
            Point<T> targetNode = FindItem(targetItem);
            if (targetNode == null)
            {
                // Если элемент с заданным информационным полем не найден, выходим из метода
                return;
            }

            // Вставляем новый элемент после найденного элемента
            newItemNode.Next = targetNode.Next;
            newItemNode.Pred = targetNode;
            targetNode.Next = newItemNode;

            // Если новый элемент добавлен в конец списка, обновляем ссылку на конец списка
            if (newItemNode.Next == null)
            {
                end = newItemNode;
            }
            else
            {
                // Обновляем ссылку на следующий элемент после нового элемента
                newItemNode.Next.Pred = newItemNode;
            }
        }



        public MyList() { }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("size less zero");
            beg = Point<T>.MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = Point<T>.MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }

        public MyList(T[] collection)
        {
            if (collection == null) throw new Exception("empty collection: null");
            if (collection.Length == 0)
                throw new Exception("empty collection");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 0; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public MyList<T> Clone()
        {
            MyList<T> cloneList = new MyList<T>();
            Point<T>? current = beg;
            while (current != null)
            {
                cloneList.AddToEnd(current.Data);
                current = current.Next;
            }
            cloneList.count = count;
            return cloneList;
        }
        public Point<T> GetHead()
        {
            return beg;
        }

        
        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("the list is empty");
            Point<T> current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }

        }

        public void RemoveUntilItem(T targetItem)
        {
            if (beg == null)//пустой список
            {
                Console.WriteLine("Error! The List is empty");
                return;
            }

            // Ищем целевой элемент
            Point<T> target = FindItem(targetItem);

            if (target == null) // целевой элемент не найден
            {
                Console.WriteLine("Error! The target item is not found.");
                return;
            }
            else
            {
                Console.WriteLine("Elements before the specified element are removed.");
            }

            // Удаление элементов до заданного элемента
            while (beg != null && beg != target)
            {
                beg = beg.Next;
                count--;
            }

            //// Удаление целевого элемента
            //if (beg == target)
            //{
            //    beg = beg.Next;
            //    count--;

            //}
        }

        public void Clear()
        {
            Point<T> current = beg;
            while (current != null)
            {
                Point<T> next = current.Next;
                current.Data = default; // Освобождаем ссылку на данные
                current.Next = null;
                current.Pred = null;
                current = next;
            }

            beg = null;
            end = null;
            count = 0;
        }


    }
}
