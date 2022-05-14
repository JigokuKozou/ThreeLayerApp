using System;
using System.Collections.Generic;

namespace ThreeLayerApp.DAL
{
    public class MemoryRepo<T> : IRepo<T>
    {
        protected List<T> _items = new();

        public T Add(T item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                return item;
            }
            else
            {
                throw new ArgumentException(nameof(T) + " already exists");
            }
        }

        public T Update(int index, T item)
        {
            if (!IsInRange(index))
                throw new ArgumentOutOfRangeException(nameof(index));

            _items[index] = item;

            return item;
        }

        public IEnumerable<T> GetAll() => _items;

        public bool TryDelete(int index)
        {
            bool isInRange = IsInRange(index);

            if (isInRange)
                _items.RemoveAt(index);

            return isInRange;
        }

        protected bool IsInRange(int index)
            => 0 <= index && index <= _items.Count;
    }
}
