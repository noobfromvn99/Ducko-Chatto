using RandomChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RandomChat.Models
{
    public class ImageManger
    {
        private HttpClient client;
        private readonly static ImageManger _instane = new ImageManger();

        private ImageManger() 
        {
            client = ImageApi.InitializeClient();
        }

        public static ImageManger GetInstance() 
        {
            return _instane;
        }

        public async Task<bool> Upload(string path, string imageKey) 
        {
            var response = await client.PostAsync($"api/S3Bucket/AddFile/chatto-images?",
                new JsonContent(
                     new 
                     {
                         filepath = path,
                         ImageKey = imageKey
                     }
                    )
            );
            Console.WriteLine(response.Content) ;
            Console.WriteLine(path);
            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }
    }
}
