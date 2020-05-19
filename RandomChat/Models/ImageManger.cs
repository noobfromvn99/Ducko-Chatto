using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RandomChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<bool> Upload(IFormFile path, string imageKey) 
        {
            var fileName = ContentDispositionHeaderValue.Parse(path.ContentDisposition).FileName.Trim('"');
            using (var content = new MultipartFormDataContent()) 
            {
                content.Add(new StreamContent(path.OpenReadStream())
                    {
                        Headers =
                        {
                            ContentLength = path.Length,
                            ContentType = new MediaTypeHeaderValue(path.ContentType)
                        }
                    }, "File", fileName);

                var response = await client.PostAsync($"api/S3Bucket/AddFile/chatto-images/{imageKey}", content);
                Console.WriteLine(content);
                if (!response.IsSuccessStatusCode)
                    return false;

                return true;
            }
         

            
        }
    }
}
