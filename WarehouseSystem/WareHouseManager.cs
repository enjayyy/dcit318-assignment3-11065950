using System;
using WarehouseSystem.Models;
using WarehouseSystem.Repositories;
using WarehouseSystem.Exceptions;
using WarehouseSystem.Interfaces;

namespace WarehouseSystem
{
    public class WareHouseManager
    {
        private readonly InventoryRepository<ElectronicItem> _electronics = new();
        private readonly InventoryRepository<GroceryItem> _groceries = new();

        public void SeedData()
        {
            try
            {
                _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
                _electronics.AddItem(new ElectronicItem(2, "Smartphone", 15, "Samsung", 12));
                _electronics.AddItem(new ElectronicItem(3, "Tablet", 8, "Apple", 18));

                _groceries.AddItem(new GroceryItem(1, "Milk", 50, DateTime.Now.AddDays(100)));
                _groceries.AddItem(new GroceryItem(2, "Eggs", 100, DateTime.Now.AddDays(30)));
                _groceries.AddItem(new GroceryItem(3, "Bread", 40, DateTime.Now.AddDays(7)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding data: {ex.Message}");
            }
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            foreach (var item in repo.GetAllItems())
            {
                Console.WriteLine(item);
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Increased stock of {item.Name} to {item.Quantity}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error increasing stock: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Item with ID {id} removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing item: {ex.Message}");
            }
        }

        // Expose repositories for Main
        public InventoryRepository<ElectronicItem> Electronics => _electronics;
        public InventoryRepository<GroceryItem> Groceries => _groceries;
    }
}
