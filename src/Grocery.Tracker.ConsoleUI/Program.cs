using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization; 
using Grocery.Tracker.Core;

namespace Grocery.Tracker.ConsoleUI
{
    public class Program
    {
        static void Main()
        {
                List<GroceryItem> groceries = new List<GroceryItem>();
                GroceryStorageService service = new GroceryStorageService();
               

            while (true)
            {

                int option = GetMenuSelectionFromUser();
                switch (option)
                {

                    case 1:
                        while (true)
                        {
                            GroceryItem groceryItem = new GroceryItem();
                            Console.WriteLine("Enter Grocery name: ");
                            groceryItem.Name = Console.ReadLine();

                            Console.WriteLine("Enter Category: ");
                            groceryItem.Category = Console.ReadLine();

                            Console.WriteLine("Enter Quantity");
                            groceryItem.Quantity = Console.ReadLine();

                            Console.WriteLine("Enter Purchased date(dd/mm/yyyy): ");
                            string purchaseDateInput = Console.ReadLine();
                            groceryItem.PurchaseDate = DateTime.ParseExact(string.IsNullOrWhiteSpace(purchaseDateInput) ? "01/01/2021" : purchaseDateInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            Console.WriteLine("Enter Open date(dd/mm/yyyy): ");
                            string openDateInput = Console.ReadLine();
                            groceryItem.OpenDate = DateTime.ParseExact(string.IsNullOrWhiteSpace(openDateInput) ? "02/02/2022" : openDateInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            Console.WriteLine("Enter Expiry date(dd/mm/yyyy): ");
                            string expiryInput = Console.ReadLine();
                            groceryItem.ExpiryDate = DateTime.ParseExact(string.IsNullOrWhiteSpace(expiryInput) ? "31/12/2021" : expiryInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            Console.WriteLine("Enter Description: ");
                            groceryItem.Description = Console.ReadLine();

                            groceries.Add(groceryItem);
                            
                            Console.WriteLine("Do you want to continue to add groceries yes/no");
                            string val = Console.ReadLine();
                            if (val == "no")
                            {
                                
                                Console.WriteLine("Successfully added the following groceries");
                                PrintGroceries(groceries);
                                
                                break;
                            }
                            
                        }
                        service.SaveGroceryItem(groceries);
                        break;
                    case 2:
                        Console.WriteLine("You opted to View Groceries");
                        Console.WriteLine("Enter the grocery name to view:");
                        string groceryName = Console.ReadLine();
                        List<GroceryItem> allGroceries = service.GetGroceryItems();
                        List<GroceryItem> selectedGroceries = new List<GroceryItem>();
                        foreach (GroceryItem item in allGroceries)
                        {
                            if(item.Name == groceryName)
                            {
                                selectedGroceries.Add(item);
                            }
                        }
                        PrintGroceries(selectedGroceries);
                        break;
                    case 3:
                        Console.WriteLine("You opted to Update Groceries");
                        break;
                    case 4:
                        Console.WriteLine("You opted to Delete Groceries");
                        break;
                    //case 5:
                    //    Console.WriteLine("Good Bye!!!");
                    //    break;

                }
                if (option == 5)
                {
                    Console.WriteLine("Good Bye!!!");
                    break;
                }
                
            }   
        }

        static void PrintGroceries(List<GroceryItem> items)
        {
            
            foreach (GroceryItem item in items)
            {
                Console.WriteLine(item.ToConsoleText());
            }
        }
        static int GetMenuSelectionFromUser()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("Welcome to Grocery Tracker! ");
            Console.WriteLine("*******************************");
            Console.WriteLine("1.Add groceries");
            Console.WriteLine("2.View groceries");
            Console.WriteLine("3.Update gorceries");
            Console.WriteLine("4.Delete groceries");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Please choose the option to proceed:");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }

        
    }
}