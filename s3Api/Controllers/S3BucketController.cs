using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using s3Api.Services;

namespace s3Api.Controllers
{
    [Produces("application/json")]
    [Route("api/S3Bucket")]
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

        [Route("test")]
        public IActionResult test() 
        {
            return Ok();
        }
    }
}