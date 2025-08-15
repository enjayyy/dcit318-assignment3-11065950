using System;

namespace InventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Data/inventory.json";

            var app = new InventoryApp(filePath);

            // Seed sample data and save
            app.SeedSampleData();
            app.SaveData();

            // Simulate a new session
            Console.WriteLine("Clearing memory and reloading data...\n");

            var newApp = new InventoryApp(filePath);
            newApp.LoadData();
            newApp.PrintAllItems();

            Console.WriteLine("\nDone. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
