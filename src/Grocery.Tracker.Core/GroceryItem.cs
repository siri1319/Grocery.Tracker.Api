using System;

namespace Grocery.Tracker.Core
{
    public class GroceryItem
    {
        public GroceryItem()
        {
            Id = Guid.NewGuid();
        }

       

        public Guid Id { get; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Description { get; set; }

        public string ToConsoleText()
        {
            return
                $"{this.Id,2} | {this.Name,-8} | {this.Category,-8} | {this.Quantity,-8} | {this.PurchaseDate:dd/MM/yyyy} |" +
                $" {this.OpenDate:dd/MM/yyyy} | {this.ExpiryDate:dd/MM/yyyy} | {this.Description,-10}";
        }
    }
}