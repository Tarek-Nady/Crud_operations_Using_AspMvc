using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace PresentationLayer.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string FolderName)
        {
            #region GetFolderPath

            //string FolderPath = "D:\\Assignments\\Projects\\MvcProject\\PresentationLayer\\wwwroot\\Files\\Images\\";

            //string FolderPath = Directory.GetCurrentDirectory() + "\\wwwroot\\Files" + FolderName;

            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);

            #endregion

            #region GetFileName

            string FileName = $"{Guid.NewGuid()}{file.FileName}";

            #endregion

            #region GetFilePath

            string FilePath = Path.Combine(FolderPath, FileName);

            #endregion

            #region Save File as Streams (Stram :Data Per Time)
            using var Fs = new FileStream(FilePath, FileMode.Create);

            file.CopyTo(Fs);
            #endregion

            return FileName;
        }



        public static void DeleteFile(string FileName,string FolderName) 
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName, FileName);

                if(File.Exists(FilePath))
                   File.Delete(FilePath); 
        
        }
    }
}
