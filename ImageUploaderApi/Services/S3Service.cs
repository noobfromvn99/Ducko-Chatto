using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using ImageUploaderApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ImageUploaderApi.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _client;

        public S3Service(IAmazonS3 client) 
        {
            _client = client;
        }

        public async Task<S3Response> CreateBucketAsync(string bucketName) 
        {
            try
            {
                if (await AmazonS3Util.DoesS3BucketExistV2Async(_client, bucketName) == false) 
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = bucketName,
                        UseClientRegion = true
                    };

                    var response = await _client.PutBucketAsync(putBucketRequest);

                    return new S3Response
                    {
                        Message = response.ResponseMetadata.RequestId,
                        Status = response.HttpStatusCode
                    };
                }
            }
            catch (AmazonS3Exception s3e)
            {
                return new S3Response
                {
                    Status = s3e.StatusCode,
                    Message = s3e.Message
                };
            }
            catch (Exception e)
            {
                return new S3Response
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
            }


            return new S3Response
            {
                Status = HttpStatusCode.InternalServerError,
                Message = "Something went wrong"
            };
            }

        private const string UploadWithKeyName = "UploadWithKeyName";
        public async Task UploadFileAsync(string bucketName, string filePath)
        {
            try
            {
                var fileTransferUtilty = new TransferUtility(_client);
                //option 2
                await fileTransferUtilty.UploadAsync(filePath, bucketName, UploadWithKeyName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task GetObjectFromS3Async(string bucketName, string keyname)
        {

            try
            {
                var requst = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyname
                };

                string responseBody;

                using (var response = await _client.GetObjectAsync(requst))
                using (var responseStream = response.ResponseStream)
                using (var reader = new StreamReader(responseStream))
                {
                    responseBody = reader.ReadToEnd();
                }

                var pathAndFileName = $"C\\S3Temp\\{keyname}";

                var createText = responseBody;

                File.WriteAllText(pathAndFileName, createText);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }

        }
    }
}
