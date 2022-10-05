using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheService
    {
        private IMemoryCache? _memoryCache;

        public MemoryCacheManager()
        {
            var memoryCache = ServiceTool.ServiceProvider?.GetService<IMemoryCache>();
            if (memoryCache != null)
            {
                _memoryCache = memoryCache;
            }
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache != null ? _memoryCache.TryGetValue(key, out _) : false; //out dönmemesi için out _
        }

        public void Remove(string key)
        {
            if (_memoryCache != null)
            {
                _memoryCache.Remove(key); //out dönmemesi için out _
            }
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance);

            var cacheEntriesCollection = cacheEntriesCollectionDefinition?.GetValue(_memoryCache) as dynamic;

            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
            List<object> keysToRemove;

            if (cacheEntriesCollection != null)
            {
                foreach (var cacheItem in cacheEntriesCollection)
                {
                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                    cacheCollectionValues.Add(cacheItemValue);
                }

                var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (cacheCollectionValues != null && _memoryCache != null)
                {
                    keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

                    foreach (var key in keysToRemove)
                    {
                        _memoryCache.Remove(key);
                    }
                }
            }
        }
    }
}
