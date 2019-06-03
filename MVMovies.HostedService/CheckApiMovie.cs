using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVMovies.HostedService
{
    public class CheckApiMovie : HostedService
    {
        HttpClient restClient;
        string uploadMoviesUrl = "http://localhost:8869/api/UpdateAllMovies";

        public CheckApiMovie()
        {
            restClient = new HttpClient();
        }


        protected override async Task executeAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                var response = await restClient.GetAsync(uploadMoviesUrl, cToken);
                //Console.WriteLine($"{DateTime.Now.ToString()} Çalışma zamanı taleplerini topluyorum.");


                await Task.Delay(TimeSpan.FromSeconds(600), cToken);
            }
        }
    }
}
