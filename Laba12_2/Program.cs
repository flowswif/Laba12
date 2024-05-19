using Laba10;
using Laba12_2;
using System.Collections.Generic;

namespace Laba12_2;

class Program
{
    static void Main(string[] args)
    {
        bool flug = false;
        MyHashTable<ControlElement> table = new MyHashTable<ControlElement>();
        int answer = 1;
        string[] menu = { "1. Create a table",
                          "2. Print the table",
                          "3. Search in the table",
                          "4. Deleting in the table",
                          "5. Adding to the table",
                          "6. Exit",
                        };
        while (answer != 6)
        {
            PrintMenu(menu);
            answer = IsInt(1, 6);
            switch (answer)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Размер таблицы? (от 10 до 100)");
                        int size = IsInt(10, 100);
                        CreateTable(size, table);
                        flug = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    break;
                case 2:
                    table.PrintTable();
                    break;
                case 3:
                    if (!flug)
                    {
                        Console.WriteLine("The table is empty. Cannot perform search.");
                    }
                    else
                    {
                        try
                        {
                            ControlElement elementForSearch = new ControlElement();
                            Console.WriteLine("Enter the object to search for");
                            elementForSearch.Init();
                            Console.WriteLine("The table contains this object: " + table.ContainsKey(elementForSearch));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    break;
                case 4:
                    
                    if (!flug)
                    {
                        Console.WriteLine("The table is empty. Cannot perform deletion.");
                    }
                    else
                    {
                        try
                        {
                            ControlElement elementForRemove = new ControlElement();
                            Console.WriteLine("Enter the object to delete");
                            elementForRemove.Init();
                            if (table.RemoveByKey(elementForRemove) == false)
                                Console.WriteLine("The element was not found in the table");
                            else
                                Console.WriteLine("The deletion was successful");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    break;
                case 5:
                    try
                    {
                        Console.WriteLine("Let's add a random element to the table");
                        ControlElement elementForAdd = new ControlElement();
                        elementForAdd.IRandomInit();
                        table.AddPoint(elementForAdd);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    break;
            }

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

    static void CreateTable(int size, MyHashTable<ControlElement> table)
    {

        Console.WriteLine("Enter 1, to fill in the table randomly" +
            "\nEnter 2, to fill in the table manually");
        int choice = IsInt(1, 2);
        if (choice == 1)
        {
            for (int i = 0; i < size; i++)
            {
                ControlElement elementForAdd = new ControlElement();
                elementForAdd.IRandomInit();
                table.AddPoint(elementForAdd);
            }
            table = new MyHashTable<ControlElement>(size);
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                ControlElement elementForAdd = new ControlElement();
                elementForAdd.Init();
                table.AddPoint(elementForAdd);
            }
        }
        Console.WriteLine("The table has been created");
        
    }
}

