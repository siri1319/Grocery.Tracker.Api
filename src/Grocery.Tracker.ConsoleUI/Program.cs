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
            int groceryIdCounter = 1;
            GroceryStorageService service = new GroceryStorageService();
            while (true)
            {
                GroceryItem groceryItem = new GroceryItem();
                groceryItem.Id = groceryIdCounter;
                Console.WriteLine("Enter Grocery name: ");
                groceryItem.Name = Console.ReadLine();
                if (groceryItem.Name == "exit")
                {
                    break;
                }
                Console.WriteLine("Enter Category: ");
                groceryItem.Category = Console.ReadLine();
                Console.WriteLine("Enter Purchased date(dd/mm/yyyy): ");
                groceryItem.PurchaseDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Enter Open date(dd/mm/yyyy): ");
                groceryItem.OpenDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Enter Expiry date(dd/mm/yyyy): ");
                groceryItem.ExpiryDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Enter Description: ");
                groceryItem.Description= Console.ReadLine();
                groceries.Add(groceryItem);
                groceryIdCounter++;
            }
            service.SaveGroceryItem(groceries);
            
            List<GroceryItem> allGroceries=service.GetGroceryItems();
            PrintGroceries(allGroceries);
        }

        static void PrintGroceries(List<GroceryItem> items)
        {
            foreach (GroceryItem item in items)
            {
                Console.WriteLine(item.ToConsoleText());
            }
        }
        
        
    }
}