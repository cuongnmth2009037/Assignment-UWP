using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2009M1HelloUWP.Service
{
    public class FileService
    {
        private static string CloudName = "nguyencuong2903";
        private static string CloudApiKey = "988194674766112";
        private static string CloudApiSecret = "DpS9TTglrF8QI0Q-smPWOIE4uM0";
        static CloudinaryDotNet.Account account;
        static CloudinaryDotNet.Cloudinary cloud;
        public FileService()
        {
            if (account == null)
            {
                account = new CloudinaryDotNet.Account
                {
                    Cloud = CloudName,
                    ApiKey = CloudApiKey,
                    ApiSecret = CloudApiSecret
                };
            }

            if (cloud == null)
            {
                cloud = new CloudinaryDotNet.Cloudinary(account);
                cloud.Api.Secure = true;
            }         
        }
        public async Task<string> UploadFile(Windows.Storage.StorageFile file)
        {
            if (file != null)
            {
                Debug.WriteLine(file.Path);
                CloudinaryDotNet.Actions.RawUploadParams imageUploadParams = new CloudinaryDotNet.Actions.RawUploadParams
                {
                    File = new CloudinaryDotNet.FileDescription(file.Name, await file.OpenStreamForReadAsync())
                };
                Debug.WriteLine("Start upload file.");
                CloudinaryDotNet.Actions.RawUploadResult result = await cloud.UploadAsync(imageUploadParams);
                Debug.WriteLine("Upload file success" + result.SecureUrl.OriginalString);
                return result.SecureUrl.OriginalString;
            }
            Debug.WriteLine("Upload file fails.");
            return null;
        }

    }
}
