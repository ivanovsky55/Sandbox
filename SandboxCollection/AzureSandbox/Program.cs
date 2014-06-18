using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        ///// <summary>
        ///// Uploads a blob in a blob container where SAS permission is defined on a blob container using storage client library.
        ///// </summary>
        ///// <param name="blobContainerSasUri"></param>
        //static void UploadBlobWithStorageClientLibrarySasPermissionOnBlobContainer(string blobContainerSasUri)
        //{
        //    CloudBlobContainer blobContainer = new CloudBlobContainer(new Uri(blobContainerSasUri));
        //    CloudBlockBlob blob = blobContainer.GetBlockBlobReference("sample.txt");
        //    string sampleContent = "This is sample text.";
        //    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sampleContent)))
        //    {
        //        blob.UploadFromStream(ms);
        //    }
        //}
    }
}
