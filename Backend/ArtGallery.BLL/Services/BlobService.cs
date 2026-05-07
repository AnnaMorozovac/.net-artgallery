using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

public class BlobService : IBlobService
{
    private readonly string _connectionString;
    private readonly string _containerName;

    public BlobService(IConfiguration config)
    {
        _connectionString = config.GetValue<string>("AzureStorageConfig:ConnectionString");
        _containerName = config.GetValue<string>("AzureStorageConfig:ContainerName");
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        var container = new BlobContainerClient(_connectionString, _containerName);
        var blob = container.GetBlobClient(fileName);

        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });
        return blob.Uri.ToString();
    }
}