using System;
using System.Collections.Generic;

namespace Grocery.Tracker.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryNames = new List<string>();
            while (true)
            {
                Console.WriteLine("Please enter grocery name:");
                string groceryName = Console.ReadLine();
                if (groceryName == "exit")
                {
                    break;
                }
                groceryNames.Add(groceryName); 
            }
                
            PrintNames(groceryNames);
        }

        static void PrintNames(List<string> items)
        {
            foreach (string item in items)
            {
                Console.WriteLine(item); 
            }
            
        }
    }
}