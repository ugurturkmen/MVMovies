using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.DataCache
{
    public class RedisCacheManager : CacheHelper, ICacheManager
    {
        private static IDatabase _db;
        private static readonly string host = "localhost";
        private static readonly int port = 6379;

        public RedisCacheManager()
        {
            createRedisDB();
        }

        private static IDatabase createRedisDB()
        {
            try
            {
                if (null == _db)
                {
                    ConfigurationOptions option = new ConfigurationOptions();
                    option.Ssl = false;
                    option.EndPoints.Add(host, port);
                    var connect = ConnectionMultiplexer.Connect(option);
                    _db = connect.GetDatabase();
                }

            }
            catch (Exception ex)
            {

            }
            
            return _db;
        }

        public void clear()
        {
            var server = _db.Multiplexer.GetServer(host, port);
            foreach (var item in server.Keys())
                _db.KeyDelete(item);
        }

        public DTO.Movies get(string key)
        {
            try
            {
                var rValue = _db.SetMembers(key);
                if (rValue.Length == 0)
                    return default(DTO.Movies);

                var result = deserialize(rValue.ToStringArray());
                return result;
            }
            catch (Exception ex)
            {
                return new DTO.Movies();     
            }
           
        }

        public bool isSet(string key)
        {
            return _db.KeyExists(key);
        }

        public bool remove(string key)
        {
            return _db.KeyDelete(key);
        }

        public void removeByPattern(string pattern)
        {
            var server = _db.Multiplexer.GetServer(host, port);
            foreach (var item in server.Keys(pattern: "*" + pattern + "*"))
                _db.KeyDelete(item);
        }

        public void set(string key, object data, int cacheTime)
        {
            try
            {
                if (data == null)
                    return;

                var entryBytes = serialize(data);
                _db.SetAdd(key, entryBytes);

                var expiresIn = TimeSpan.FromMinutes(cacheTime);

                if (cacheTime > 0)
                    _db.KeyExpire(key, expiresIn);
            }
            catch (Exception ex)
            {
                
            }
            
        }
    }
}
