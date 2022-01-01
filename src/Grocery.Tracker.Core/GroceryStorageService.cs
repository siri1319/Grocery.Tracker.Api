using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Grocery.Tracker.Core
{
    public class GroceryStorageService
    {
        private string path = "/var/lib/GroceryTrackerApp/Groceries.csv";

        public void SaveGroceryItem(List<GroceryItem> newGroceries)
        {
            List<GroceryItem> allGroceries = new List<GroceryItem>();
            if (File.Exists(path))
            {
                allGroceries = GetGroceryItems();
                allGroceries.AddRange(newGroceries);
            }

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(allGroceries);
            }
        }

        public List<GroceryItem> GetGroceryItems()
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<GroceryItem>();
                return records.ToList();
            }
        }
    }
}