using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MonarchsProject.Models;
using Newtonsoft.Json;

namespace MonarchsProject.HttpHandler
{
    public static class HttpRequestHelper
    {
        public static async Task<List<Monarch>> GetJsonKings(string uri, HttpClient httpClient)
        {
            var httpResponse = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();

            try
            {
                var stream = await httpResponse.Content.ReadAsStreamAsync();
                var streamReader = await new StreamReader(stream).ReadToEndAsync();

                var json = JsonConvert.DeserializeObject<List<Monarch>>(streamReader);

                var serializer = new JsonSerializer();

                return json;
            }
            catch (Exception e)
            {
                //In real world, I usually handle IO exceptions much better
                Console.WriteLine(e);
                throw;
            }
        }
    }
}