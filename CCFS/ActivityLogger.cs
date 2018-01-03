using System;
using System.Threading.Tasks;
using PCLStorage;

namespace CCFS
{
    public static class ActivityLogger
    {
        
        public async static Task<string> InitPCLStorage()
        {

            IFolder folder = FileSystem.Current.LocalStorage;
            string fileName = "CGFS_Logger.txt";
            string folderName = "CGFS Database";

            bool IsFolderExist = await PCLStorageHelper.IsFolderExistAsync(folderName, folder);

            if (!IsFolderExist)
            {
                await PCLStorageHelper.CreateFolder(folderName, folder);
                Console.WriteLine("PCL Storage Folder Created");

                bool IsFileExist = await PCLStorageHelper.IsFileExistAsync(fileName, await folder.GetFolderAsync(folderName));

                if (!IsFileExist && await PCLStorageHelper.IsFolderExistAsync(folderName, folder))
                {
                    await PCLStorageHelper.CreateFile(fileName, await folder.GetFolderAsync(folderName));
                    Console.WriteLine("PCL Storage File Created");
                    return "File Created";

                }
                else
                {
                    Console.WriteLine("PCL Storage File exist");
                    Console.WriteLine("Writing data in PCLS");
                    IFolder existFolder = await folder.GetFolderAsync(folderName);
                    IFile existFile = await existFolder.GetFileAsync(fileName);

                    DateTime localDate = DateTime.Now;
                    //await PCLStorageHelper.WriteTextAllAsync(existFile, "Thimira");
                    await PCLStorageHelper.AppendAllTextAsync(existFile, localDate.ToString() + " : " + "CGFS Ap Launched");

                    return "Data Writed";

                }
            }
            else
            {
                Console.WriteLine("PCL Storage Folder Exist");

                bool IsFileExist = await PCLStorageHelper.IsFileExistAsync(fileName, await folder.GetFolderAsync(folderName));

                if (!IsFileExist && await PCLStorageHelper.IsFolderExistAsync(folderName, folder))
                {
                    await PCLStorageHelper.CreateFile(fileName, await folder.GetFolderAsync(folderName));
                    Console.WriteLine("PCL Storage File Created");
                    return "File Created";
                }
                else
                {
                    Console.WriteLine("PCL Storage File exist");
                    IFolder existFolder = await folder.GetFolderAsync(folderName);
                    IFile existFile = await existFolder.GetFileAsync(fileName);

                    DateTime localDate = DateTime.Now;
                    //await PCLStorageHelper.WriteTextAllAsync(existFile, "Thimira");
                    await PCLStorageHelper.AppendAllTextAsync(existFile, localDate.ToString() + " : " + "CGFS App Launched");

                    return "Data Writed";
                }
            }

        }

        public static async void AddLogger(string activity){
            IFolder folder = FileSystem.Current.LocalStorage;
            string fileName = "CGFS_Logger.txt";
            string folderName = "CGFS Database";

            IFolder existFolder = await folder.GetFolderAsync(folderName);
            IFile existFile = await existFolder.GetFileAsync(fileName);

            DateTime localDate = DateTime.Now;
            //await PCLStorageHelper.WriteTextAllAsync(existFile, "Thimira");
            await PCLStorageHelper.AppendAllTextAsync(existFile, localDate.ToString()+" : " + activity);
        }

        public static async Task<string> ReadLogger()
        {
            IFolder folder = FileSystem.Current.LocalStorage;
            string fileName = "CGFS_Logger.txt";
            string folderName = "CGFS Database";

            IFolder existFolder = await folder.GetFolderAsync(folderName);

            return await PCLStorageHelper.ReadAllTextAsync(fileName, existFolder);
        }

        public static async Task<bool> ClearLogger(){

            ActivityLogger.AddLogger("Clear Activity Logger");
            Console.WriteLine("Clear Activity Logger");

            IFolder folder = FileSystem.Current.LocalStorage;
            string fileName = "CGFS_Logger.txt";
            string folderName = "CGFS Database";

            IFolder existFolder = await folder.GetFolderAsync(folderName);

            bool b = await PCLStorageHelper.DeleteFile(fileName, existFolder);

            if(b){
                await InitPCLStorage();
                return true;
            }else{
                return false;
            }
        }

    }


}
