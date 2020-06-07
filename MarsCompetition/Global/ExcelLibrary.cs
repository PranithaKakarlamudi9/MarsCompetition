using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using ExcelDataReader;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;

namespace MarsCompetition.Global
{
    //<Summary>
    // This class is reads data from excel sheet and passes into UI elements
    //</summary>
    class ExcelLibrary
    {
        public static List<Datacollection> dataCollection = new List<Datacollection>();

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }

            public static void ClearData()
            {

                dataCollection.Clear();
            }

        }

        public static DataTable ExcelToDataTable(String FileName, String SheetName)
        {
            using (System.IO.FileStream stream = File.Open(FileName, FileMode.Open, FileAccess.Read))
            {
                         
                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    
                    DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    }
         );
                    //Get all the tables
                    DataTableCollection table = result.Tables;

                    //storing in a DataTable
                    DataTable resultTable = table[SheetName];

                    return resultTable;

                }
            }

        }
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
            
              rowNumber = rowNumber-1;
            string data = (from collectionData in dataCollection
                               where collectionData.colName == columnName && collectionData.rowNumber == rowNumber
                               select collectionData.colValue).SingleOrDefault();

                return data.ToString();
          
               
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                return null; }
        }
        public static void PopulateInCollectiion(String FileName, String SheetName)
        {

               Datacollection.ClearData();
            //DataTable table = null;
         DataTable   table = ExcelToDataTable(FileName,SheetName);
           for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCollection.Add(dtTable);
                }
            }



        }
    }
}

    
