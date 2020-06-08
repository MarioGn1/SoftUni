using System;
using System.IO;

namespace Copy_Binary_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "copyMe.png");
            string dest = Path.Combine("data", "SoftUniLogo.png");
            using (FileStream readFile = new FileStream(path, FileMode.Open))
            {
                using (FileStream copyFile = new FileStream(dest, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    
                    while (true)
                    {
                        int counter = readFile.Read(buffer, 0, buffer.Length);
                        if (counter == 0 )
                        {
                            break;
                        }
                        copyFile.Write(buffer);
                    }
                }
            }
        }
    }
}
