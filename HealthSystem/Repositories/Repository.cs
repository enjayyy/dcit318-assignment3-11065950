using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthSystem.Repositories
{
    public class Repository<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public List<T> GetAll() => new List<T>(_items);

        public T? GetById(Func<T, bool> predicate)
            => _items.FirstOrDefault(predicate);

        public bool Remove(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item != null)
            {
                _items.Remove(item);
                return true;
            }
            return false;
        }
    }
}
