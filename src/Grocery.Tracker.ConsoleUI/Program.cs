using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;

namespace Grocery.Tracker.ConsoleUI
{
    public class Program
    {
        static void Main()
        {
            List<GroceryItem> groceries = new List<GroceryItem>();
            int k = 1;
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
            PrintGroceries(groceries);
            }

        static void PrintGroceries(List<GroceryItem> items)
        {
            foreach (GroceryItem item in items)
            {
                Console.WriteLine(item.ToConsoleText());
            }
        }
        class GroceryItem
        {
            public int Id;
            public string Name;
            public string Category;
            public DateTime PurchaseDate;
            public DateTime OpenDate;
            public DateTime ExpiryDate;
            public string Description;

            public string ToConsoleText()
            {
                return
                    $"Id: {this.Id} Name: {this.Name} Category: {this.Category} PurchaseDate: {this.PurchaseDate:dd/MM/yyyy} " +
                    $"OpenDate: {this.OpenDate:dd/MM/yyyy} ExpiryDate: {this.ExpiryDate:dd/MM/yyyy} Description: {this.Description}";
            }
        }
        
    }
}