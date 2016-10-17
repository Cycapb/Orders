using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using Domain;

namespace Businesslogic
{
    public class OrdersToExcelUnloader:IUnloader<OrderToUnload>
    {
        public string Unload(IEnumerable<OrderToUnload> items)
        {
            var fileName = System.IO.Path.GetTempPath() + @"\Orders.xlsx";
            var workBook = new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("Orders");
            workSheet.Cell("A1").Value = "Order_ID";
            workSheet.Cell("B1").Value = "Order_Date";
            workSheet.Cell("C1").Value = "Product_ID";
            workSheet.Cell("D1").Value = "Product_Name";
            workSheet.Cell("E1").Value = "Quantity";
            workSheet.Cell("F1").Value = "Unit_Price";
            workSheet.Cell("G1").Value = "Position_Price";

            workSheet.Cell(2, 1).Value = items;

            var rngTable = workSheet.Range("A1:G1");
            var rngHeaders = rngTable.Range("A1:G1");
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.FontColor = XLColor.DarkBlue;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

            var rowcount = workSheet.RowCount() >= 65535? 65534 : workSheet.RowCount();

            for (int i = 2; i <= rowcount; i++)
            {
                var currentCell = "G" + i;
                var totalPrice = "=E" + i + "*" + "F" + i;
                workSheet.Cell(currentCell).FormulaA1 = totalPrice;
            }

            try
            {
                workBook.SaveAs(fileName);
            }
            catch (Exception)
            {
                fileName = System.IO.Path.GetTempPath() + @"\Orders" + DateTime.Now + ".xlsx"; ;
            }
            
            return fileName;
        }
    }
}