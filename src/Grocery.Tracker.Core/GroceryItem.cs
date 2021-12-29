using System;

namespace Grocery.Tracker.Core
{
    public class GroceryItem
    {
        public int Id;
        public string Name;
        public string Category;
        public string Quantity;
        public DateTime PurchaseDate;
        public DateTime OpenDate;
        public DateTime ExpiryDate;
        public string Description;

        public string ToConsoleText()
        {
            return
                $"{this.Id, 2} | {this.Name, -8} | {this.Category, -8} | {this.Quantity, -8} | {this.PurchaseDate:dd/MM/yyyy} |" +
                $" {this.OpenDate:dd/MM/yyyy} | {this.ExpiryDate:dd/MM/yyyy} | {this.Description, -10}";
        }
    }
}