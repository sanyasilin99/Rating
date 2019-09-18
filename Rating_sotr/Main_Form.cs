using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Rating_sotr
{

    public partial class Main_Form : MaterialForm
    {
        Arhive arhiv;
        Setting setting;
        string pdkl = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = " + Program.server + "; Integrated Security = True";
        BD_Edit d_Edit = new BD_Edit();
        SqlConnection sqlConnection;
        MaterialSkinManager materialSkinManager;

        public string sotr;
        public int[] nums = new int[11];
        public int[] lnums = new int[11];
        public int[] nums_fact = new int[5];
        public int[] nums_crit = new int[11];

        MaterialLabel NameLbl, SotrLbl, KritLbl, NameKritLbl, OcenSotrLbl, ResultLbl;
        MaterialRaisedButton DiagrammBtn, DBBtn, OcenkaPanelBtn, SettingBtn, ArhiveBtn, AuthBtn, CancelBtn, ContinueBtn, CompleteBtn, OtchetBtn, OcenkaListBtn, SearchBtn, FiltrBtn, DeleteBtn;
        MaterialDivider OcenkaDiv, ListDiv;
        MaterialSingleLineTextField PokazTextBox, SearchTextBox, IdTextBox;
        public ComboBox SotrComBox, FiltrComBox;
        DataGridView OcenkaDtGrView;

        public Main_Form()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void EditTheme_button_Click(object sender, EventArgs e)
        {
        }

        public DataTable tabl = new DataTable();
        public DataTable tabl2 = new DataTable();

        private async void Main_Form_Load(object sender, EventArgs e)
        {
            string path = @"C:\";
            string subpath = @"Document";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);

            AuthBtn = new MaterialRaisedButton
            {
                Text = "Авторизация",
                Location = new Point(542, 24)
            }; 
            AuthBtn.Click += new EventHandler(AuthBtn_Click);
            this.Controls.Add(AuthBtn);

            NameLbl = new MaterialLabel
            {
                Location = new Point(13, 83),
                Text = "Добро пожаловать: " + Program.Name + "!",
                AutoSize = true
            }; 
            this.Controls.Add(NameLbl);

            DBBtn = new MaterialRaisedButton
            {
                Text = "Справочники",
                Location = new Point(16, 125)
            };
            DBBtn.Click += new EventHandler(DBBtn_Click);
            this.Controls.Add(DBBtn);

            OcenkaPanelBtn = new MaterialRaisedButton
            {
                Text = "Определить рейтинг сотрудника",
                Location = new Point(210, 125)
            };
            OcenkaPanelBtn.Click += new EventHandler(OcenkaPanelBtn_Click);
            this.Controls.Add(OcenkaPanelBtn);

            SettingBtn = new MaterialRaisedButton
            {
                Text = "Настройки",
                Location = new Point(558, 75)
            };
            SettingBtn.Click += new EventHandler(SettingBtn_Click);
            this.Controls.Add(SettingBtn);

            ArhiveBtn = new MaterialRaisedButton
            {
                Text = "Архивация",
                Location = new Point(558, 125)
            }; 
            ArhiveBtn.Click += new EventHandler(ArhiveBtn_Click);
            this.Controls.Add(ArhiveBtn);

            SotrComBox = new ComboBox()
            {
                Location = new Point(28, 219),
                Size = new Size(121, 21),
            }; 

            FiltrComBox = new ComboBox()
            {
                Location = new Point(464, 561),
                Size = new Size(171, 21)
            }; 

            OcenkaDtGrView = new DataGridView
            {
                Location = new Point(11, 451),
                Size = new Size(420, 176),
                ReadOnly = true
            };
            OcenkaDtGrView.CellClick += OcenkaDtGrView_CellClick;

            LoadDataOcenka();
            string connectionString = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = " + Program.server + "; Integrated Security = True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
            Select_name_sotr_void();
            Select_ocenka_void();
            d_Edit.LoadDataCritery();
            SqlConnection connect = new SqlConnection(connectionString);
            string podkl = "SELECT * FROM critery";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            tabl.Load(read);

            podkl = "SELECT * FROM factory_critery";
            com = new SqlCommand(podkl, connect);
            read = com.ExecuteReader();
            tabl2.Load(read);

            Height = 168;
        }

        int countCritery = 0;

        private void ExitImg_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                Application.Exit();
            }
        } // Подтверждение выхода

        public double FINALOCHKA;
        public double Factor;

        private void DBBtn_Click(object sender, EventArgs e)
        {
            d_Edit.Show();
            Return();
            this.Close();
        } // Переход к форме справочников

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            Form aut = new Log_Form();
            aut.Show();
            Return();
            this.Hide();
        } // ООткрытие формы авторизации

        private void OcenkaPanelBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
                OcenkaPanelBtn.Enabled = false;
            }
            else
            {
                if (Height != 168)
                {
                    Height = 168;

                    this.Controls.Remove(OcenkaDiv);
                    this.Controls.Remove(SotrLbl);
                    this.Controls.Remove(KritLbl);
                    this.Controls.Remove(NameKritLbl);
                    this.Controls.Remove(OcenSotrLbl);
                    this.Controls.Remove(PokazTextBox);
                    this.Controls.Remove(ContinueBtn);
                    this.Controls.Remove(CompleteBtn);
                    this.Controls.Remove(OcenkaListBtn);
                    this.Controls.Remove(SotrComBox);
                    this.Controls.Remove(OtchetBtn);
                    this.Controls.Remove(CancelBtn);
                }
                else
                {
                    Height = 425;

                    OcenkaDiv = new MaterialDivider
                    {
                        Location = new Point(-3, 176),
                        Size = new Size(680, 10)
                    };
                    this.Controls.Add(OcenkaDiv);

                    SotrLbl = new MaterialLabel
                    {
                        Location = new Point(25, 197),
                        Text = "Сотрудник",
                        AutoSize = true
                    };
                    this.Controls.Add(SotrLbl);

                    KritLbl = new MaterialLabel
                    {
                        Location = new Point(25, 275),
                        Text = "Название критерия",
                        AutoSize = true
                    };
                    this.Controls.Add(KritLbl);

                    NameKritLbl = new MaterialLabel
                    {
                        Location = new Point(24, 301),
                        Text = " ",
                        AutoSize = true
                    }; 
                    this.Controls.Add(NameKritLbl);

                    OcenSotrLbl = new MaterialLabel
                    {
                        Location = new Point(235, 274),
                        Text = "Показатель сотрудника",
                        AutoSize = true
                    };
                    this.Controls.Add(OcenSotrLbl);

                    ResultLbl = new MaterialLabel
                    {
                        Location = new Point(24, 366),
                        Text = "Результат оценки",
                        AutoSize = true
                    };
                    

                    PokazTextBox = new MaterialSingleLineTextField
                    {
                        Location = new Point(239, 301),
                        Size = new Size(175, 23)
                    }; 
                    PokazTextBox.KeyPress += PokazTextBox_KeyPress;
                    this.Controls.Add(PokazTextBox);

                    OtchetBtn = new MaterialRaisedButton
                    {
                        Text = "Сформировать отчет",
                        Location = new Point(484, 358)
                    }; 
                    OtchetBtn.Click += new EventHandler(OtchetBtn_Click);
                    this.Controls.Add(OtchetBtn);

                    CancelBtn = new MaterialRaisedButton
                    {
                        Text = "Отмена",
                        Location = new Point(587, 204)
                    }; 
                    CancelBtn.Click += new EventHandler(CancelBtn_Click);
                    this.Controls.Add(CancelBtn);

                    ContinueBtn = new MaterialRaisedButton
                    {
                        Text = "Далее",
                        Location = new Point(491, 284)
                    };
                    ContinueBtn.Click += new EventHandler(ContinueBtn_Click);
                    this.Controls.Add(ContinueBtn);

                    CompleteBtn = new MaterialRaisedButton
                    {
                        Text = "Завершить",
                        Location = new Point(561, 284)
                    };
                    CompleteBtn.Click += new EventHandler(CompleteBtn_Click);
                    this.Controls.Add(CompleteBtn);

                    OcenkaListBtn = new MaterialRaisedButton
                    {
                        Text = "Просмотреть",
                        Location = new Point(293, 385)
                    };
                    OcenkaListBtn.Click += new EventHandler(OcenkaListBtn_Click);
                    this.Controls.Add(OcenkaListBtn);

                    this.Controls.Add(SotrComBox);

                    PokazTextBox.MaxLength = 1;

                    NameKritLbl.Text = tabl.Rows[0].Field<string>(1).ToString();
                    this.NameKritLbl.MaximumSize = new Size(200, 100);
                }
            }

        } 

        private void SettingBtn_Click(object sender, EventArgs e)
        {
            if (setting == null || setting.IsDisposed)
            {
                setting = new Setting();
                setting.Show();
            }
            else setting.Activate();
        } // Открытие формы настройки

        private void ArhiveBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3" || Program.Dolj == "2")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
                ArhiveBtn.Enabled = false;
            }
            else
            {
                if (arhiv == null || arhiv.IsDisposed)
                {
                    arhiv = new Arhive();
                    arhiv.Show();
                }
                else arhiv.Activate();
            }
        } // Открытие формы архива

        private void Select_name_sotr_void()
        {

                string pdkl = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = Raiting; Integrated Security = True";
                SqlConnection connect = new SqlConnection(pdkl);
                string podkl = "SELECT * FROM sotr";
                SqlCommand com = new SqlCommand(podkl, connect);
                connect.Open();
                SqlDataReader read = com.ExecuteReader();
                DataTable tabl = new DataTable();
                tabl.Load(read);
                SotrComBox.DataSource = tabl;
                SotrComBox.DisplayMember = "f_s";
                SotrComBox.ValueMember = "id_sotr";

        } // Вывод списка сотрудников

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Return();
        } // Отмена действий

        public void Return()
        {
            try
            {
                PokazTextBox.Clear();
                SotrComBox.ResetText();
                NameKritLbl.Text = tabl.Rows[0].Field<string>(1).ToString();
                countCritery = 0;
                Array.Clear(nums, 0, 20);
                Array.Clear(nums_fact, 0, 10);
                Array.Clear(lnums, 0, 20);
                this.Controls.Remove(ResultLbl);
                FINALOCHKA = 0;
                Factor = 0;
                lbl = 0;
                ContinueBtn.Enabled = true;
                OtchetBtn.Enabled = true;
                SotrComBox.Enabled = true;
            }
            catch
            { }
        }  // Отмена действий

        private int lbl = 0;

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            if (PokazTextBox.Text != "")
            {
                try
                {
                    lnums[countCritery] = Convert.ToInt32(PokazTextBox.Text);
                    ++countCritery;
                    for (int i = countCritery - 1; i < countCritery; i++)
                    {
                        nums[i] = Convert.ToInt32(PokazTextBox.Text);
                        nums[i] = (nums[i] * tabl.Rows[i].Field<int>(2));
                        nums_crit[i] = tabl.Rows[i].Field<int>(2);
                    }

                    try
                    {
                        for (int i = countCritery - 1; i < countCritery; i++)
                        {
                            nums_fact[i] = tabl2.Rows[i].Field<int>(2);

                        }
                    }
                    catch
                    {

                    }
                    
                    NameKritLbl.Text = tabl.Rows[countCritery].Field<string>(1).ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Критерии исчерпаны!");
                    ContinueBtn.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле личного показателя сотрудника!");
            }

        }  // Запись личных показателей

        public int[] res = new int[4];
        public int[] resv = new int[4];
        private async void CompleteBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                int ch = 0;
                int chcr = 0;
                ch = nums[i];
                chcr = nums_crit[i];
                res[0] = res[0] + ch;
                resv[0] = resv[0] + chcr;
            }

            for (int i = 2; i < 4; i++)
            {
                int ch = 0;
                int chcr = 0;
                ch = nums[i];
                chcr = nums_crit[i];
                res[1] = res[1] + ch;
                resv[1] = resv[1] + chcr;
            }

            for (int i = 4; i < 6; i++)
            {
                int ch = 0;
                int chcr = 0;
                ch = nums[i];
                chcr = nums_crit[i];
                res[2] = res[2] + ch;
                resv[2] = resv[2] + chcr;
            }

            for (int i = 6; i < 9; i++)
            {
                int ch = 0;
                int chcr = 0;
                ch = nums[i];
                chcr = nums_crit[i];
                res[3] = res[3] + ch;
                resv[3] = resv[3] + chcr;
            }

            for (int i = 0; i < 4; i++)
            {
                res[i] = res[i] / resv[i];
            }

            for (int i = 0; i < 4; i++)
            {
                res[i] = res[i] * nums_fact[i];
            }

            FINALOCHKA = res.Average();

            sotr = SotrComBox.Text;
            try
            {
                if (!string.IsNullOrEmpty(SotrComBox.Text) && !string.IsNullOrWhiteSpace(SotrComBox.Text))  
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [ocenka] (activities_sotr, date_ocenki, id_sotr)VALUES(@activities_sotr, @date_ocenki, @id_sotr)", sqlConnection);

                    command.Parameters.AddWithValue("activities_sotr", Convert.ToDouble(FINALOCHKA.ToString("0.00")));
                    command.Parameters.AddWithValue("date_ocenki", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("id_sotr", SotrComBox.SelectedIndex + 1);

                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Результат оценки добавлен!");

                }
                else
                {
                    MessageBox.Show("Данные не заполнены!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка: Отсутсвие связи с сервером!");
            }
            SotrComBox.Enabled = false;
            this.Controls.Add(ResultLbl);
            ResultLbl.Text = "Результат оценки: " + Convert.ToDouble(FINALOCHKA.ToString("00")) + "!";
            Otchot otchot = new Otchot(FINALOCHKA, sotr, lnums);
            lbl = 1;
            PokazTextBox.Clear();
            LoadDataOcenka();
        } // Расчет рейтинга сотрудника

        private void OtchetBtn_Click(object sender, EventArgs e)
        {
            if (lbl == 1)
            {
                Otchot oth = new Otchot(FINALOCHKA, sotr, lnums);
                oth.Show();
            }
            else
            {
                MessageBox.Show("Процедура расчета рейтинга сотрудника не произведена!");
            }
        } // Открытие формы параметров отчета

        private void OcenkaListBtn_Click(object sender, EventArgs e)
        {
            if (Height != 425)
            {
                Height = 425;
            }
            else
            {
                Height = 631;

                ListDiv = new MaterialDivider
                {
                    Location = new Point(-3, 427),
                    Size = new Size(680, 10)
                };
                this.Controls.Add(ListDiv);

                SearchTextBox = new MaterialSingleLineTextField
                {
                    Location = new Point(464, 485),
                    Size = new Size(170, 23),
                    Hint = "Найти"
                }; // Поле ввода поиска
                this.Controls.Add(SearchTextBox);

                IdTextBox = new MaterialSingleLineTextField
                {
                    Location = new Point(451, 604),
                    Size = new Size(29, 23),
                    Hint = "Код",
                    Enabled = false
                };
                this.Controls.Add(IdTextBox);
                
                this.Controls.Add(FiltrComBox);
              
                this.Controls.Add(OcenkaDtGrView);

                SearchBtn = new MaterialRaisedButton
                {
                    Text = "Поиск",
                    Location = new Point(522, 451)
                }; // Кнопка поиска записи оценки
                SearchBtn.Click += new EventHandler(SearchBtn_Click);
                this.Controls.Add(SearchBtn);

                FiltrBtn = new MaterialRaisedButton
                {
                    Text = "Фильтрация",
                    Location = new Point(499, 521)
                }; // Кнопка фильтрации записи оценки
                FiltrBtn.Click += new EventHandler(FiltrBtn_Click);
                this.Controls.Add(FiltrBtn);

                DeleteBtn = new MaterialRaisedButton
                {
                    Text = "Удалить",
                    Location = new Point(517, 591)
                }; // Кнопка удаления записи оценки
                DeleteBtn.Click += new EventHandler(DeleteBtn_Click);
                this.Controls.Add(DeleteBtn);
            }


        } 

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM ocenka WHERE date_ocenki LIKE '%" + SearchTextBox.Text + "%'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            OcenkaDtGrView.DataSource = tabl;
            OcenkaDtGrView.Columns[0].Visible = false;
            OcenkaDtGrView.Columns[1].Visible = true;
            OcenkaDtGrView.Columns[1].HeaderText = "Рейтинг сотрудника";
            OcenkaDtGrView.Columns[2].Visible = true;
            OcenkaDtGrView.Columns[2].HeaderText = "Дата оценки рейтинга";
            OcenkaDtGrView.Columns[3].Visible = true;
            OcenkaDtGrView.Columns[3].HeaderText = "Код сотрудника";
            OcenkaDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Поиск записи оценки

        private void FiltrBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM ocenka WHERE id_ocenka = '" + FiltrComBox.SelectedValue.ToString() + "'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            OcenkaDtGrView.DataSource = tabl;
            OcenkaDtGrView.Columns[0].Visible = false;
            OcenkaDtGrView.Columns[1].Visible = true;
            OcenkaDtGrView.Columns[1].HeaderText = "Рейтинг сотрудника";
            OcenkaDtGrView.Columns[2].Visible = true;
            OcenkaDtGrView.Columns[2].HeaderText = "Дата оценки рейтинга";
            OcenkaDtGrView.Columns[3].Visible = true;
            OcenkaDtGrView.Columns[3].HeaderText = "Код сотрудника";
            OcenkaDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Фильтрация записей оценки

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(IdTextBox.Text) && !string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [ocenka] WHERE [id_ocenka]=@id_ocenka", sqlConnection);

                    command.Parameters.AddWithValue("id_ocenka", IdTextBox.Text);

                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Результат оценки сотрудника: " + SotrComBox.Text.ToString() + " удален!");
                }
                else
                {
                    MessageBox.Show("Код должен быть заполнен!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка: Введено неверное значение!");
            }
            IdTextBox.Clear();
            LoadDataOcenka();
        } // Удаление записи оценки

        private void PokazTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) 
            {
                e.Handled = true;
            }
        }  // цифры, клавиша BackSpace и запятая


        private void OcenkaDtGrView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            OcenkaDtGrView.Rows[index].Selected = true;

            IdTextBox.Text = OcenkaDtGrView.SelectedCells[0].Value.ToString();
        }  // Запрет на изменение данных внутри ячейки dataGridView

        private void Select_ocenka_void() // Выборка фильтра сортировки в comboBox
        {

            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM ocenka";
            SqlCommand com = new SqlCommand(podkl, sqlConnection);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            FiltrComBox.DataSource = tabl;
            FiltrComBox.DisplayMember = "activities_sotr";
            FiltrComBox.ValueMember = "id_ocenka";
        }

        public void LoadDataOcenka()  // отображение данных из таблицы рейтинг сотрудника
        {
            try
            {
                SqlConnection connect = new SqlConnection(pdkl);
                string podkl = "SELECT * FROM ocenka";
                SqlCommand com = new SqlCommand(podkl, connect);
                connect.Open();
                SqlDataReader read = com.ExecuteReader();
                DataTable tabl = new DataTable();
                tabl.Load(read);
                OcenkaDtGrView.DataSource = tabl;
                OcenkaDtGrView.Columns[0].Visible = false;
                OcenkaDtGrView.Columns[1].Visible = true;
                OcenkaDtGrView.Columns[1].HeaderText = "Рейтинг сотрудника";
                OcenkaDtGrView.Columns[2].Visible = true;
                OcenkaDtGrView.Columns[2].HeaderText = "Дата оценки рейтинга";
                OcenkaDtGrView.Columns[3].Visible = true;
                OcenkaDtGrView.Columns[3].HeaderText = "Код сотрудника";
                OcenkaDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connect.Close();
            }
            catch
            { }
            
        }
    }
}
