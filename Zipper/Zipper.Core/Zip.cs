using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Zipper.Core
{
    public class Zip
    {
        public static byte[] GetZippedFileAsByteArray(IEnumerable<IFormFile> files)
        {
            byte[] zipFileByteArray;
            
            var zipStream = new MemoryStream();
            zipStream.Seek(0, SeekOrigin.Begin);

            using (ZipArchive zipArchive = new(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in files)
                {
                    var entry = zipArchive.CreateEntry($"{file.FileName}");
                    using (Stream entryStream = entry.Open())
                    {
                        file.CopyTo(entryStream);
                    }
                }
            }

            zipFileByteArray = zipStream.ToArray();
            zipStream.Flush();
            
            return zipFileByteArray;
        }
    }
}
