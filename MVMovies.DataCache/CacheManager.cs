using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.DataCache
{
    public class CacheManager : ICacheManager
    {
        private readonly string _cacheType;
        public CacheManager(string CacheType)
        {
            _cacheType = CacheType;
        }

        public void clear()
        {
            if (_cacheType == "Redis")
            {
                ICacheManager manager = new RedisCacheManager();
                manager.clear();
            }
        }

        public DTO.Movies get(string key)
        {
            ICacheManager manager;
            if (_cacheType == "Redis")
            {
                manager = new RedisCacheManager();
            }
            else
            {
                manager = new RedisCacheManager();
            }
            return manager.get(key);
        }

        public bool isSet(string key)
        {
            ICacheManager manager;
            if (_cacheType == "Redis")
            {
                manager = new RedisCacheManager();
            }
            else
            {
                manager = new RedisCacheManager();
            }
            return manager.isSet(key);
        }

        public bool remove(string key)
        {
            ICacheManager manager;
            if (_cacheType == "Redis")
            {
                manager = new RedisCacheManager();
            }
            else
            {
                manager = new RedisCacheManager();
            }
            return manager.remove(key);
        }

        public void removeByPattern(string pattern)
        {
            ICacheManager manager;
            if (_cacheType == "Redis")
            {
                manager = new RedisCacheManager();
            }
            else
            {
                manager = new RedisCacheManager();
            }
            manager.removeByPattern(pattern);
        }

        public void set(string key, object data, int cacheTime)
        {
            ICacheManager manager;
            if (_cacheType == "Redis")
            {
                manager = new RedisCacheManager();
            }
            else
            {
                manager = new RedisCacheManager();
            }
            manager.set(key, data, cacheTime);
        }
    }
}
