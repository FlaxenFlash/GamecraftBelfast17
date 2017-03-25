using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Messaging
{
    public class CollectionByType
    {
        private Dictionary<Type, List<object>> _collection = new Dictionary<Type, List<object>>();
        public bool AllowDuplicates { get; set; }

        public void AddItem<T>(T item)
        {
            var type = typeof(T);
            AddItemToCollection(item, type);
        }

        public void AddItem(Type type, object item)
        {
            if (!IsOfType(type, item)) return;
            AddItemToCollection(item, type);
        }

        private void AddItemToCollection<T>(T item, Type type)
        {
            if (!_collection.ContainsKey(type))
            {
                _collection[type] = new List<object>();
            }

            if (!AllowDuplicates && _collection[type].Contains(item))
                return;
            _collection[type].Add(item);
        }

        public bool RemoveItem<T>(T item)
        {
            var type = typeof(T);
            return RemoveItemFromCollection(item, type);
        }

        public bool RemoveItem(Type type, object item)
        {
            if (!IsOfType(type, item)) return false;
            return RemoveItemFromCollection(item, type);
        }

        private bool RemoveItemFromCollection<T>(T item, Type type)
        {
            if (!_collection.ContainsKey(type))
                return false;
            return _collection[type].Remove(item);
        }

        public IEnumerable<T> GetItems<T>()
        {
            var type = typeof(T);
            return !_collection.ContainsKey(type) ? new T[] { } : _collection[type].Cast<T>();
        }

        private bool IsOfType(Type type, object item)
        {
            return type.IsInstanceOfType(item);
        }
    }
}