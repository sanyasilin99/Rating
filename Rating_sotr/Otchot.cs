using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;

namespace Rating_sotr
{

    public partial class Otchot : MaterialForm
    {
        public Otchot(double finalochka, string sotrudnik, int[] lnumss)
        {
            FINALOCHKA = finalochka;
            sotr = sotrudnik;
            lnums = lnumss;
            InitializeComponent();
            checkBoxes = new List<MaterialCheckBox>();
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
        }
        private string sotr;
        private double FINALOCHKA;
        private int[] lnums = new int[20];

        List<MaterialCheckBox> checkBoxes;
        int[] nums = new int[20];
        BD_Edit DB = new BD_Edit();
        MaterialSkinManager skinManager;
        SqlConnection sqlConnection;

        MaterialCheckBox allCheck, WordChek, ExcelChek, PdfChek;
        MaterialLabel vibvers, vibkrit;
        PictureBox WordImage, ExcelImage, PdfImage;
        MaterialDivider OthDiv;
        MaterialRaisedButton BackBtn, CompleteBtn;

        public DataTable tabl = new DataTable();

        private void ExitImg_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Otchot_Load(object sender, EventArgs e)
        {
            OthDiv = new MaterialDivider
            {
                Location = new Point(-1, 168),
                Size = new Size(565, 11)
            };
            this.Controls.Add(OthDiv);

            allCheck = new MaterialCheckBox
            {
                Text = "Выбрать все",
                Location = new Point(257, 193),
                AutoSize = true
            };  
            allCheck.CheckedChanged += new EventHandler(allcheck_CheckedChanged);
            this.Controls.Add(allCheck);

            WordChek = new MaterialCheckBox
            {
                Text = "",
                Location = new Point(185, 113),
                AutoSize = true
            }; 
            this.Controls.Add(WordChek);

            ExcelChek = new MaterialCheckBox
            {
                Text = "",
                Location = new Point(311, 113),
                AutoSize = true
            }; 
            this.Controls.Add(ExcelChek);

            PdfChek = new MaterialCheckBox
            {
                Text = "",
                Location = new Point(434, 113),
                AutoSize = true
            }; 
            this.Controls.Add(PdfChek);

            Bitmap Word = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\Word.png");

            WordImage = new PictureBox
            {
                Location = new Point(214, 88),
                Size = new Size(77, 67),
                BackgroundImage = Word,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            WordImage.Click += new EventHandler(WordImage_Click);
            this.Controls.Add(WordImage);

            Bitmap Excel = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\Excel.png");

            ExcelImage = new PictureBox
            {
                Location = new Point(340, 88),
                Size = new Size(77, 67),
                BackgroundImage = Excel,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            ExcelImage.Click += new EventHandler(ExcelImage_Click);
            this.Controls.Add(ExcelImage);

            Bitmap Pdf = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\pdf.png");

            PdfImage = new PictureBox
            {
                Location = new Point(463, 88),
                Size = new Size(77, 67),
                BackgroundImage = Pdf,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            PdfImage.Click += new EventHandler(PdfImage_Click);
            this.Controls.Add(PdfImage);

            vibvers = new MaterialLabel
            {
                Location = new Point(23, 105),
                Text = "Выбор формата " +
                "документа",
                AutoSize = true
            };
            this.Controls.Add(vibvers);

            vibkrit = new MaterialLabel
            {
                Location = new Point(22, 197),
                Text = "Выбор критерий для отчета",
                AutoSize = true
            };
            this.Controls.Add(vibkrit);

            BackBtn = new MaterialRaisedButton
            {
                Text = "Отмена",
                Location = new Point(276, 393)
            }; 
            BackBtn.Click += new EventHandler(BackBtn_Click);
            this.Controls.Add(BackBtn);

            CompleteBtn = new MaterialRaisedButton
            {
                Text = "Сформировать отчет",
                Location = new Point(359, 393)
            }; 
            CompleteBtn.Click += new EventHandler(CompleteBtn_Click);
            this.Controls.Add(CompleteBtn);

            string connectionString = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = " + Program.server + "; Integrated Security = True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
            DB.LoadDataCritery();
            SqlConnection connect = new SqlConnection(connectionString);
            string podkl = "SELECT * FROM critery";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            tabl.Load(read);

            int name = 26; 
            int nume = 236; 
           
            for (int i = 0; i < tabl.Rows.Count; i++)
            {
                MaterialCheckBox bt = new MaterialCheckBox();
                bt.Text = tabl.Rows[i][1].ToString();
                bt.AutoSize = true;
                bt.Name = tabl.Rows[i][1].ToString();
                bt.Location = new Point(name, nume);
                Controls.Add(bt);
                nume = nume + 30;
                this.Height = nume + 45;
                BackBtn.Location = new Point(276, nume + 5);
                CompleteBtn.Location = new Point(359, nume + 5);
                checkBoxes.Add(bt);
            } 

            this.vibvers.MaximumSize = new Size(200, 100);

        }

        private void WordImage_Click(object sender, EventArgs e)
        {
            WordChek.Checked = WordChek.Checked == true ? WordChek.Checked = false : WordChek.Checked = true;
        } // Выбор формата отчета

        private void ExcelImage_Click(object sender, EventArgs e)
        {
            ExcelChek.Checked = ExcelChek.Checked == true ? ExcelChek.Checked = false : ExcelChek.Checked = true;
        } // Выбор формата отчета

        private void PdfImage_Click(object sender, EventArgs e)
        {
            PdfChek.Checked = PdfChek.Checked == true ? PdfChek.Checked = false : PdfChek.Checked = true;
        } // Выбор формата отчета

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        } // Закрытие формы

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabl.Rows.Count; i++)
            {
                if (!checkBoxes[i].Checked) { lnums[i] = 0; }
            }

            Dok dok = new Dok(FINALOCHKA, sotr, lnums);
            if (ExcelChek.Checked == true)
            {
                dok.Excele();
            }

            if (WordChek.Checked == true)
            {
                dok.Wordo();
            }

            if (PdfChek.Checked == true)
            {
                dok.Pdf();
            }
        } // Формирование отчета

        private void allcheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (MaterialCheckBox checkBox in checkBoxes)
            {
                checkBox.Checked = checkBox.Checked == true ? checkBox.Checked = false : checkBox.Checked = true;
            }
        } // Выбор всех чек боксов
    }
}
