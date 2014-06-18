using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GetDataFromErrorLogs
{
    class Program
    {
        static void Main()
        {
            List<string> marketList = new List<string>();
            #region
            marketList.Add("English");
            marketList.Add("Chinese-Simplified");
            marketList.Add("French");
            marketList.Add("Portuguese-Brazil");
            marketList.Add("German");
            marketList.Add("Japanese");
            marketList.Add("Russian");
            marketList.Add("Spanish");
            marketList.Add("Dutch");
            marketList.Add("Swedish");
            marketList.Add("Portuguese");
            marketList.Add("Finnish");
            marketList.Add("Turkish");
            marketList.Add("Chinese-Traditional");
            marketList.Add("Italian");
            marketList.Add("Korean");
            marketList.Add("Polish");
            marketList.Add("Danish");
            marketList.Add("Norwegian");
            marketList.Add("Croatian");
            marketList.Add("Kazakh");
            marketList.Add("Ukrainian");
            marketList.Add("Serbian");
            marketList.Add("Romanian");
            marketList.Add("Lithuanian");
            marketList.Add("Bulgarian");
            marketList.Add("Latvian");
            marketList.Add("Estonian");
            marketList.Add("Hungarian");
            marketList.Add("Slovenian");
            marketList.Add("Hebrew");
            marketList.Add("Slovak");
            marketList.Add("Czech");
            marketList.Add("Thai");
            marketList.Add("Greek");
            marketList.Add("Arabic");
            marketList.Add("Hindi");
            marketList.Add("Vietnamese");
            marketList.Add("Indonesian");
            marketList.Add("Malay");
            marketList.Add("Albanian");
            marketList.Add("Azerbaijani");
            marketList.Add("Belarusian");
            marketList.Add("Catalan");
            marketList.Add("Filipino");
            marketList.Add("Macedonian");
            marketList.Add("Persian");
            marketList.Add("Uzbek");
            marketList.Add("Serbian-Cyrillic");
            marketList.Add("Basque");
            marketList.Add("Malayalam");
            marketList.Add("Marathi");
            marketList.Add("Norwegian-Nynorsk");
            marketList.Add("Tamil");
            marketList.Add("Telugu");
            marketList.Add("Urdu");
            marketList.Add("Welsh");
            marketList.Add("Odia");
            marketList.Add("Amharic");
            marketList.Add("Bangla");
            marketList.Add("Galician");
            marketList.Add("Gujarati");
            marketList.Add("Icelandic");
            marketList.Add("Kannada");
            marketList.Add("Kiswahili");
            #endregion

            List<string> inputFiles = new List<string>();
            foreach (var s in marketList)
            {
                inputFiles.Add(GetLatestLog(@"\\WIN-E5U3RQA9QQH\MigrationTransfer\A2A_Output\OCMS2Dx-" + s));
            }

            //var x = GetLatestLog(@"\\WIN-E5U3RQA9QQH\MigrationTransfer\A2A_Output\OCMS2Dx-Albanian");

            //Merge error log
            const int chunkSize = 2 * 1024; // 2KB
            string outFile = @"C:\Users\v-ivayal\Desktop\Pseudo Trash\AllLogs.txt";
            using (var output = File.Create(outFile))
            {
                foreach (var file in inputFiles)
                {
                    try
                    {
                        using (var input = File.OpenRead(file))
                        {
                            var buffer = new byte[chunkSize];
                            int bytesRead;
                            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                output.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static string GetLatestLog(string languagePath)
        {
            string latestLog = "";

            int highestLogNumber = 0;
            foreach (var logFile in Directory.GetFiles(languagePath, "ocms2dx.*.log"))
            {
                var regex = new Regex(@".*?ocms2dx\.(\d*)\.log");
                var match = regex.Match(logFile);
                int logVersion = Convert.ToInt32((match.Groups[1].Value));
                if (highestLogNumber < logVersion)
                {
                    latestLog = logFile;
                    highestLogNumber = logVersion;
                }
            }

            return latestLog;
        }
    }
}
