using ImageUploaderApi.Models;
using System.Threading.Tasks;

namespace s3Api.Services
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucketAsync(string bucketName);
    }
}