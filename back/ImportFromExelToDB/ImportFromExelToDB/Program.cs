using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace ImportFromExelToDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileName = @"D:\Загрузки\Данные для аналитики.xlsx";
            object rOnly = true;
            object SaveChanges = false;
            object MissingObj = System.Reflection.Missing.Value;

            Excel.Application app = new Excel.Application();
            Excel.Workbooks workbooks = null;
            Excel.Workbook workbook = null;
            Excel.Sheets sheets = null;
            try
            {
                workbooks = app.Workbooks;
                workbook = workbooks.Open(FileName, MissingObj, rOnly, MissingObj, MissingObj,
                                            MissingObj, MissingObj, MissingObj, MissingObj, MissingObj,
                                            MissingObj, MissingObj, MissingObj, MissingObj, MissingObj);

                // Получение всех страниц докуента
                sheets = workbook.Sheets;

                foreach (Excel.Worksheet worksheet in sheets)
                {
                    // Получаем диапазон используемых на странице ячеек
                    Excel.Range UsedRange = worksheet.UsedRange;
                    // Получаем строки в используемом диапазоне
                    Excel.Range urRows = UsedRange.Rows;
                    // Получаем столбцы в используемом диапазоне
                    Excel.Range urColums = UsedRange.Columns;

                    // Количества строк и столбцов
                    int RowsCount = urRows.Count;
                    int ColumnsCount = urColums.Count;
                    for (int i = 1; i <= RowsCount; i++)
                    {
                        var list = new List<string>();
                        for (int j = 1; j <= ColumnsCount; j++)
                        {
                            
                            Excel.Range CellRange = (Excel.Range)UsedRange.Cells[i, j];
                            // Получение текста ячейки
                            string CellText = (CellRange == null || CellRange.Value2 == null) ? null :
                                                (CellRange as Excel.Range).Value2.ToString();

                        }
                        //Console.WriteLine("__________________");
                        Console.WriteLine(i);
                        var db = new EmployeeDbContext();

                        var employee = new Employee()
                        {
                            Id = Guid.NewGuid(),
                            EmployeeId = Convert.ToInt32(list[0]),
                            Position = new Position() { Name = list[1] },
                            Birthdate = Convert.ToDateTime(list[2]),
                            Gender = new Gender() { Name = list[3] },
                            EmploymentDate = Convert.ToDateTime(list[5]),
                            FamilyStatus = new FamilyStatus() { Name = list[4] },
                            DismissalDate = Convert.ToDateTime(list[6]),
                            Salary = Convert.ToInt32(list[9]),
                            City = new City() { Name = list[10] },
                            ChildrensNumber = Convert.ToInt32(list[11]),
                            Mentor = false,
                        };
                        db.Employees.Add(employee);
                    }
                    // Очистка неуправляемых ресурсов на каждой итерации
                    if (urRows != null) Marshal.ReleaseComObject(urRows);
                    if (urColums != null) Marshal.ReleaseComObject(urColums);
                    if (UsedRange != null) Marshal.ReleaseComObject(UsedRange);
                    if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                }
            }
            catch (Exception ex)
            {
                /* Обработка исключений */
            }
            finally
            {
            }
        }
        
    }
}
