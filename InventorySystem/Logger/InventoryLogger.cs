using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InventorySystem.Interfaces;

namespace InventorySystem.Logger
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log = new();
        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
        }

        public List<T> GetAll()
        {
            return _log;
        }

        public void SaveToFile()
        {
            try
            {
                // Ensure the folder exists
                var directory = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using var stream = File.Create(_filePath);
                JsonSerializer.Serialize(stream, _log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }


        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("File does not exist. No data loaded.");
                    return;
                }

                using var stream = File.OpenRead(_filePath);
                var items = JsonSerializer.Deserialize<List<T>>(stream);
                _log = items ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }
}
