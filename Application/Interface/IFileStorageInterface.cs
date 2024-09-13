using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFileStorageService
    {
        string SaveFile(byte[] fileContent, string folderName);
        Task<byte[]> LoadFileAsync(string filePath);


    }
}
