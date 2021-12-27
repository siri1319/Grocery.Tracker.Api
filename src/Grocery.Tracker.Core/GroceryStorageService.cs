using System.Collections.Generic;

namespace Grocery.Tracker.Core
{
    public class GroceryStorageService
    {
        List<GroceryItem> groceryItems = new List<GroceryItem>();
        public void SaveGroceryItem(List<GroceryItem> grocery)
        {
            groceryItems.AddRange(grocery);
        }

        public List<GroceryItem> GetGroceryItems()
        {
            return groceryItems;
        }
    }
}