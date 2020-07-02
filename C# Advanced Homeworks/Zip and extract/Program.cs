using System;
using System.IO;
using System.IO.Compression;

namespace Zip_and_extract
{
    class Program
    {
        static void Main(string[] args)
        {
            //Copy all files but to diferent upper directory than source

            ZipFile.CreateFromDirectory("./", $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/EntireFolder.zip");

            //Copy a selection of file/s 
            string path = Path.Combine("data", "copyMe.png");
            string dest = Path.Combine("data", "copyMe.zip");
            using (ZipArchive archive = ZipFile.Open(dest, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(path, "copyMe.png");
            }
        }
    }
}
