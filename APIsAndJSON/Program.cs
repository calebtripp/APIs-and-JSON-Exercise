using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var urlWest = "https://api.kanye.rest";
            var westResponse = client.GetStringAsync(urlWest).Result;
            var westQ = JObject.Parse(westResponse).GetValue("quote").ToString();

            Console.WriteLine($"{westQ}\n");

            //var urlSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            //var swansonResponse = client.GetStringAsync(urlSwanson).Result;
            //var swansonQ = JObject.Parse(swansonResponse).GetValue("quote").ToString();




            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"{westQ}\n");
            //    Console.WriteLine($"{swansonQ}\n");
            //}

            // Use var  = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
        }
    }
}