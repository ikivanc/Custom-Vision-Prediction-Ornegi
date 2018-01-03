using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomVisionPrectionURL
{
    static class Program
    {
        static void Main()
        {
            MakeRequest();
            Console.ReadLine();
        }

        //Test için
        //https://www.tarimdanhaber.com//media/img/7ca03b1f07fd6f3eaa4038ff9d69b197.jpg

        static async void MakeRequest()
        {
            var client = new HttpClient();
       
            // Request headers
            // Buraya Prediction API Key'inizi girebilirsiniz.
            client.DefaultRequestHeaders.Add("Prediction-key", "YOUR PREDICTION KEY");

            Console.Write("Enter image URL: ");
            var imageUrl = Console.ReadLine();

            //Buraya URL ile sorgu yapmayı sağlayan Prediction API endpoint'inizi ekleyin
            var uri = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/b03e07f6-9faa-4a91-b652-745467d3fbd4/url";
            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"Url\": \"" + imageUrl + "\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                //JSON Deserialization
                string jsoncust = response.Content.ReadAsStringAsync().Result;
                CustomVision custobjectVision = JsonConvert.DeserializeObject<CustomVision>(jsoncust);

                //Search objesi için gerekli sonuçların alınması

                Console.WriteLine("---\n\nCustom Vision Detayları");
                foreach (Prediction p in custobjectVision.Predictions)
                {
                    Console.WriteLine(p.Tag + " - " + p.Probability);
                }

                Console.WriteLine("Çıkmak için ENTER 'a basın...");
                Console.ReadLine();
            }

        }
    }
}