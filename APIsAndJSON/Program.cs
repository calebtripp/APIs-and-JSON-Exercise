using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;
using System.Threading;
using System.Net;

namespace APIsAndJSON
{
    // FAIR WARNING - Quotes are random, some are inappropriate.
    internal class Program
    {
        public delegate string GetQuoteFromResponse(string response);
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var urlWest = "https://api.kanye.rest";
            var urlSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var urlNorris = "https://api.chucknorris.io/jokes/random";

            void PrintQuote(string urlCharacter, GetQuoteFromResponse f, string name)
            {
                var apiResponse = client.GetStringAsync(urlCharacter).Result;
                var quote = f(apiResponse);
                Console.Write($"{name}: {quote}\n");
                Thread.Sleep(1000);
            }

            for (int i = 0; i < 5; i++)
            {
                PrintQuote(urlWest, r => JObject.Parse(r).GetValue("quote").ToString(), "West");
                Thread.Sleep(1000);
                PrintQuote(urlNorris, r => JObject.Parse(r).GetValue("value").ToString(), "Norris");
                Thread.Sleep(1000);
               
            }
        }
    }
}

