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
            var urlSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i < 5; i++)
            {
                var westResponse = client.GetStringAsync(urlWest).Result;
                var westQ = JObject.Parse(westResponse).GetValue("quote").ToString();
                Console.WriteLine($"Kanye: {westQ}\n");

                var swansonResponse = client.GetStringAsync(urlSwanson).Result;
                var swansonQ = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Ron: {swansonQ}\n");

                Console.WriteLine();
            }
        }
    }
}