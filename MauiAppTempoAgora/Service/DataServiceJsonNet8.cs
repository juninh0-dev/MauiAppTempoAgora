using MauiAppTempoAgora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace MauiAppTempoAgora.Service
{
    internal class DataServiceJsonNet8
    {
        public static async Task<Tempo?> GetPrevisaoDoTempo(string cidade)
        {
            string appId = "6135072afe7f6cec1537d5b08a5a1a2";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q=" +
                         $"{cidade}&units=metric&appid={appId}";

            Tempo tempo = null;

            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode) 
                { 
                    string json = response.Content.ReadAsStringAsync().Result;

                    Debug.WriteLine("-----------------------------------------------------------");
                    Debug.WriteLine(json);
                    Debug.WriteLine("-----------------------------------------------------------");
                
                    var rascunho = JObject.Parse(json);

                    Debug.WriteLine("-----------------------------------------------------------");

                    DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime sunrise = time.AddSeconds((double)rascunho["sys"]["sunrise"]).ToLocalTime();
                    DateTime sunset = time.AddSeconds((double)rascunho["sys"]["sunset"]).ToLocalTime();
                }
            }

        }
    }
}
