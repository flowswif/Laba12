using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba10;
using Laba12_1_2;

namespace Laba12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //MyList<ControlElement> list1 = new MyList<ControlElement>(5);
            //list1.MakeRandomData();
            //list1.PrintList();
            //Console.WriteLine();
            //ControlElement element = new ControlElement();
            //element.IRandomInit();
            //list1.AddToBegin(element);
            //Console.WriteLine();
            //element = new ControlElement();
            //element.IRandomInit();
            //list1.AddToEnd(element);
            //list1.PrintList();

            //ControlElement element2 = new ControlElement();
            //element2.Init();
            //list1.RemoveUntilItem(element2);
            //Console.WriteLine(list1.FindItem(element2));
            //Console.WriteLine();
            //list1.PrintList();

            MyList<ControlElement> list = new MyList<ControlElement>();
            MyList<ControlElement> clonedList = list.Clone();
            int answer = 1;
            string[] menu = { "1. Create a new collection",
                          "2. Print the list",
                          "3. Add an item to the list after the item with the specified information field",
                          "4. Add element to the beginning",
                          "5. Add element to the end",
                          "6. Remove all items from the list, starting from the beginning of the list and up to the item with the specified information field",
                          "7. Delete the list from memory",
                          "8. Exit" };  
            while (answer != 8)
            {
                
                PrintMenu(menu);
                answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Enter collection size:");
                            if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
                            {
                                list = new MyList<ControlElement>(size);
                                Console.WriteLine("The list is created");
                                // Клонирование списка
                                clonedList = list.Clone();
                            }
                            else
                            {
                                Console.WriteLine("Invalid size. Please enter a positive integer.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                        break;

                    case 2:
                        if (clonedList != null)
                        {
                            clonedList.PrintList();
                        }
                        else
                        {
                            Console.WriteLine("List has not been created yet.");
                        }
                        break;

                    case 3:
                        ControlElement targetElement = new ControlElement();
                        ControlElement newElement = new ControlElement();
                        if (clonedList == null)
                        {
                            Console.WriteLine("The list is empty. Cannot add an element.");
                        }
                        else
                        {
                            targetElement.Init();
                            newElement.IRandomInit();
                            var foundItem = clonedList.FindItem(targetElement);
                            if (foundItem != null)
                            {
                                clonedList.AddAfterItem(targetElement, newElement);
                                Console.WriteLine("The element is added after the specified element");
                            }
                            else
                            {
                                Console.WriteLine("The specified element is not found in the list");
                            }
                        }
                        break;

                    case 4:
                        ControlElement element1 = new ControlElement();
                        element1.IRandomInit();
                        clonedList?.AddToBegin(element1);
                        Console.WriteLine("The element is added to the beginning");
                        break;

                    case 5:
                        ControlElement element2 = new ControlElement();
                        element2.IRandomInit();
                        clonedList?.AddToEnd(element2);
                        Console.WriteLine("The element is added to the end");
                        break;

                    case 6:
                        try
                        {
                            ControlElement targetElementToRemoveUntil = new ControlElement();
                            if (clonedList == null)
                            {
                                Console.WriteLine("The list is empty. No elements to remove.");
                            }
                            else
                            {
                                Console.WriteLine("Enter the target element to remove until:");
                                targetElementToRemoveUntil.Init();
                                clonedList.RemoveUntilItem(targetElementToRemoveUntil);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                        break;

                    case 7:
                        clonedList?.Clear();
                        break;


                    default:
                        Console.WriteLine("Invalid option. Please select a valid menu item.");
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
    }
}
