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
        private const string S3URL = "https://chatto-images.s3.amazonaws.com/";
        private readonly static ImageManger _instane = new ImageManger();

        public static ImageManger GetInstance() 
        {
            return _instane;
        }

        public string GetReplyImageUrl(string imageKey)
        {
            return S3URL + imageKey;
        }

    }
}
