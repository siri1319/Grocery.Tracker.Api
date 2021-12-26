using System;

namespace Grocery.Tracker.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] groceryNames = new string[100];
            var k = 0;
            for (int i = 0; i < groceryNames.Length; i++)
            {
                Console.WriteLine("Please enter grocery name:");
                string groceryName = Console.ReadLine();
                if (groceryName == "exit")
                {
                    k = i;
                    break;
                }
                groceryNames[i] = groceryName;
            }
            PrintNames(groceryNames,k);
        }

        static void PrintNames(string[] items,int z)
        {
            for (int i = 0; i < z; i++)
            {
                Console.WriteLine(items[i]); 
            }
            
        }
    }
}