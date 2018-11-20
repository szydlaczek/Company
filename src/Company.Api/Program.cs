using Microsoft.Owin.Hosting;
using System;

namespace CompanySelf.Api
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url = "http://localhost:8005";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"Web Server is running at {url}");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}