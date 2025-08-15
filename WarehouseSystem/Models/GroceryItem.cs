﻿using System;
using WarehouseSystem.Interfaces;

namespace WarehouseSystem.Models
{
    public class GroceryItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; }

        public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        public override string ToString()
        {
            return $"[Grocery] ID: {Id}, Name: {Name}, Qty: {Quantity}, Expiry: {ExpiryDate:d}";
        }
    }
}
