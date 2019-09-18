using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.IO;
using System.Dynamic;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Rating_sotr
{
    class Dok
    {
        string low = "Для повышения рейтинга данного сотрудника, нужно провести полную переподготовку к должностным обязанностям, т.к. рейтинг сотрудника предельно низкий.";
        string norm = "Для повышения рейтинга данного сотрудника, нужно провести дополнительные процедуры для подготовки к должностным обязанностям, т.к. рейтинг сотрудника находиться в пределах нормы.";
        string hard = "Данный сотрудник не нуждается в дополнительной подготовке должностных обязанностей, т.к. рейтинг сотрудника выше среднего.";
        private readonly string TemplateFileRaitingSotr = @"C:\Document\Raiting.docx";
        private readonly string TemplateFolderRaitingSotr = @"C:\Document\";
        public Dok(double finalochka, string sotrudnik, int[] lnumss)
        {
            FINALOCHKA = finalochka;
            sotr = sotrudnik;
            lnums = lnumss;
        }

         
        private string sotr;
        private double FINALOCHKA;
        private int[] lnums = new int[20];
        
        SqlConnection sqlConnection;

        public async void DB()
        {
            BD_Edit edit = new BD_Edit();
            string connectionString = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = " + Program.server + "; Integrated Security = True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
            edit.LoadDataCritery();
            SqlConnection connect = new SqlConnection(connectionString);
            string podkl = "SELECT * FROM critery";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            tabl.Load(read);
        }  // Подключение к БД

        public DataTable tabl = new DataTable();

        public void Main()
        {


            MessageBox.Show(FINALOCHKA.ToString());
            MessageBox.Show(sotr);
            for (int i = 0; i < 4; i++)
            {
                MessageBox.Show(lnums[i].ToString());
            }
        } 

        public void Excele()
        {
            DB();
            Excel.Application excelApp = new Excel.Application(); 
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;

            workBook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            workSheet.Name = "Рейтинг" + sotr;
            
            workSheet.Cells[1] = "Фамилия сотрудника";
            workSheet.Cells[2] = "Дата оценки рейтинга";
            workSheet.Cells[3] = "Критерии оценки";
            workSheet.Cells[4] = "Вес критерия";
            workSheet.Cells[5] = "Личные показатели";
            workSheet.Cells[6] = "Результат";
            workSheet.Cells[2, 1] = sotr; 
            workSheet.Cells[2, 2] = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                for (int j = 0; j < tabl.Rows.Count; j++)
                {
                    workSheet.Cells[j + 2, 3] = tabl.Rows[j].Field<string>(1).ToString();
                    workSheet.Cells[j + 2, 4] = tabl.Rows[j].Field<int>(2).ToString();
                    workSheet.Cells[j + 2, 5] = lnums[j];
                    if (workSheet.Cells[j + 2, 5].Text == "0" || workSheet.Cells[j + 2, 5].Text == " ")
                    {
                        Microsoft.Office.Interop.Excel.Range cel = (Excel.Range)workSheet.Rows[j + 2];
                        cel.EntireRow.Delete(Type.Missing);
                    }
                }
                workSheet.Cells[2, 6] = Convert.ToDouble(FINALOCHKA.ToString("0.00"));
            }
            catch
            {

            } 

            try
            {
                for (int i = 1; i < tabl.Rows.Count; i++)
                {
                    if (workSheet.Cells[i, 5].text == "")
                    {
                        workSheet.Range[$"C{i}", $"E{i}"].Rows.Delete(Type.Missing);
                    }
                }
            }
            catch
            { }

            var excelcells = workSheet.get_Range("E2", "E10");
            excelcells.Select();
            Excel.Chart excelchart = (Excel.Chart)excelApp.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelchart.Activate();
            excelchart.Select(Type.Missing);
            excelApp.ActiveChart.ChartType = Excel.XlChartType.xlPie;
            excelApp.ActiveChart.HasTitle = true;
            excelApp.ActiveChart.ChartTitle.Text
                       = "Рейтинг сотрудника";
            excelApp.ActiveChart.FullSeriesCollection(1).XValues = "=Рейтинг" + sotr + "!$C$2:$C$10";

            excelApp.ActiveChart.HasLegend = true;
            excelApp.ActiveChart.Legend.Position
                       = Excel.XlLegendPosition.xlLegendPositionBottom;
            excelApp.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, workSheet.Name);
            var excelsheets = workBook.Worksheets;
            workSheet = (Excel.Worksheet)excelsheets.get_Item(1);
            workSheet.Shapes.Item(1).IncrementLeft(-201);
            workSheet.Shapes.Item(1).IncrementTop((float)20.5);
            workSheet.Shapes.Item(1).Height = 350;
            workSheet.Shapes.Item(1).Width = 300;

            workSheet.Columns.AutoFit();
            excelApp.Visible = true;
            excelApp.UserControl = true;
        } // Формирование Excel отчета

        public void Wordo()
        {
            DB();

            var wordApp = new Word.Application();

            var wordDocument = wordApp.Documents.Open(TemplateFileRaitingSotr);
            
            Object missing = System.Reflection.Missing.Value;

            Word.Paragraph para1 = wordDocument.Content.Paragraphs.Add(ref missing);
            para1.Range.Text = "Фамилия: " + sotr + ";";
            para1.Range.Font.Size = 14;
            para1.Range.Font.Color = Word.WdColor.wdColorBlack;
            para1.Range.Font.Name = "Times New Roman";
            para1.Range.InsertParagraphAfter();

            Word.Paragraph para2 = wordDocument.Content.Paragraphs.Add(ref missing);
            para2.Range.Text = "Дата оценки: " + DateTime.Now.ToString("yyyy-MM-dd") + ";";
            para2.Range.Font.Size = 14;
            para2.Range.Font.Color = Word.WdColor.wdColorBlack;
            para2.Range.Font.Name = "Times New Roman";
            para2.Range.InsertParagraphAfter();

            Word.Paragraph para3 = wordDocument.Content.Paragraphs.Add(ref missing);
            para3.Range.Text = "Результат оценки: " + Convert.ToDouble(FINALOCHKA.ToString("0.00")) + ";";
            para3.Range.Font.Size = 14;
            para3.Range.Font.Color = Word.WdColor.wdColorBlack;
            para3.Range.Font.Name = "Times New Roman";
            para3.Range.InsertParagraphAfter();

            if ( FINALOCHKA > 45)
            {
                Word.Paragraph para5 = wordDocument.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = "Рекомендации: " + hard + "";
                para5.Range.Font.Size = 14;
                para5.Range.Font.Color = Word.WdColor.wdColorBlack;
                para5.Range.Font.Name = "Times New Roman";
                para5.Range.InsertParagraphAfter();
            }
            else
            { }

            if (FINALOCHKA > 20 && FINALOCHKA < 45)
            {
                Word.Paragraph para5 = wordDocument.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = "Рекомендации: " + norm + "";
                para5.Range.Font.Size = 14;
                para5.Range.Font.Color = Word.WdColor.wdColorBlack;
                para5.Range.Font.Name = "Times New Roman";
                para5.Range.InsertParagraphAfter();
            }
            else
            { }

            if (FINALOCHKA < 20)
            {
                Word.Paragraph para5 = wordDocument.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = "Рекомендации: " + low + "";
                para5.Range.Font.Size = 14;
                para5.Range.Font.Color = Word.WdColor.wdColorBlack;
                para5.Range.Font.Name = "Times New Roman";
                para5.Range.InsertParagraphAfter();
            }
            else
            { }

            wordDocument.Save();
            wordApp.Visible = true;
        } // Формирование Word отчета

        public void Pdf()
        {
            DB();
            var pdfApp = new Word.Application();

            var pdfDocument = pdfApp.Documents.Open(TemplateFileRaitingSotr);

            Object missing = System.Reflection.Missing.Value;

            Word.Paragraph para1 = pdfDocument.Content.Paragraphs.Add(ref missing);
            para1.Range.Text = "Фамилия: " + sotr + ";";
            para1.Range.Font.Size = 14;
            para1.Range.Font.Color = Word.WdColor.wdColorBlack;
            para1.Range.Font.Name = "Times New Roman";
            para1.Range.InsertParagraphAfter();

            Word.Paragraph para2 = pdfDocument.Content.Paragraphs.Add(ref missing);
            para2.Range.Text = "Дата оценки: " + DateTime.Now.ToString("yyyy-MM-dd") + ";";
            para2.Range.Font.Size = 14;
            para2.Range.Font.Color = Word.WdColor.wdColorBlack;
            para2.Range.Font.Name = "Times New Roman";
            para2.Range.InsertParagraphAfter();

            Word.Paragraph para3 = pdfDocument.Content.Paragraphs.Add(ref missing);
            para3.Range.Text = "Результат оценки: " + Convert.ToDouble(FINALOCHKA.ToString("0.00")) + ";";
            para3.Range.Font.Size = 14;
            para3.Range.Font.Color = Word.WdColor.wdColorBlack;
            para3.Range.Font.Name = "Times New Roman";
            para3.Range.InsertParagraphAfter();

            if (FINALOCHKA > 65)
            {
                Word.Paragraph para5 = pdfDocument.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = "Рекомендации: " + hard + "";
                para5.Range.Font.Size = 14;
                para5.Range.Font.Color = Word.WdColor.wdColorBlack;
                para5.Range.Font.Name = "Times New Roman";
                para5.Range.InsertParagraphAfter();
            }
            else
            { }

            if (FINALOCHKA > 35 && FINALOCHKA < 65)
            {
                Word.Paragraph para5 = pdfDocument.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = "Рекомендации: " + norm + "";
                para5.Range.Font.Size = 14;
                para5.Range.Font.Color = Word.WdColor.wdColorBlack;
                para5.Range.Font.Name = "Times New Roman";
                para5.Range.InsertParagraphAfter();
            }
            else
            { }

            if (FINALOCHKA < 35)
            {
                Word.Paragraph para5 = pdfDocument.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = "Рекомендации: " + low + "";
                para5.Range.Font.Size = 14;
                para5.Range.Font.Color = Word.WdColor.wdColorBlack;
                para5.Range.Font.Name = "Times New Roman";
                para5.Range.InsertParagraphAfter();
            }
            else
            { }

            pdfDocument.ExportAsFixedFormat(TemplateFolderRaitingSotr + "Raiting_pdf.pdf", Word.WdExportFormat.wdExportFormatPDF);
            pdfDocument.Save();
            pdfApp.Quit();
        }  // Формирование Pdf отчета

    }
}
