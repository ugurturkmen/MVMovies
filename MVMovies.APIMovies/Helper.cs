using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MVMovies.APIMovies
{
    public class Helper
    {
        public string urlGetResponse(string Url)
        {
            string data = "";
            HttpWebRequest request = WebRequest.Create(Url) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                data = reader.ReadToEnd();
            }
            return data;
        }
    }
}
