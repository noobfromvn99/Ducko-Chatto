using ImageUploaderApi.Models;
using System.Threading.Tasks;

namespace ImageUploaderApi.Services
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucketAsync(string bucketName);
        Task UploadFileAsync(string bucketName, string filePath, string ImageKey);

        Task GetObjectFromS3Async(string bucketName, string keyname);
    }
}