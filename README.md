# Upload to S3 with .NET AWS SDK

The following code is a simple example of how to upload a file to S3 using the AWS SDK for .NET

The main file to look at is `UploadToS3/Program.cs`. The following Nuget package was installed: `AWSSDK.S3`

You can authenticate yourself in a myriad of ways but this example uses a public/private access key pair and provides those to the SDK by using environment variables. The two variables that need to be set are `AWS_SECRET_ACCESS_KEY` and `AWS_SECRET_ACCESS_KEY`.