using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Grocery.Tracker.Core
{
    public class GroceryStorageService
    {
        private string path = Environment.GetEnvironmentVariable("CSV_PATH");

        public void AppendGroceryItem(List<GroceryItem> newGroceries)
        {
            List<GroceryItem> allGroceries = new List<GroceryItem>();
            if (File.Exists(path))
            {
                allGroceries = GetGroceryItems();
                allGroceries.AddRange(newGroceries);
            }

            WriteToCSV(allGroceries);

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

        public void WriteToCSV(List<GroceryItem> newGroceries)
        {
            using (var writer = new StreamWriter(path))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(newGroceries);
                }
            }
        }
        //public static void CreateFile()
        //{
        //    var dbFilePath = "D:\\Sri\\poc\\Groceries.sqlite";
        //    using var connection = new SqliteConnection($"Data Source='{dbFilePath}'");
        //    if (!File.Exists(dbFilePath))
        //    {
        //        File.Create(dbFilePath);
        //        connection.Execute("Create Table Groceries (" + "Id varchar(50) NOT NULL," + "Name varchar(100) NOT NULL," + "Category varchar(20)," + "Quantity varchar(20) NOT NULL," + "PurchaseDate text," + "OpenDate text," + "ExpiryDate text," + "Description varchar(1000)," + ")");
        //    }
        //}
    }
}