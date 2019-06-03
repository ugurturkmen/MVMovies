using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.DataCache
{
    public class CacheHelper
    {
        protected virtual byte[] serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        protected virtual DTO.Movies deserialize(string[] serializedObject)
        {
            if (serializedObject == null)
                return default(DTO.Movies);

            string jsonString = "";
            foreach (var item in serializedObject)
                jsonString += item + ",";
            jsonString = jsonString.Substring(0, jsonString.Length - 1);
            jsonString += "";
            return JsonConvert.DeserializeObject<DTO.Movies>(jsonString);
        }
    }
}
