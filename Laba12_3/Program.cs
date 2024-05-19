using System;
using ClassLibrary1;
using Laba10;

namespace Laba12_3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTree<ControlElement> tree = null; 
            bool treeCleared = true; // Флаг, указывающий, что дерево было очищено
            int answer = 1;

            string[] menu = { "1. Create a tree",
                          "2. Show the tree",
                          "3. Count the number of leaves",
                          "4. Delete an item by key",
                          "5. Clear the tree",
                          "6. Convert to a search tree",
                          "7. Exit"
                        };

            while (answer != 7)
            {
                PrintMenu(menu);
                answer = IsInt(1, 7);

                // Если дерево было очищено, то выводим сообщение и продолжаем цикл
                

                switch (answer)
                {
                    case 1:
                        Console.Write("Enter the number of items in the tree: ");
                        int length;
                        if (!int.TryParse(Console.ReadLine(), out length))
                        {
                            Console.WriteLine("Error: Enter the correct number.");
                            continue;
                        }
                        tree = new MyTree<ControlElement>(length);
                        treeCleared = false; // Сбрасываем флаг после создания нового дерева
                        Console.WriteLine("The tree has been created.");
                        break;
                    case 2:
                        if (treeCleared)
                        {
                            Console.WriteLine("Error: The tree was cleared. Please create a new tree.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Tree:");
                            tree.ShowTree();
                        }
                        break;
                    case 3:
                        if (treeCleared)
                        {
                            Console.WriteLine("Error: The tree was cleared. Please create a new tree.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"Number of leaves: {tree.CountLeaves()}");
                        }
                        break;
                    case 4:
                        if (treeCleared)
                        {
                            Console.WriteLine("Error: The tree was cleared. Please create a new tree.");
                            continue;
                        }
                        else
                        {
                            Console.Write("Enter the key to delete: ");
                            ControlElement key = new ControlElement();
                            key.Init();
                            if (tree.Remove(key))
                                Console.WriteLine($"The element with the {key} key has been successfully deleted.");
                            else
                                Console.WriteLine($"The element with the {key} key was not found.");
                        }
                        if (tree.Count == 0)
                            treeCleared = true;

                        break;
                    case 5:
                        if (treeCleared)
                        {
                            Console.WriteLine("Error: The tree was cleared. Please create a new tree.");
                            continue;
                        }
                        else
                        {
                            tree.ClearTree();
                            Console.WriteLine("The tree has been cleared.");
                            treeCleared = true; // Устанавливаем флаг после очистки дерева
                        }
                        break;
                    case 6:
                        if (treeCleared)
                        {
                            Console.WriteLine("Error: The tree was cleared. Please create a new tree.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Original Tree (Balanced):");
                            tree.PrintTreeByLevels();
                            tree.TransformToFindTree();
                            Console.WriteLine("Transformed Tree (Binary Search Tree):");
                            tree.PrintTreeByLevels();
                            Console.WriteLine("The tree has been transformed into a search tree.");
                        }
                        break;

                }

                Console.WriteLine();
            }
        }
        static void PrintMenu(string[] menu)
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
            Console.Write("Enter your choice: ");
        }

        static int IsInt(int min, int max) //функция для проверки на Int (параметры - минимальное и максимальное значение)
        {
            bool isConvert;
            int number;
            do
            {
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out number);
                if (!isConvert || number < min || number > max)
                {
                    Console.WriteLine($"The number is entered incorrectly. Enter a value from {min} to {max}");
                }
            } while (!isConvert || number < min || number > max);
            return number;
        }
    }
}
