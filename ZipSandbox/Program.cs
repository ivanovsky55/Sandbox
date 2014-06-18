using Ionic.Zip;
using System;
using System.IO;

namespace ZipSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start " + DateTime.Now);
            using (ZipFile zip = new ZipFile())
            {
                foreach (
                    var f in
                        Directory.GetFiles(@"\\win-dfkodv52v1p\A2A_Results\16197_Test\OCMS2Dx-Korean\Acquired\WordML"))
                {
                    zip.AddFile(f, "WordML");
                }
                Console.WriteLine("Zipping " + DateTime.Now);
                zip.Save(@"C:\Users\v-ivayal\Desktop\Pseudo Trash\ZIPTESTWordML.zip");
                Console.WriteLine("Done" + DateTime.Now);
                Console.ReadLine();
            }
        }

        private static void ExtractAllInPath(string inPath, string outPath)
        {
            try
            {
                foreach (string p in Directory.GetFiles(inPath, "*.zip"))
                {
                    using (ZipFile zip = ZipFile.Read(p))
                    {
                        zip.ExtractAll(outPath);
                    }
                }
            }
            catch
            {
                //Console.WriteLine("Error: Files already exist in target directory");
            }
        }
    }
}
