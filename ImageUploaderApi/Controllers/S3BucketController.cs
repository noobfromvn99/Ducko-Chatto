using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageUploaderApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploaderApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class S3BucketController : ControllerBase
    {
        private readonly IS3Service _service;

        public S3BucketController(IS3Service service)
        {
            _service = service;
        }


        [HttpPost("create/{bucketName}")]
        public async Task<IActionResult> CreateBucket([FromRoute] string bucketName)
        {
            var response = await _service.CreateBucketAsync(bucketName);

            return Ok(response);
        }

        [HttpPost]
        [Route("AddFile/{bucketName}/{ImageKey}")]
        public async Task<IActionResult> AddFile([FromRoute] string bucketName, IFormFile file, [FromRoute] string ImageKey){
            var response =  await _service.UploadFileAsync(bucketName, file, ImageKey);

            return Ok(response);
        }

        [HttpPost]
        [Route("GetFile/{bucketName}")]
        public async Task<IActionResult> GetObjectFromS3Async([FromRoute] string bucketName, string keyname)
        {
            await _service.GetObjectFromS3Async(bucketName, keyname);

            return Ok();
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test() 
        {
            return Ok();
        }
    }
}