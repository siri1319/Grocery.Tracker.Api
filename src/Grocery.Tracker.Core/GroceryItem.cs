using System;

namespace Grocery.Tracker.Core
{
    public class GroceryItem
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