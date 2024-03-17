using System;
using System.Net.Http;

namespace ZR.CodingExample.SercureCoding;
class HttpsExample
{
    public static void Main()
    {
        using (var httpClient = new HttpClient())
        {
            // Configure the HttpClient to use HTTPS
            httpClient.BaseAddress = new Uri("https://api.example.com/");

            // Make a secure request
            HttpResponseMessage response = httpClient.GetAsync("endpoint").Result;

            if (response.IsSuccessStatusCode)
            {
                // Process the response
                // ...
                Console.WriteLine("Request successful.");
            }
            else
            {
                // Handle error
                // ...
                Console.WriteLine("Request failed.");
            }
        }
    }
}