using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Runtime.CompilerServices;


namespace HttpClientDemo

{
    class Program
    {
        public static string fileOutput = @"C:\Users\kryst\source\repos\HttpClientDemo\HttpClientDemo\output.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the URL that you want the HTML response from:");
            var url = Console.ReadLine();
            var awaiter = CallURL(url);
            if(awaiter.Result != "")
            {
                File.WriteAllText(fileOutput, awaiter.Result);
                Console.WriteLine("HTML response output to " + fileOutput);
            }
        }

        private static async Task<string> CallURL(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.DefaultRequestHeaders.Accept.Clear(); ;
            var response = client.GetStringAsync(url);
            return await response;
        }
    }
}
