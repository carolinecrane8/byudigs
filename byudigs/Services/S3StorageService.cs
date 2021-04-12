using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using byudigs.Services;
using Microsoft.AspNetCore.Http;

namespace byudigs.Services
{
    public class S3StorageService : IStorageService
    {
        private readonly AmazonS3Client s3Client;
        private const string BUCKET_NAME = "myBucket";
        private const string FOLDER_NAME = "assets";
        private const double DURATION = 24;
        public S3StorageService()
        {
            s3Client = new AmazonS3Client(RegionEndpoint.USEast2);
        }
        public async Task<string> AddItem(IFormFile file, string readerName)
        {
            // implementation for S3 bucket  
            string fileName = file.FileName;
            string objectKey = $"{FOLDER_NAME}/{fileName}";

            using (Stream fileToUpload = file.OpenReadStream())
            {
                var putObjectRequest = new PutObjectRequest();
                putObjectRequest.BucketName = BUCKET_NAME;
                putObjectRequest.Key = objectKey;
                putObjectRequest.InputStream = fileToUpload;
                putObjectRequest.ContentType = file.ContentType;

                var response = await s3Client.PutObjectAsync(putObjectRequest);

                return GeneratePreSignedURL(objectKey);
            }
        }
        private string GeneratePreSignedURL(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = BUCKET_NAME,
                Key = objectKey,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(DURATION)
            };

            string url = s3Client.GetPreSignedURL(request);
            return url;
        }
    }
}
