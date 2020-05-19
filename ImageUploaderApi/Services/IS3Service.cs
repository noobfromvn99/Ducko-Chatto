using ImageUploaderApi.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImageUploaderApi.Services
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucketAsync(string bucketName);
        Task<S3Response> UploadFileAsync(string bucketName, IFormFile filePath, string ImageKey);

        Task GetObjectFromS3Async(string bucketName, string keyname);
    }
}