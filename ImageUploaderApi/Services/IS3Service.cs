using ImageUploaderApi.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ImageUploaderApi.Services
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucketAsync(string bucketName);
        Task<S3Response> UploadFileAsync(string bucketName, MemoryStream stream, string ImageKey);

        Task GetObjectFromS3Async(string bucketName, string keyname);
    }
}