using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Grocery.Tracker.Core
{
    public class GroceryStorageService
    {
        private string path = Environment.GetEnvironmentVariable("CSV_PATH");


        public void SaveGroceryItem(List<GroceryItem> newGroceries)
        {
            List<GroceryItem> allGroceries = new List<GroceryItem>();
            if (File.Exists(path))
            {
                allGroceries = GetGroceryItems();
                allGroceries.AddRange(newGroceries);
            }

            using (var writer = new StreamWriter(path))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(allGroceries);
                }
            }
        }

        public List<GroceryItem> GetGroceryItems()
        {
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<GroceryItem>();
                        return records.ToList();
                    }

                }
                
            }
            else
            {
                return new List<GroceryItem>();
            }
        }
    }
}