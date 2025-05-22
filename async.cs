using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp3
{
    class Car
    {
        static async Task Main(string[] args)
        {
            var URL = "";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var task = new List<Task> { onDemandLoading(), onDemandLoadingURL(URL) };
            await Task.WhenAll(task);

            sw.Stop();
            Console.WriteLine("we are done here", sw.Elapsed.TotalSeconds);
        }

        static async Task onDemandLoading()
        {
            Console.WriteLine("1. summoning dog locally");
            try
            {
                string dogText = await File.ReadAllTextAsync(@"C:\Users\kommi\source\repos\ConsoleApp3\Demo.txt");
                Console.WriteLine($"Summoning dog locally:\n{dogText}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: Demo.txt not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task onDemandLoadingURL(string URL)
        {
            Console.WriteLine("OnDemandLoadingfromURL");

            using(var httpClient = new HttpClient())
            {
                string result = await httpClient.GetStringAsync(URL);
                Console.WriteLine($"Summoning dog locally:\n{result}");
            }
        }
    }
}