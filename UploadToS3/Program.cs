// See https://aka.ms/new-console-template for more information

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Threading.Tasks;

namespace Amazon.DocSamples.S3
{
    class UploadObjectTest
    {
        // These variables will be supplied by 10East and dictate what S3 bucket your files will be uploaded to and where they will be placed in the bucket.
        private const string bucketName = "member-documents101729-djozdev";
        private const string destinationPrefix = "private/fourpines/pending/";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1; 

        private static IAmazonS3 client;

        public static void Main()
        {
            // Initialize the S3 client, make sure your AWS_ACCESS_KEY_ID and AWS_SECRET_ACCESS_KEY environment variables are set or the upload will fail.
            client = new AmazonS3Client(bucketRegion);
            
            WritingAnObjectAsync(
                "David Jozwik - Testing Fund, LP PCAP Statement Q3 2022.docx", 
                @"C:\Users\10East\OneDrive\Desktop\David Jozwik - Testing Fund, LP PCAP Statement Q3 2022.docx"
                ).Wait();
        }

        static async Task WritingAnObjectAsync(string destinationName, string localFilePath)
        {
            try
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = destinationPrefix + destinationName,
                    FilePath = localFilePath
                };
                // Attach some custom metadata, such as an email, to the object here. Which accepts key value pairs. Must be prefixed with "x-amz-meta-". Can set up to 50 key/value pairs.
                putRequest.Metadata.Add("x-amz-meta-email", "john-tester-email@nonexistent123testing.com");
                PutObjectResponse response1 = await client.PutObjectAsync(putRequest);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }
        }
    }
}