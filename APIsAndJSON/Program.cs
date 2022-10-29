using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;
using System.Threading;
using System.Net;

namespace APIsAndJSON
{
    // Disclaimer: Take this for what it is - an app to show API calls and function.
    // Quotes are random, the app simulates a conversation that's sometimes funny, sometimes inappropriate. 
    internal class Program
    {
        public delegate string GetQuoteFromResponse(string response);
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var urlSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var urlWest = "https://api.kanye.rest";           
            var urlNorris = "https://api.chucknorris.io/jokes/random";

            void PrintQuote(string speakerEndpoint, GetQuoteFromResponse f, string name)
            {
                var apiResponse = client.GetStringAsync(speakerEndpoint).Result;
                var quote = f(apiResponse);
                Console.Write($"{name}: {quote}\n");
                Thread.Sleep(750);
            }

            for (int i = 0; i < 5; i++)
            {
                PrintQuote(urlSwanson, r => JArray.Parse(r).ElementAt(0).ToString(), "Swanson");
                Thread.Sleep(750);                
                PrintQuote(urlWest, r => JObject.Parse(r).GetValue("quote").ToString(), "West");
                Thread.Sleep(1000);
                PrintQuote(urlNorris, r => JObject.Parse(r).GetValue("value").ToString(), "Norris");
                Thread.Sleep(1000);      
                Console.WriteLine();
            }
        }
    }
}

