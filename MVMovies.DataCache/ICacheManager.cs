using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.DataCache
{
    public interface ICacheManager
    {
        DTO.Movies get(string key);
        void set(string key, object data, int cacheTime);
        bool isSet(string key);
        bool remove(string key);
        void removeByPattern(string pattern);
        void clear();
    }
}
