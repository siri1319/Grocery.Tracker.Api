using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

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
            var connection =new SqlConnection(@"Server=localhost,1401;Database=GroceryTracker;User=sa;Password=P@ssword;");
            var result = connection.Query("select * from GroceryItems");
            return groceryItems;
        }
    }
}