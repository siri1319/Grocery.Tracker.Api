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
            int k = 1;
            GroceryStorageService service = new GroceryStorageService();
            while (true)
            {
                GroceryItem grocery = new GroceryItem();
                grocery.Id = k;
                Console.WriteLine("Enter Grocery name: ");
                grocery.Name = Console.ReadLine();
                if (grocery.Name == "exit")
                {
                    break;
                }
                Console.WriteLine("Enter Category: ");
                grocery.Category = Console.ReadLine();
                Console.WriteLine("Enter Purchased date: ");
                grocery.PurchaseDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Enter Open date: ");
                grocery.OpenDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Enter Expiry date: ");
                grocery.ExpiryDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Enter Description: ");
                grocery.Description= Console.ReadLine();
                groceries.Add(grocery);
                k++;
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