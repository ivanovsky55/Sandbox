using ClosedXML.Excel;
using System;

namespace ClosedXmlSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var wbEng = new XLWorkbook(@"C:\Users\v-ivayal\Desktop\EnglishCheck.xlsx");
            var wbLoc = new XLWorkbook(@"C:\Users\v-ivayal\Desktop\LocCheck.xlsx");

            foreach (var wsEng in wbEng.Worksheets)
            {
                var x = wsEng.Cell(7, 6);
                for (int col = 6; col <= 49; col++)
                {

                }
            }

            //var wb = new XLWorkbook();
            //var ws = wb.Worksheets.Add("Test");

            //ws.Cell("A1").Value = "AAA";
            //ws.Cell("A2").Value = "AAA2";

            ////var range = ws.RangeUsed();
            //ws.Range("A4:" + ws.RangeUsed().RangeAddress.LastAddress).SetAutoFilter();
            ////range.SetAutoFilter();

            //ws.Column(1).Width = 5;

            //wb.SaveAs("TestSpreadsheet.xlsx");
            //Console.ReadLine();
        }

        private static void DataValidationTest()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Test");
            ws.Cell("B1").Value = "Yes";
            ws.Cell("B2").Value = "No";

            const int MAX_ROWS = 30000;

            Console.WriteLine(DateTime.Now + " ---- " + "0/" + MAX_ROWS + " rows processed.");
            for (int i = 1; i < MAX_ROWS; i++)
            {
                ws.Cell("A" + i.ToString()).DataValidation.List(ws.Range("B1:B2"));
                if (i % 1000 == 0)
                    Console.WriteLine(DateTime.Now + " ---- " + i + "/" + MAX_ROWS + " rows processed.");
            }
            wb.SaveAs("TestSpreadsheet.xlsx");
            Console.ReadLine();
        }
    }
}
