using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryRepositorySimulator
{
    public class Repository : IRepository
    {
        public Dictionary<object, object> Items = new Dictionary<object, object>();

        public bool Add<TKey, TValue>(TKey key, TValue value)
        {
            try
            {
                if (key == null || value == null) throw new ArgumentNullException($"input parameters cannot be null");

                if (Items.ContainsKey(key)) throw new ArgumentException(nameof(key), $"{key} already exists in the repository"); //key already exists exception

                Items.Add(key, value);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool EmptyAll()
        {
            try
            {
                Items.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TValue Get<TValue>(object key)
        {
            try
            {
                if (!Items.ContainsKey(key)) throw new ArgumentException(nameof(key), $"{key} not found in the repository"); //key not found exception

                if (Items[key].GetType() != typeof(TValue)) throw new InvalidCastException($"output type required is {Items[key].GetType()}");

                return (TValue)Convert.ChangeType(Items[key], typeof(TValue));
            }
            finally { }
        }

        public bool Remove<TKey>(TKey key)
        {
            try
            {
                if (key == null) throw new ArgumentNullException(nameof(key), $"cannot be null");

                if (!Items.ContainsKey(key)) throw new ArgumentException(nameof(key), $"{key} not found in the repository");

                Items.Remove(key);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Count()
        {
            return Items.Count;
        }
    }
}
