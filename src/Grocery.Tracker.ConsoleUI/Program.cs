using System;
using System.Collections.Generic;

namespace Grocery.Tracker.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GroceryItem> groceries = new List<GroceryItem>();
            while (true)
            {
                Console.WriteLine("Please enter grocery name:"); 
                GroceryItem grocery = new GroceryItem();
                grocery.Name = Console.ReadLine();
                if (grocery.Name == "exit")
                {
                    break;
                }
                groceries.Add(grocery);
            }
              
            PrintGroceries(groceries);
        }

        static void PrintGroceries(List<GroceryItem> items)
        {
            foreach (GroceryItem item in items)
            {
                Console.WriteLine($"Name: {item.Name}. ExpiryDate: {item.ExpiryDate}"); 
            }
            
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
    }
}