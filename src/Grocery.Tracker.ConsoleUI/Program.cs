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
            GroceryStorageService service = new GroceryStorageService();
            List<GroceryItem> test=service.GetGroceryItems();
            List<GroceryItem> groceries = new List<GroceryItem>();
            int groceryIdCounter = 1;
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