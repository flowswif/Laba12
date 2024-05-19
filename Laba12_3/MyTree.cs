using System;
using Laba10;
using ClassLibrary1;

namespace Laba12_3
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        public Point<T>? root = null;
        int count = 0;

        public int Count => count;

        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length);
        }

        public void ShowTree()
        {
            if (root == null)
            {
                Console.WriteLine("The tree is empty.");
                return;
            }

            Show(root);
        }

        public int CountLeaves()
        {
            return CountLeaves(root);
        }

        private int CountLeaves(Point<T>? node)
        {
            if (node == null)
                return 0;
            if (node.Left == null && node.Right == null)
                return 1;
            return CountLeaves(node.Left) + CountLeaves(node.Right);
        }

        private Point<T>? MakeTree(int length)
        {
            if (length == 0) return null;

            T data = new T();
            data.IRandomInit();
            Point<T> newItem = new Point<T>(data);

            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl);
            newItem.Right = MakeTree(nr);

            return newItem;
        }

        private void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }

        public void AddPoint(T data)
        {
            if (root == null)
            {
                root = new Point<T>(data);
                count++;
                return;
            }

            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;
            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else
                {
                    if (point.Data.CompareTo(data) > 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
            }
            if (isExist)
            {
                return;
            }
            Point<T> newPoint = new Point<T>(data);
            if (current.Data.CompareTo(data) > 0)
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }

        private void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            if (root == null || count == 0) return;

            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);

            root = null;
            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }

        public bool Remove(T key)
        {
            if (root == null)
                return false;

            Point<T> parent = null;
            Point<T> current = root;

            while (current != null)
            {
                int comparisonResult = key.CompareTo(current.Data);
                if (comparisonResult == 0)
                    break;
                else
                {
                    parent = current;
                    if (comparisonResult < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }
            }

            if (current == null)
                return false;

            if (current.Left == null && current.Right == null)
            {
                if (parent == null)
                    root = null;
                else if (parent.Left == current)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            else if (current.Left == null || current.Right == null)
            {
                Point<T> child = current.Left ?? current.Right;
                if (parent == null)
                    root = child;
                else if (parent.Left == current)
                    parent.Left = child;
                else
                    parent.Right = child;
            }
            else
            {
                Point<T> successorParent = current;
                Point<T> successor = current.Right;
                while (successor.Left != null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }

                if (successorParent != current)
                {
                    successorParent.Left = successor.Right;
                    successor.Right = current.Right;
                }

                successor.Left = current.Left;

                if (parent == null)
                    root = successor;
                else if (parent.Left == current)
                    parent.Left = successor;
                else
                    parent.Right = successor;
            }

            count--;
            return true;
        }

        private void DeepClearTree(Point<T>? node)
        {
            if (node == null)
                return;

            DeepClearTree(node.Left);
            DeepClearTree(node.Right);

            node.Left = null;
            node.Right = null;

            count--;
        }

        public void ClearTree()
        {
            DeepClearTree(root);
            root = null;
            count = 0;
        }

        public void PrintTreeByLevels()
        {
            if (root == null)
            {
                Console.WriteLine("The tree is empty.");
                return;
            }

            Queue<Point<T>> queue = new Queue<Point<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                while (levelSize > 0)
                {
                    Point<T> current = queue.Dequeue();
                    Console.Write(current.Data + " ");
                    if (current.Left != null)
                    {
                        queue.Enqueue(current.Left);
                    }
                    if (current.Right != null)
                    {
                        queue.Enqueue(current.Right);
                    }
                    levelSize--;
                }
                Console.WriteLine();
            }
        }
    }
}
  