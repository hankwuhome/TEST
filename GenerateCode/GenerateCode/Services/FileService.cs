using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Services
{
    static class FileService
    {
        #region Public Methods
        public static void CreatePath(string path)
        {
            System.IO.Directory.CreateDirectory(path);
        }

        public static void CreateFile(string path, string filename, string content)
        {
            try
            {
                string file = Path.Combine(path, filename);

                // Delete the file if it exists.
                if (File.Exists(file))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(file);
                }

                // Create the file.
                using (FileStream fs = File.Create(file))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(content);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                //using (StreamReader sr = File.OpenText(file))
                //{
                //    string s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
