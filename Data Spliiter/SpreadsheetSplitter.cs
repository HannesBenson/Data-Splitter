using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Data_Spliiter
{
    class SpreadsheetSplitter
    {
        Excel.Application excel;
        Excel.Workbook workbook;
        Excel.Worksheet first_sheet;
        Excel.Range sheet_range;
        
        static object missing = System.Reflection.Missing.Value;
        
        int heading_column_start;
        int heading_column_end;
        int heading_row_start;
        int heading_row_end;
        int start_row;

        string start_col;
        string end_col;
        string output_folder;

        Dictionary<string, string> sheet_and_company_names_dictionary = new Dictionary<string, string>();
        Dictionary<string, string> company_and_sheet_names_dictionary = new Dictionary<string, string>();

        public SpreadsheetSplitter(string filename, string destination_folder)
        {
            excel = new Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;
            workbook = excel.Workbooks.Open(filename, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            first_sheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
            string main_sheet_name = first_sheet.Name;
            output_folder = destination_folder;

            sheet_range = first_sheet.UsedRange;
            heading_column_start = 1;
            heading_column_end = sheet_range.Columns.Count - 1;
            heading_row_start = 1;
            heading_row_end = 2;
            start_row = 3;
            start_col = GetExcelColumnName(heading_column_start);
            end_col = GetExcelColumnName(heading_column_end);
        }

        public bool processHeadings(string range)
        {
            bool valid = true;
            string[] lines = Regex.Split(range, ":");

            int dig_index = -1;
            try
            {
                dig_index = lines[0].IndexOfAny("0123456789".ToCharArray());
                start_col = lines[0].Substring(0, dig_index);
                dig_index = lines[0].IndexOfAny("0123456789".ToCharArray());
                heading_row_start = int.Parse(lines[0].Substring(dig_index, lines[0].Length - dig_index));
                dig_index = lines[1].IndexOfAny("0123456789".ToCharArray());
                end_col = lines[1].Substring(0, dig_index);
                dig_index = lines[1].IndexOfAny("0123456789".ToCharArray());
                heading_row_end = int.Parse(lines[1].Substring(dig_index, lines[1].Length - dig_index));
            }
            catch
            {
                valid = false;
            }
            return valid;
        }

        public void processFile(Label progressLabel, ProgressBar progressBar1)
        {
            progressBar1.Value = 0;
            for (int rCnt = start_row; rCnt <= sheet_range.Rows.Count; rCnt++)
            {
                // check if sheet exists and create it if not
                string target_sheet_name = getValue(sheet_range.Cells[rCnt, sheet_range.Columns.Count]).ToLower();
                createSheetIfItDoesNotExist(target_sheet_name);
                // copy data
                Excel.Worksheet target_sheet = (Excel.Worksheet)workbook.Sheets.get_Item(company_and_sheet_names_dictionary[target_sheet_name]);
                Excel.Range sourceRange = first_sheet.get_Range(start_col + rCnt.ToString(), end_col + rCnt.ToString());
                int number_of_rows_on_target_sheet = target_sheet.UsedRange.Rows.Count;
                Excel.Range destinationRange = target_sheet.get_Range(start_col + (number_of_rows_on_target_sheet + 1).ToString(), end_col + (number_of_rows_on_target_sheet + 1).ToString());
                sourceRange.Copy(Type.Missing);
                destinationRange.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormulas, Microsoft.Office.Interop.Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                progressLabel.Text = "Copied line " + (rCnt - start_row + 1).ToString() + " of " + (sheet_range.Rows.Count - start_row + 1).ToString();
                progressBar1.Value = (rCnt - start_row + 1) * 100 / (sheet_range.Rows.Count - start_row + 1);
            }
            progressBar1.Value = 0;
            for (int counter = 1; counter <= workbook.Worksheets.Count; counter++)
            {
                string sheet_name = ((Excel.Worksheet)excel.Workbooks[1].Sheets[counter]).Name;
                if (sheet_and_company_names_dictionary.ContainsKey(sheet_name))
                {
                    string company_name = sheet_and_company_names_dictionary[sheet_name];
                    Excel.Workbook new_workbook = excel.Workbooks.Add(1);
                    ((Excel.Worksheet)excel.Workbooks[1].Sheets[counter]).Copy(((Excel.Worksheet)new_workbook.Sheets[1]));
                    try
                    {
                        new_workbook.SaveAs(output_folder + "\\" + company_name + ".xlsx");
                    }
                    catch
                    {
                        MessageBox.Show("Could not save " + company_name + ".xlsx. The system does not allow " + company_name + " as a file name!");
                    }
                    progressBar1.Value = counter * 100 / sheet_and_company_names_dictionary.Keys.Count;
                    progressLabel.Text = "Saving file " + counter.ToString() + " of " + sheet_and_company_names_dictionary.Keys.Count;
                }
            }
            MessageBox.Show("All of your files can be found in '" + output_folder + "'.");
            workbook.Close(false, missing, missing);
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(first_sheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            first_sheet = null;
            workbook = null;
            excel = null;
            GC.Collect();
        }

        private string getValue(Excel.Range cell)
        {
            object value = cell.Value;

            string converted_value;

            if (value == null)
            {
                converted_value = "";
            }
            else
            {
                converted_value = value.ToString().Trim();
            }
            return converted_value;
        }

        private void createSheetIfItDoesNotExist(string company_name)
        {
            if (company_name != "")
            {
                //MessageBox.Show(company_name);
                //MessageBox.Show(sheet_and_company_names_dictionary.ContainsKey(company_name).ToString());
                object missing = System.Reflection.Missing.Value;
                if (!company_and_sheet_names_dictionary.ContainsKey(company_name))
                {
                    Excel.Worksheet new_worksheet;
                    new_worksheet = (Excel.Worksheet)workbook.Worksheets.Add(missing, missing, missing, missing);
                    sheet_and_company_names_dictionary.Add(new_worksheet.Name, company_name);
                    company_and_sheet_names_dictionary.Add(company_name, new_worksheet.Name);
                    copyHeadings(first_sheet, new_worksheet, start_col, end_col);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(new_worksheet);
                    new_worksheet = null;
                }
            }
        }

        private void copyHeadings(Excel.Worksheet main_sheet, Excel.Worksheet target_sheet, string start_col, string end_col)
        {
            Excel.Range sourceRange = main_sheet.get_Range(start_col + "1", end_col + "2");
            Excel.Range destinationRange = target_sheet.get_Range(start_col + "1", end_col + "2");

            sourceRange.Copy(Type.Missing);
            destinationRange.PasteSpecial(Microsoft.Office.Interop.Excel.XlPasteType.xlPasteFormulas, Microsoft.Office.Interop.Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;
            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }

        public DataSet getHeadings()
        {
            DataSet headingDataSet = new DataSet();
            DataTable headingTable = headingDataSet.Tables.Add("heading_data");
            
            for (int cCnt = 1; cCnt <= heading_column_end; cCnt++)
            {
                headingTable.Columns.Add(GetExcelColumnName(cCnt), typeof(string));
            }
            for (int rCnt = 1; rCnt < start_row; rCnt++)
            {
                string[] row_data = new string[heading_column_end];
                for (int cCnt = 1; cCnt <= heading_column_end; cCnt++)
                {
                    row_data[cCnt - 1] = getValue(sheet_range.Cells[rCnt, cCnt]);
                }
                headingTable.Rows.Add(row_data);
            }
            return headingDataSet;
        }
    }
}
