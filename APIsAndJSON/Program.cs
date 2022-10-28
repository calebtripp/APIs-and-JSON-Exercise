using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;
using System.Threading;

namespace APIsAndJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var urlWest = "https://api.kanye.rest";
            var urlSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var urlNorris = "https://api.chucknorris.io/jokes/random";

            for (int i = 0; i < 5; i++)
            {
                //Kanye needed to be censored due to public image concerns
                var westResponse = client.GetStringAsync(urlWest).Result;
                var westQ = JObject.Parse(westResponse).GetValue("quote").ToString();
                Console.Write($"Kanye: {westQ}\n");
               Thread.Sleep(1000);

                //var norrisResponse = client.GetStringAsync(urlNorris).Result;
                //var norrisQ = JObject.Parse(norrisResponse).GetValue("value").ToString();
                //Console.Write($"Chuck Norris: {norrisQ}\n");
               Thread.Sleep(1000);

                var swansonQuotes = JArray.Parse(client.GetStringAsync(urlSwanson).Result);                       
                Console.WriteLine($"Ron: {swansonQuotes[0]}");
                Thread.Sleep(1500);                       
            }
        }
    }
}