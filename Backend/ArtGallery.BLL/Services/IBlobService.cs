using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBlobService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
}