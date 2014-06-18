using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AltTextExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sourceFolder = @"C:\Users\v-ivayal\Desktop\Temp\17103_Converts";
            string sourceFolder = @"\\WIN-E5U3RQA9QQH\MigrationTransfer\A2A_Output";
            string outPath = @"\\WIN-E5U3RQA9QQH\MigrationTransfer\A2A_Output";

            var results = new XDocument(new XElement("Assets")).Root;

            foreach (var folder in Directory.GetDirectories(sourceFolder))
            {
                string market = Path.GetFileName(folder).Replace("OCMS2Dx-", "");
                string file = Path.Combine(folder, "ConvertAssets.xml");
                Console.WriteLine("Starting " + market);
                var doc = XDocument.Load(file).Root;
                foreach (var xe in doc.XPathSelectElements("//Asset[contains(AssetId,'ZA')]"))
                {
                    var assetId = TryGetXValue(xe, "AssetId");
                    var altText = TryGetXValue(xe, "Alt");

                    results.Add(new XElement("ZA",
                                    new XElement("Market", market),
                                    new XElement("AssetId", assetId),
                                    new XElement("AltText", altText)));
                }
            }
            results.Save(outPath);
        }
        private static string TryGetXValue(XElement xe, string query)
        {
            string res = "";
            try
            {
                res = xe.XPathSelectElement(query).Value;
            }
            catch (NullReferenceException) { }
            return res;
        }

    }
}
