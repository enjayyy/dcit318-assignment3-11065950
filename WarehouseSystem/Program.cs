using System;

namespace WarehouseSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new WareHouseManager();
            manager.SeedData();

            Console.WriteLine("\nAll Grocery Items:");
            manager.PrintAllItems(manager.Groceries);

            Console.WriteLine("\nAll Electronic Items:");
            manager.PrintAllItems(manager.Electronics);

            Console.WriteLine("\n--- Testing Exception Handling ---");

            // Duplicate Item
            try
            {
                manager.Electronics.AddItem(new Models.ElectronicItem(1, "Monitor", 5, "LG", 12));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Duplicate test: {ex.Message}");
            }

            // Remove non-existent item
            manager.RemoveItemById(manager.Groceries, 999);

            // Update with invalid quantity
            try
            {
                manager.Electronics.UpdateQuantity(2, -5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid quantity test: {ex.Message}");
            }

            Console.WriteLine("\nDone. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
