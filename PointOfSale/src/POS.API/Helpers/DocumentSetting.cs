﻿namespace POS.API.Helpers;

public static class DocumentSetting
{
    public static string UploadFile(IFormFile file, string folderName)
    {
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Files", folderName);
        
        if(!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string fileName = file.FileName;
        
        string filePath = Path.Combine(folderPath, fileName);

        using FileStream fileStream = new(filePath, FileMode.Create);
        file.CopyTo(fileStream);

        return $"Files/{folderName}/{fileName}";

        //return Path.Combine("Files", folderName, fileName);
    }

    public static bool DeleteFile(string filePath)
    {
        try
        {
            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
                return true; 
            }
            else
            {
                return false; 
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            return false; 
        }
    }
}