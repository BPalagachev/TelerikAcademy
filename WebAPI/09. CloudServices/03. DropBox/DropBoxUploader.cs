using Spring.IO;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.Social.OAuth1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DropBox
{
    class DropBoxUploader
    {
        private const string DropboxAppKey = "wkbe4x03hza334g";
        private const string DropboxAppSecret = "1ucy36z7y6kga2k";

        static void Main(string[] args)
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            OAuthToken oauthAccessToken = new OAuthToken("9gyo6l0xq3l7kdd0", "ly7ayinrqbocfy8");

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            // Create new folder
            string newFolderName = "New_Folder_" + DateTime.Now.Ticks;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;

            var filePath = GetUserInput("Enter file path: ");
            var fileName = filePath.Substring(filePath.LastIndexOf('/', filePath.Length));
            // Upload a file
            IResource fileResource = new FileResource(filePath);
            Entry uploadFileEntry = dropbox.UploadFileAsync(fileResource,
                "/" + newFolderName + "/" + fileName).Result;

            // Share a file
            DropboxLink sharedUrl = dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;
        }

        static string GetUserInput(string message)
        {
            Console.Write(message);
            var result = Console.ReadLine();
            return result;
        }
    }
}
