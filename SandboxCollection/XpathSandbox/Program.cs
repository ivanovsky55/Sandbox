using System;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XpathSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Home_b3072214-bd65-40be-804e-cc014f90a833.html Home_b3072214-bd65-40be-804e-cc014f90a833_es.html
            XDocument xDoc = XDocument.Load(@"C:\Users\v-ivayal\Desktop\xml.xml");

            foreach (var xe in xDoc.XPathSelectElements("//Field"))
            {
                try
                {
                    Console.WriteLine(xe.Attribute("value").Value);
                }
                catch { }
            }

            XDocument xDoc2 = XDocument.Load(@"C:\Users\v-ivayal\Desktop\Home_b3072214-bd65-40be-804e-cc014f90a833.html");
            foreach (var xe in xDoc2.XPathSelectElements("//Field"))
            {
                try
                {
                    Console.WriteLine(xe.Attribute("value").Value);
                }
                catch { }
            }
            Console.ReadLine();

            //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            //doc.Load(@"C:\Users\v-ivayal\Desktop\Home_b3072214-bd65-40be-804e-cc014f90a833.html");
            //string xmlcontents = doc.InnerXml;

            //System.Xml.XmlDocument doc2 = new System.Xml.XmlDocument();
            //doc2.Load(@"C:\Users\v-ivayal\Desktop\Home_b3072214-bd65-40be-804e-cc014f90a833_es.html");
            //string xmlcontents2 = doc2.InnerXml;
            //Console.ReadLine();
            //string locVerLogPath = @"C:\Cloud\SkyDrive\Dropbox\Code\CoolSandbox\XpathSandbox\bin\Debug\locver.log";
            ////Add errors to the result, depending on whether the detailed log exists or not
            //XDocument locVerLogDoc = null;
            //locVerLogDoc = XDocument.Load(locVerLogPath);

            ////If detailed log exists (most common option assuming correct configuration)
            //if (File.Exists(locVerLogPath) && locVerLogDoc != null)
            //{
            //    foreach (var item in locVerLogDoc.XPathSelectElements("//Output"))
            //    {
            //        //Ignore Info messages about starting/finishing
            //        if (item.XPathSelectElement("Message").Value.StartsWith("Starting verification") ||
            //            item.XPathSelectElement("Message").Value.StartsWith("Finished verification"))
            //            continue;

            //        string sourceTerm = "";
            //        var sourceNode = item.XPathSelectElement("Item/SourceText");
            //        if (sourceNode != null) sourceTerm = sourceNode.Value;

            //        string targetTerm = "";
            //        var targetNode = item.XPathSelectElement("Item/Translation");
            //        if (targetNode != null) targetTerm = targetNode.Value;

            //        string errorType = "Warning";
            //        var errorNode = item.XPathSelectElement("Item/Severity");
            //        if (errorNode != null)
            //        {
            //            if (errorNode.Value == "Error1") //REPLACE WITH REAL ERROR CODE
            //                errorType = "Error";
            //        }

            //        string resourceId = "";
            //        var resIdNode = item.XPathSelectElement("Item/Context");
            //        if (resIdNode != null)
            //        {
            //            string fullResId = resIdNode.Value;

            //            string regex = ".*|(.*)";
            //            RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) | RegexOptions.IgnoreCase);
            //            Regex reg = new Regex(regex, options);
            //            var matches = reg.Matches(fullResId);
            //            if (matches.Count > 0)
            //            {
            //                resourceId = matches[0].Groups[1].Value;
            //            }
            //        }

            //    }

            //}
        }
    }
}
