using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bcrypt = BCrypt.Net.BCrypt;
using Rating_sotr.Properties;


namespace Rating_sotr
{
    public partial class BD_Edit : MaterialForm
    {

        string pdkl = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = " + Program.server + "; Integrated Security = True";
        public DataTable tabl = new DataTable();
        MaterialSkinManager skinManager;
        SqlConnection sqlConnection;

        MaterialRaisedButton GlavnBtn, ExitBtn, SearchCriteryBtn, FiltrCriteryBtn, AddCriteryBtn, UpdateCriteryBtn, DeleteCriteryBtn,
                                                SearchFactoryBtn, FiltrFactoryBtn, AddFactoryBtn, UpdateFactoryBtn, DeleteFactortyBtn,
                                                SearchSotrBtn, FiltrSotrBtn, AddSotrBtn, UpdateSotrBtn, DeleteSotrBtn,
                                                SearchDoljBtn, FiltrDoljBtn, AddDoljBtn, UpdateDoljBtn, DeleteDoljBtn;
        MaterialSingleLineTextField SearchCriteryTextBox, IDCriteryTextBox, NameCriteryTextBox, VesCriteryTextBox, IDFactoryCriteryTextBox,
                                    SearchFactoryTextBox, IDFactoryTextBox, NameFactoryTextBox, VesFactoryTextBox,
                                    SearchSotrTextBox, IDSotrTextBox, LogSotrTextBox, PassSotrTextBox, NameSotrTextBox, FamileSotrTextBox, OtchSotrTextBox, DoljSotrTextBox,
                                    SearchDoljTextBox, IDDoljTextBox, NameDoljTextBox;
        ComboBox CriteryComBox, FactoryComBox, SotrComBox, DoljComBox;

        private void ExitImg_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                Application.Exit();
            }
        } // Подтверждение выхода

        DataGridView CriteryDtGrView, FactoryDtGrView, SotrDtGrView, DoljDtGrView;
        MaterialTabControl DBTbControl;

        MaterialTabSelector DBTbSelect;
        public BD_Edit()
        {
            InitializeComponent();
            this.Size = new Size(766, 378);
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
        }


        private async void BD_Edit_Load(object sender, EventArgs e) // подключение к БД
        {
            GlavnBtn = new MaterialRaisedButton
            {
                Text = "Главная",
                Location = new Point(663, 26)
            }; 
            GlavnBtn.Click += new EventHandler(GlavnBtn_Click);
            this.Controls.Add(GlavnBtn);

            SearchCriteryBtn = new MaterialRaisedButton
            {
                Text = "Найти",
                Location = new Point(632, 5)
            }; 
            SearchCriteryBtn.Click += new EventHandler(SearchCriteryBtn_Click);

            SearchFactoryBtn = new MaterialRaisedButton
            {
                Text = "Найти",
                Location = new Point(632, 5)
            }; 
            SearchFactoryBtn.Click += new EventHandler(SearchFactoryBtn_Click);

            SearchSotrBtn = new MaterialRaisedButton
            {
                Text = "Найти",
                Location = new Point(632, 5)
            }; 
            SearchSotrBtn.Click += new EventHandler(SearchSotrBtn_Click);

            SearchDoljBtn = new MaterialRaisedButton
            {
                Text = "Найти",
                Location = new Point(632, 5)
            }; 
            SearchDoljBtn.Click += new EventHandler(SearchDoljBtn_Click);

            FiltrCriteryBtn = new MaterialRaisedButton
            {
                Text = "Фильтрация",
                Location = new Point(609, 75)
            }; 
            FiltrCriteryBtn.Click += new EventHandler(FiltrCriteryBtn_Click);

            FiltrFactoryBtn = new MaterialRaisedButton
            {
                Text = "Фильтрация",
                Location = new Point(609, 75)
            };
            FiltrFactoryBtn.Click += new EventHandler(FiltrFactoryBtn_Click);


            FiltrSotrBtn = new MaterialRaisedButton
            {
                Text = "Фильтрация",
                Location = new Point(609, 75)
            }; 
            FiltrSotrBtn.Click += new EventHandler(FiltrSotrBtn_Click);

            FiltrDoljBtn = new MaterialRaisedButton
            {
                Text = "Фильтрация",
                Location = new Point(609, 75)
            }; 
            FiltrDoljBtn.Click += new EventHandler(FiltrDoljBtn_Click);

            AddCriteryBtn = new MaterialRaisedButton
            {
                Text = "Добавить",
                Location = new Point(620, 151)
            };
            AddCriteryBtn.Click += new EventHandler(AddCriteryBtn_Click);

            AddFactoryBtn = new MaterialRaisedButton
            {
                Text = "Добавить",
                Location = new Point(620, 151)
            }; 
            AddFactoryBtn.Click += new EventHandler(AddFactoryBtn_Click);

            AddSotrBtn = new MaterialRaisedButton
            {
                Text = "Добавить",
                Location = new Point(620, 151)
            }; 
            AddSotrBtn.Click += new EventHandler(AddSotrBtn_Click);

            AddDoljBtn = new MaterialRaisedButton
            {
                Text = "Добавить",
                Location = new Point(620, 151)
            }; 
            AddDoljBtn.Click += new EventHandler(AddDoljBtn_Click);

            UpdateCriteryBtn = new MaterialRaisedButton
            {
                Text = "Изменить",
                Location = new Point(567, 217)
            }; 
            UpdateCriteryBtn.Click += new EventHandler(UpdateCriteryBtn_Click);

            UpdateFactoryBtn = new MaterialRaisedButton
            {
                Text = "Изменить",
                Location = new Point(567, 217)
            }; 
            UpdateFactoryBtn.Click += new EventHandler(UpdateFactoryBtn_Click);

            UpdateSotrBtn = new MaterialRaisedButton
            {
                Text = "Изменить",
                Location = new Point(567, 217)
            };
            UpdateSotrBtn.Click += new EventHandler(UpdateSotrBtn_Click);

            UpdateDoljBtn = new MaterialRaisedButton
            {
                Text = "Изменить",
                Location = new Point(567, 217)
            }; 
            UpdateDoljBtn.Click += new EventHandler(UpdateDoljBtn_Click);

            DeleteCriteryBtn = new MaterialRaisedButton
            {
                Text = "Удалить",
                Location = new Point(666, 217)
            };
            DeleteCriteryBtn.Click += new EventHandler(DeleteCriteryBtn_Click);

            DeleteFactortyBtn = new MaterialRaisedButton
            {
                Text = "Удалить",
                Location = new Point(666, 217)
            }; 
            DeleteFactortyBtn.Click += new EventHandler(DeleteFactortyBtn_Click);

            DeleteSotrBtn = new MaterialRaisedButton
            {
                Text = "Удалить",
                Location = new Point(666, 217)
            }; 
            DeleteSotrBtn.Click += new EventHandler(DeleteSotrBtn_Click);

            DeleteDoljBtn = new MaterialRaisedButton
            {
                Text = "Удалить",
                Location = new Point(666, 217)
            }; 
            DeleteDoljBtn.Click += new EventHandler(DeleteDoljBtn_Click);

            SearchCriteryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(574, 39),
                Size = new Size(170, 23),
                Hint = "Найти"
            }; 

            SearchFactoryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(574, 39),
                Size = new Size(170, 23),
                Hint = "Найти"
            }; 

            SearchSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(574, 39),
                Size = new Size(170, 23),
                Hint = "Найти"
            };

            SearchDoljTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(574, 39),
                Size = new Size(170, 23),
                Hint = "Найти"
            };

            IDCriteryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(11, 219),
                Size = new Size(29, 23),
                Hint = "Код",
                Enabled = false
            }; 

            IDFactoryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(11, 219),
                Size = new Size(29, 23),
                Hint = "Код",
                Enabled = false
            }; 

            IDSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(4, 213),
                Size = new Size(29, 23),
                Hint = "Код",
                Enabled = false
            }; 

            IDDoljTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(11, 219),
                Size = new Size(29, 23),
                Hint = "Код",
                Enabled = false
            };

            NameCriteryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(43, 219),
                Size = new Size(346, 23),
                Hint = "Название критерия"
            };

            NameFactoryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(43, 219),
                Size = new Size(346, 23),
                Hint = "Название фактора"
            }; 

            NameDoljTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(43, 219),
                Size = new Size(346, 23),
                Hint = "Название должности"
            };

            IDFactoryCriteryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(473, 219),
                Size = new Size(76, 23),
                Hint = "Фактор"
            };

            VesCriteryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(410, 219),
                Size = new Size(31, 23),
                Hint = "Вес"
            };
            VesCriteryTextBox.KeyPress += VesCriteryTextBox_KeyPress;

            VesFactoryTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(410, 219),
                Size = new Size(31, 23),
                Hint = "Вес"
            }; 
            VesFactoryTextBox.KeyPress += VesFactoryTextBox_KeyPress;

            LogSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(69, 213),
                Size = new Size(109, 23),
                Hint = "Логин"
            };

            PassSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(203, 213),
                Size = new Size(109, 23),
                Hint = "Пароль",
                PasswordChar = '*'
            };

            NameSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(203, 240),
                Size = new Size(109, 23),
                Hint = "Имя"
            }; 

            FamileSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(4, 240),
                Size = new Size(109, 23),
                Hint = "Фамилия"
            }; 

            OtchSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(391, 240),
                Size = new Size(115, 23),
                Hint = "Отчество"
            }; 

            DoljSotrTextBox = new MaterialSingleLineTextField
            {
                Location = new Point(391, 213),
                Size = new Size(87, 23),
                Hint = "Должность"
            }; 

            CriteryDtGrView = new DataGridView
            {
                Location = new Point(4, 5),
                Size = new Size(545, 199),
                ReadOnly = true
            }; 
            CriteryDtGrView.CellClick += CriteryDtGrView_CellClick;

            FactoryDtGrView = new DataGridView
            {
                Location = new Point(4, 5),
                Size = new Size(545, 199),
                ReadOnly = true
            }; 
            FactoryDtGrView.CellClick += FactoryDtGrView_CellClick;

            SotrDtGrView = new DataGridView
            {
                Location = new Point(4, 5),
                Size = new Size(545, 199),
                ReadOnly = true
            }; 
            SotrDtGrView.CellClick += SotrDtGrView_CellClick;

            DoljDtGrView = new DataGridView
            {
                Location = new Point(4, 5),
                Size = new Size(545, 199),
                ReadOnly = true
            }; 
            DoljDtGrView.CellClick += DoljDtGrView_CellClick;

            CriteryComBox = new ComboBox()
            {
                Location = new Point(574, 119),
                Size = new Size(171, 21),
            }; 

            FactoryComBox = new ComboBox()
            {
                Location = new Point(574, 119),
                Size = new Size(171, 21),
            }; 

            SotrComBox = new ComboBox()
            {
                Location = new Point(574, 119),
                Size = new Size(171, 21),
            }; 

            DoljComBox = new ComboBox()
            {
                Location = new Point(574, 119),
                Size = new Size(171, 21),
            };

            DBTbControl = new MaterialTabControl
            {
                Location = new Point(-2, 90),
                Size = new Size(766, 283),

            };
            TabPage critery = new TabPage("Критерии");
            critery.Controls.Add(SearchCriteryBtn);
            critery.Controls.Add(FiltrCriteryBtn);
            critery.Controls.Add(AddCriteryBtn);
            critery.Controls.Add(UpdateCriteryBtn);
            critery.Controls.Add(DeleteCriteryBtn);
            critery.Controls.Add(SearchCriteryTextBox);
            critery.Controls.Add(IDCriteryTextBox);
            critery.Controls.Add(NameCriteryTextBox);
            critery.Controls.Add(VesCriteryTextBox);
            critery.Controls.Add(IDFactoryCriteryTextBox);
            critery.Controls.Add(CriteryDtGrView);
            critery.Controls.Add(CriteryComBox);
            TabPage factory = new TabPage("Факторы");
            factory.Controls.Add(SearchFactoryBtn);
            factory.Controls.Add(FiltrFactoryBtn);
            factory.Controls.Add(AddFactoryBtn);
            factory.Controls.Add(UpdateFactoryBtn);
            factory.Controls.Add(DeleteFactortyBtn);
            factory.Controls.Add(SearchFactoryTextBox);
            factory.Controls.Add(IDFactoryTextBox);
            factory.Controls.Add(NameFactoryTextBox);
            factory.Controls.Add(VesFactoryTextBox);
            factory.Controls.Add(FactoryDtGrView);
            factory.Controls.Add(FactoryComBox);
            TabPage sotr = new TabPage("Сотрудники");
            sotr.Controls.Add(SearchSotrBtn);
            sotr.Controls.Add(FiltrSotrBtn);
            sotr.Controls.Add(AddSotrBtn);
            sotr.Controls.Add(UpdateSotrBtn);
            sotr.Controls.Add(DeleteSotrBtn);
            sotr.Controls.Add(SearchSotrTextBox);
            sotr.Controls.Add(IDSotrTextBox);
            sotr.Controls.Add(LogSotrTextBox);
            sotr.Controls.Add(PassSotrTextBox);
            sotr.Controls.Add(NameSotrTextBox);
            sotr.Controls.Add(FamileSotrTextBox);
            sotr.Controls.Add(OtchSotrTextBox);
            sotr.Controls.Add(DoljSotrTextBox);
            sotr.Controls.Add(SotrDtGrView);
            sotr.Controls.Add(SotrComBox);
            TabPage dolj = new TabPage("Должности");
            dolj.Controls.Add(SearchDoljBtn);
            dolj.Controls.Add(FiltrDoljBtn);
            dolj.Controls.Add(AddDoljBtn);
            dolj.Controls.Add(UpdateDoljBtn);
            dolj.Controls.Add(DeleteDoljBtn);
            dolj.Controls.Add(SearchDoljTextBox);
            dolj.Controls.Add(IDDoljTextBox);
            dolj.Controls.Add(NameDoljTextBox);
            dolj.Controls.Add(DoljDtGrView);
            dolj.Controls.Add(DoljComBox);
            DBTbControl.TabPages.Add(critery);
            DBTbControl.TabPages.Add(factory);
            DBTbControl.TabPages.Add(sotr);
            DBTbControl.TabPages.Add(dolj);

            this.Controls.Add(DBTbControl);

            DBTbSelect = new MaterialTabSelector
            {
                Location = new Point(-2, 63),
                Size = new Size(768, 28),
                BaseTabControl = DBTbControl
            };
            this.Controls.Add(DBTbSelect);

            string connectionString = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = " + Program.server + "; Integrated Security = True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
            Select_critery_void();
            Select_factory_void();
            Select_sotr_void();
            Select_dolj_void();
            this.CriteryDtGrView.DefaultCellStyle.ForeColor = Color.Black;
            this.FactoryDtGrView.DefaultCellStyle.ForeColor = Color.Black;
            this.SotrDtGrView.DefaultCellStyle.ForeColor = Color.Black;
            this.DoljDtGrView.DefaultCellStyle.ForeColor = Color.Black;
            SqlDataReader sqlReader = null;
            VesCriteryTextBox.MaxLength = 2;
            VesFactoryTextBox.MaxLength = 2;

            LoadDataCritery();
            LoadDataFactory();
            LoadDataSotr();
            LoadDataDolj();
            loadform();
        }

        private void GlavnBtn_Click(object sender, EventArgs e)
        {
            Form main = new Main_Form();
            main.Show();
            this.Hide();
        } // Переход на главную страницу

        private void SearchCriteryBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM critery WHERE name_critery LIKE '%" + SearchCriteryTextBox.Text + "%'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            CriteryDtGrView.DataSource = tabl;
            CriteryDtGrView.Columns[0].Visible = false;
            CriteryDtGrView.Columns[1].Visible = true;
            CriteryDtGrView.Columns[1].HeaderText = "Наименование  критерия";
            CriteryDtGrView.Columns[2].Visible = true;
            CriteryDtGrView.Columns[2].HeaderText = "Вес критерия";
            CriteryDtGrView.Columns[3].Visible = true;
            CriteryDtGrView.Columns[3].HeaderText = "Код фактора";
            CriteryDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Поиск критерий

        private void SearchFactoryBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM factory_critery WHERE name_factory_critery LIKE '%" + SearchFactoryTextBox.Text + "%'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            FactoryDtGrView.DataSource = tabl;
            FactoryDtGrView.Columns[0].Visible = false;
            FactoryDtGrView.Columns[1].Visible = true;
            FactoryDtGrView.Columns[1].HeaderText = "Наименование фактора";
            FactoryDtGrView.Columns[2].Visible = true;
            FactoryDtGrView.Columns[2].HeaderText = "Вес фактора";
            FactoryDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Поиск факторов критерий

        private void SearchSotrBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM sotr WHERE f_s LIKE '%" + SearchSotrTextBox.Text + "%'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            SotrDtGrView.DataSource = tabl;
            SotrDtGrView.Columns[0].Visible = false;
            SotrDtGrView.Columns[1].Visible = true;
            SotrDtGrView.Columns[1].HeaderText = "Логин";
            SotrDtGrView.Columns[2].Visible = true;
            SotrDtGrView.Columns[2].HeaderText = "Пароль";
            SotrDtGrView.Columns[3].Visible = true;
            SotrDtGrView.Columns[3].HeaderText = "Фамилия";
            SotrDtGrView.Columns[4].Visible = true;
            SotrDtGrView.Columns[4].HeaderText = "Имя";
            SotrDtGrView.Columns[5].Visible = true;
            SotrDtGrView.Columns[5].HeaderText = "Отчество";
            SotrDtGrView.Columns[6].Visible = true;
            SotrDtGrView.Columns[6].HeaderText = "Код должности";
            SotrDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Поиск сотрудников

        private void SearchDoljBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM dolj WHERE name_dolj LIKE '%" + SearchDoljTextBox.Text + "%'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            DoljDtGrView.DataSource = tabl;
            DoljDtGrView.Columns[0].Visible = false;
            DoljDtGrView.Columns[1].Visible = true;
            DoljDtGrView.Columns[1].HeaderText = "Наименование должности";
            DoljDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Поиск должности

        private void FiltrCriteryBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM critery WHERE id_critery = '" + CriteryComBox.SelectedValue.ToString() + "'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            CriteryDtGrView.DataSource = tabl;
            CriteryDtGrView.Columns[0].Visible = false;
            CriteryDtGrView.Columns[1].Visible = true;
            CriteryDtGrView.Columns[1].HeaderText = "Наименование  критерия";
            CriteryDtGrView.Columns[2].Visible = true;
            CriteryDtGrView.Columns[2].HeaderText = "Вес критерия";
            CriteryDtGrView.Columns[3].Visible = true;
            CriteryDtGrView.Columns[3].HeaderText = "Код фактора";
            CriteryDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Фильтрация критерий

        private void FiltrFactoryBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM factory_critery WHERE id_factory_critery = '" + FactoryComBox.SelectedValue.ToString() + "'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            FactoryDtGrView.DataSource = tabl;
            FactoryDtGrView.Columns[0].Visible = false;
            FactoryDtGrView.Columns[1].Visible = true;
            FactoryDtGrView.Columns[1].HeaderText = "Наименование фактора";
            FactoryDtGrView.Columns[2].Visible = true;
            FactoryDtGrView.Columns[2].HeaderText = "Вес фактора";
            FactoryDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Фильтрация факторов критерий

        private void FiltrSotrBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM sotr WHERE id_sotr = '" + SotrComBox.SelectedValue.ToString() + "'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            SotrDtGrView.DataSource = tabl;
            SotrDtGrView.Columns[0].Visible = false;
            SotrDtGrView.Columns[1].Visible = true;
            SotrDtGrView.Columns[1].HeaderText = "Логин";
            SotrDtGrView.Columns[2].Visible = true;
            SotrDtGrView.Columns[2].HeaderText = "Пароль";
            SotrDtGrView.Columns[3].Visible = true;
            SotrDtGrView.Columns[3].HeaderText = "Фамилия";
            SotrDtGrView.Columns[4].Visible = true;
            SotrDtGrView.Columns[4].HeaderText = "Имя";
            SotrDtGrView.Columns[5].Visible = true;
            SotrDtGrView.Columns[5].HeaderText = "Отчество";
            SotrDtGrView.Columns[6].Visible = true;
            SotrDtGrView.Columns[6].HeaderText = "Код должности";
            SotrDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Фильтрация сотрудников

        private void FiltrDoljBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM dolj WHERE id_dolj = '" + DoljComBox.SelectedValue.ToString() + "'";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            DoljDtGrView.DataSource = tabl;
            DoljDtGrView.Columns[0].Visible = false;
            DoljDtGrView.Columns[1].Visible = true;
            DoljDtGrView.Columns[1].HeaderText = "Наименование должности";
            DoljDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        } // Фильтрация должностей

        private async void AddCriteryBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(NameCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(NameCriteryTextBox.Text) &&
                    !string.IsNullOrEmpty(VesCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(VesCriteryTextBox.Text) &&
                    !string.IsNullOrEmpty(IDFactoryCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(IDFactoryCriteryTextBox.Text))
                    {

                        SqlCommand command = new SqlCommand("INSERT INTO [critery] (name_critery, ves_critery, id_factory_critery)VALUES(@name_critery, @ves_critery, @id_factory_critery)", sqlConnection);

                        command.Parameters.AddWithValue("name_critery", NameCriteryTextBox.Text);
                        command.Parameters.AddWithValue("ves_critery", VesCriteryTextBox.Text);
                        command.Parameters.AddWithValue("id_factory_critery", IDFactoryCriteryTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Критерий добавлен!");

                    }
                    else
                    {
                        MessageBox.Show("Данные не заполнены!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDCriteryTextBox.Clear();
                NameCriteryTextBox.Clear();
                VesCriteryTextBox.Clear();
                IDFactoryCriteryTextBox.Clear();
                LoadDataCritery();
            }
        } // Добавление критерия

        private async void AddFactoryBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(NameFactoryTextBox.Text) && !string.IsNullOrWhiteSpace(NameFactoryTextBox.Text) &&
                    !string.IsNullOrEmpty(VesFactoryTextBox.Text) && !string.IsNullOrWhiteSpace(VesFactoryTextBox.Text))
                    {

                        SqlCommand command = new SqlCommand("INSERT INTO [factory_critery] (name_factory_critery, ves_factory_critery)VALUES(@name_factory_critery, @ves_factory_critery)", sqlConnection);

                        command.Parameters.AddWithValue("name_factory_critery", NameFactoryTextBox.Text);
                        command.Parameters.AddWithValue("ves_factory_critery", VesFactoryTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Фактор критерий добавлен!");


                    }
                    else
                    {
                        MessageBox.Show("Данные не заполнены!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDFactoryTextBox.Clear();
                NameFactoryTextBox.Clear();
                VesFactoryTextBox.Clear();
                LoadDataFactory();
            }
        }  // Добавление фактора критерий

        private async void AddSotrBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "2")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(LogSotrTextBox.Text) && !string.IsNullOrWhiteSpace(LogSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(PassSotrTextBox.Text) && !string.IsNullOrWhiteSpace(PassSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(NameSotrTextBox.Text) && !string.IsNullOrWhiteSpace(NameSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(FamileSotrTextBox.Text) && !string.IsNullOrWhiteSpace(FamileSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(OtchSotrTextBox.Text) && !string.IsNullOrWhiteSpace(OtchSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(DoljSotrTextBox.Text) && !string.IsNullOrWhiteSpace(DoljSotrTextBox.Text))
                    {

                        SqlCommand command = new SqlCommand("INSERT INTO [sotr] (login_sotr, password_sotr, i_s, f_s, o_s, id_dolj)VALUES(@login_sotr, @password_sotr, @i_s, @f_s, @o_s, @id_dolj)", sqlConnection);

                        command.Parameters.AddWithValue("login_sotr", LogSotrTextBox.Text);
                        command.Parameters.AddWithValue("password_sotr", Bcrypt.HashPassword(PassSotrTextBox.Text, Settings.Default.Heach));
                        command.Parameters.AddWithValue("i_s", NameSotrTextBox.Text);
                        command.Parameters.AddWithValue("f_s", FamileSotrTextBox.Text);
                        command.Parameters.AddWithValue("o_s", OtchSotrTextBox.Text);
                        command.Parameters.AddWithValue("id_dolj", DoljSotrTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Сотрудник добавлен!");


                    }
                    else
                    {
                        MessageBox.Show("Данные не заполнены!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDSotrTextBox.Clear();
                LogSotrTextBox.Clear();
                PassSotrTextBox.Clear();
                NameSotrTextBox.Clear();
                FamileSotrTextBox.Clear();
                OtchSotrTextBox.Clear();
                DoljSotrTextBox.Clear();
                LoadDataSotr();
            }
        } // Добавление сотрудников

        private async void AddDoljBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3" || Program.Dolj == "2")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(NameDoljTextBox.Text) && !string.IsNullOrWhiteSpace(NameDoljTextBox.Text))
                    {

                        SqlCommand command = new SqlCommand("INSERT INTO [dolj] (name_dolj)VALUES(@name_dolj)", sqlConnection);

                        command.Parameters.AddWithValue("name_dolj", NameDoljTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Должность добавлена!");

                    }
                    else
                    {
                        MessageBox.Show("Данные не заполнены!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDDoljTextBox.Clear();
                NameDoljTextBox.Clear();
                LoadDataDolj();
            }
        } // Добавление должности

        private async void UpdateCriteryBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(IDCriteryTextBox.Text) &&
                    !string.IsNullOrEmpty(NameCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(NameCriteryTextBox.Text) &&
                    !string.IsNullOrEmpty(VesCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(VesCriteryTextBox.Text) &&
                    !string.IsNullOrEmpty(IDFactoryCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(IDFactoryCriteryTextBox.Text))
                    {

                        SqlCommand command = new SqlCommand("UPDATE [critery] SET [name_critery]=@name_critery, " +
                            "[ves_critery]=@ves_critery, [id_factory_critery]=@id_factory_critery WHERE [id_critery]=@id_critery", sqlConnection);

                        command.Parameters.AddWithValue("id_critery", IDCriteryTextBox.Text);
                        command.Parameters.AddWithValue("name_critery", NameCriteryTextBox.Text);
                        command.Parameters.AddWithValue("ves_critery", VesCriteryTextBox.Text);
                        command.Parameters.AddWithValue("id_factory_critery", IDFactoryCriteryTextBox.Text);
                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Данные критерия изменены!");
                    }
                    else
                    {
                        MessageBox.Show("Данные поля должны быть заполнены");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDCriteryTextBox.Clear();
                NameCriteryTextBox.Clear();
                VesCriteryTextBox.Clear();
                IDFactoryCriteryTextBox.Clear();
                LoadDataCritery();
            }
        } // Изменение критерия

        private async void UpdateFactoryBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDFactoryTextBox.Text) && !string.IsNullOrWhiteSpace(IDFactoryTextBox.Text) &&
                    !string.IsNullOrEmpty(NameFactoryTextBox.Text) && !string.IsNullOrWhiteSpace(NameFactoryTextBox.Text) &&
                    !string.IsNullOrEmpty(VesFactoryTextBox.Text) && !string.IsNullOrWhiteSpace(VesFactoryTextBox.Text))
                    {

                        SqlCommand command = new SqlCommand("UPDATE [factory_critery] SET [name_factory_critery]=@name_factory_critery, [ves_factory_critery]=@ves_factory_critery WHERE [id_factory_critery]=@id_factory_critery", sqlConnection);

                        command.Parameters.AddWithValue("id_factory_critery", IDFactoryTextBox.Text);
                        command.Parameters.AddWithValue("name_factory_critery", NameFactoryTextBox.Text);
                        command.Parameters.AddWithValue("ves_factory_critery", VesFactoryTextBox.Text);
                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Данные фактора изменены!");
                    }
                    else
                    {
                        MessageBox.Show("Данные поля должны быть заполнены");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDFactoryTextBox.Clear();
                NameFactoryTextBox.Clear();
                VesFactoryTextBox.Clear();
                LoadDataFactory();
            }
        }  // Изменение фактора критерия

        private async void UpdateSotrBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "2")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDSotrTextBox.Text) && !string.IsNullOrWhiteSpace(IDSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(LogSotrTextBox.Text) && !string.IsNullOrWhiteSpace(LogSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(PassSotrTextBox.Text) && !string.IsNullOrWhiteSpace(PassSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(NameSotrTextBox.Text) && !string.IsNullOrWhiteSpace(NameSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(FamileSotrTextBox.Text) && !string.IsNullOrWhiteSpace(FamileSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(OtchSotrTextBox.Text) && !string.IsNullOrWhiteSpace(OtchSotrTextBox.Text) &&
                    !string.IsNullOrEmpty(DoljSotrTextBox.Text) && !string.IsNullOrWhiteSpace(DoljSotrTextBox.Text))
                    {
                        SqlCommand command = new SqlCommand("UPDATE [sotr] SET [login_sotr]=@login_sotr, [password_sotr]=@password_sotr, [f_s]=@f_s, [i_s]=@i_s, [o_s]=@o_s, [id_dolj]=@id_dolj WHERE [id_sotr]=@id_sotr", sqlConnection);

                        command.Parameters.AddWithValue("id_sotr", IDSotrTextBox.Text);
                        command.Parameters.AddWithValue("login_sotr", LogSotrTextBox.Text);
                        command.Parameters.AddWithValue("password_sotr", Bcrypt.HashPassword(PassSotrTextBox.Text, Settings.Default.Heach));
                        command.Parameters.AddWithValue("i_s", NameSotrTextBox.Text);
                        command.Parameters.AddWithValue("f_s", FamileSotrTextBox.Text);
                        command.Parameters.AddWithValue("o_s", OtchSotrTextBox.Text);
                        command.Parameters.AddWithValue("id_dolj", DoljSotrTextBox.Text);
                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Данные сотрудника изменены!");
                    }
                    else
                    {
                        MessageBox.Show("Данные поля должны быть заполнены");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDSotrTextBox.Clear();
                LogSotrTextBox.Clear();
                PassSotrTextBox.Clear();
                NameSotrTextBox.Clear();
                FamileSotrTextBox.Clear();
                OtchSotrTextBox.Clear();
                DoljSotrTextBox.Clear();
                LoadDataSotr();
            }
        } // Изменение сотрудника

        private async void UpdateDoljBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3" || Program.Dolj == "2")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDDoljTextBox.Text) && !string.IsNullOrWhiteSpace(IDDoljTextBox.Text) &&
                    !string.IsNullOrEmpty(NameDoljTextBox.Text) && !string.IsNullOrWhiteSpace(NameDoljTextBox.Text))
                    {
                        SqlCommand command = new SqlCommand("UPDATE [dolj] SET [name_dolj]=@name_dolj WHERE [id_dolj]=@id_dolj", sqlConnection);

                        command.Parameters.AddWithValue("id_dolj", IDDoljTextBox.Text);
                        command.Parameters.AddWithValue("name_dolj", NameDoljTextBox.Text);
                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Данные должности изменены!");
                    }
                    else
                    {
                        MessageBox.Show("Данные поля должны быть заполнены");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка: Введено неверное значение!");
                }
                IDDoljTextBox.Clear();
                NameDoljTextBox.Clear();
                LoadDataDolj();
            }
        }  // Изменение должности

        private async void DeleteCriteryBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDCriteryTextBox.Text) && !string.IsNullOrWhiteSpace(IDCriteryTextBox.Text))
                    {
                        SqlCommand command = new SqlCommand("DELETE FROM [critery] WHERE [id_critery]=@id_critery", sqlConnection);

                        command.Parameters.AddWithValue("id_critery", IDCriteryTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Критерий удален!");
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
                IDCriteryTextBox.Clear();
                LoadDataCritery();
            }
        } // Удаление критерия

        private async void DeleteFactortyBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDFactoryTextBox.Text) && !string.IsNullOrWhiteSpace(IDFactoryTextBox.Text))
                    {
                        SqlCommand command = new SqlCommand("DELETE FROM [factory_critery] WHERE [id_factory_critery]=@id_factory_critery", sqlConnection);

                        command.Parameters.AddWithValue("id_factory_critery", IDFactoryTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("фактор критерий удален!");
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
                IDFactoryTextBox.Clear();
                LoadDataFactory();
            }
        }  // Удаление фактора критерия

        private async void DeleteSotrBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "2")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDSotrTextBox.Text) && !string.IsNullOrWhiteSpace(IDSotrTextBox.Text))
                    {
                        SqlCommand command = new SqlCommand("DELETE FROM [sotr] WHERE [id_sotr]=@id_sotr", sqlConnection);

                        command.Parameters.AddWithValue("id_sotr", IDSotrTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Сотрудник удален!");
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
                IDSotrTextBox.Clear();
                LoadDataSotr();
            }
        } // Удаление сотрудника

        private async void DeleteDoljBtn_Click(object sender, EventArgs e)
        {
            if (Program.Dolj == "3" || Program.Dolj == "2")
            {
                MessageBox.Show("У вас нет доступа для данной функции!");
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(IDDoljTextBox.Text) && !string.IsNullOrWhiteSpace(IDDoljTextBox.Text))
                    {
                        SqlCommand command = new SqlCommand("DELETE FROM [dolj] WHERE [id_dolj]=@id_dolj", sqlConnection);

                        command.Parameters.AddWithValue("id_dolj", IDDoljTextBox.Text);

                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("Должность удалена!");
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
                IDDoljTextBox.Clear();
                LoadDataDolj();
            }
        } // Удаление должности

        private void VesCriteryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) 
            {
                e.Handled = true;
            }
        } // ограничения ввода веса критерий

        private void VesFactoryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        } // ограничения ввода веса факторов

        private void CriteryDtGrView_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            CriteryDtGrView.Rows[index].Selected = true;

            IDCriteryTextBox.Text = CriteryDtGrView.SelectedCells[0].Value.ToString();
            NameCriteryTextBox.Text = CriteryDtGrView.SelectedCells[1].Value.ToString();
            VesCriteryTextBox.Text = CriteryDtGrView.SelectedCells[2].Value.ToString();
            IDFactoryCriteryTextBox.Text = CriteryDtGrView.SelectedCells[3].Value.ToString();
        } // вывод данных критерий при нажатии на ячейку

        private void FactoryDtGrView_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            FactoryDtGrView.Rows[index].Selected = true;

            IDFactoryTextBox.Text = FactoryDtGrView.SelectedCells[0].Value.ToString();
            NameFactoryTextBox.Text = FactoryDtGrView.SelectedCells[1].Value.ToString();
            VesFactoryTextBox.Text = FactoryDtGrView.SelectedCells[2].Value.ToString();
        } // вывод данных факторов при нажатии на ячейку

        private void SotrDtGrView_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            SotrDtGrView.Rows[index].Selected = true;

            IDSotrTextBox.Text = SotrDtGrView.SelectedCells[0].Value.ToString();
            LogSotrTextBox.Text = SotrDtGrView.SelectedCells[1].Value.ToString();
            PassSotrTextBox.Text = SotrDtGrView.SelectedCells[2].Value.ToString();
            FamileSotrTextBox.Text = SotrDtGrView.SelectedCells[3].Value.ToString();
            NameSotrTextBox.Text = SotrDtGrView.SelectedCells[4].Value.ToString();
            OtchSotrTextBox.Text = SotrDtGrView.SelectedCells[5].Value.ToString();
            DoljSotrTextBox.Text = SotrDtGrView.SelectedCells[6].Value.ToString();
        } // вывод данных сотрудников при нажатии на ячейку

        private void DoljDtGrView_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            DoljDtGrView.Rows[index].Selected = true;

            IDDoljTextBox.Text = DoljDtGrView.SelectedCells[0].Value.ToString();
            NameDoljTextBox.Text = DoljDtGrView.SelectedCells[1].Value.ToString();
        } // вывод данных должностей при нажатии на ячейку

        private void Select_critery_void() 
        {

            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM critery";
            SqlCommand com = new SqlCommand(podkl, sqlConnection);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            CriteryComBox.DataSource = tabl;
            CriteryComBox.DisplayMember = "name_critery";
            CriteryComBox.ValueMember = "id_critery";
        } // Выборка фильтра сортировки критерий в comboBox

        private void Select_factory_void() 
        {

            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM factory_critery";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            FactoryComBox.DataSource = tabl;
            FactoryComBox.DisplayMember = "name_factory_critery";
            FactoryComBox.ValueMember = "id_factory_critery";

        } // Выборка фильтра сортировки факторов критерий в comboBox

        private void Select_sotr_void() 
        {

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

        } // Выборка фильтра сортировки сотрудников в comboBox

        private void Select_dolj_void() 
        {

            SqlConnection connect = new SqlConnection(pdkl);
            string podkl = "SELECT * FROM dolj";
            SqlCommand com = new SqlCommand(podkl, connect);
            connect.Open();
            SqlDataReader read = com.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Load(read);
            DoljComBox.DataSource = tabl;
            DoljComBox.DisplayMember = "name_dolj";
            DoljComBox.ValueMember = "id_dolj";

        } // Выборка фильтра сортировки должностей в comboBox

        public void LoadDataCritery()  
        {
            try
            {
                SqlConnection connect = new SqlConnection(pdkl);
                string podkl = "SELECT * FROM critery";
                SqlCommand com = new SqlCommand(podkl, connect);
                connect.Open();
                SqlDataReader read = com.ExecuteReader();
                DataTable tabl = new DataTable();
                tabl.Load(read);
                CriteryDtGrView.DataSource = tabl;
                CriteryDtGrView.Columns[0].Visible = false;
                CriteryDtGrView.Columns[1].Visible = true;
                CriteryDtGrView.Columns[1].HeaderText = "Наименование критерия";
                CriteryDtGrView.Columns[2].Visible = true;
                CriteryDtGrView.Columns[2].HeaderText = "Вес критерия";
                CriteryDtGrView.Columns[3].Visible = true;
                CriteryDtGrView.Columns[3].HeaderText = "Код фактора";
                CriteryDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connect.Close();
            }
            catch
            { }

        } // отображение данных из таблицы критерии

        private void LoadDataFactory()  
        {
            try
            {
                SqlConnection connect = new SqlConnection(pdkl);
                string podkl = "SELECT * FROM factory_critery";
                SqlCommand com = new SqlCommand(podkl, connect);
                connect.Open();
                SqlDataReader read = com.ExecuteReader();
                DataTable tabl = new DataTable();
                tabl.Load(read);
                FactoryDtGrView.DataSource = tabl;
                FactoryDtGrView.Columns[0].Visible = false;
                FactoryDtGrView.Columns[1].Visible = true;
                FactoryDtGrView.Columns[1].HeaderText = "Наименование фактора";
                FactoryDtGrView.Columns[2].Visible = true;
                FactoryDtGrView.Columns[2].HeaderText = "Вес фактора";
                FactoryDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connect.Close();
            }
            catch
            { }

        } // отображение данных из таблицы факторы

        private void LoadDataSotr()  
        {
            try
            {
                SqlConnection connect = new SqlConnection(pdkl);
                string podkl = "SELECT * FROM sotr";
                SqlCommand com = new SqlCommand(podkl, connect);
                connect.Open();
                SqlDataReader read = com.ExecuteReader();
                DataTable tabl = new DataTable();
                tabl.Load(read);
                SotrDtGrView.DataSource = tabl;
                SotrDtGrView.Columns[0].Visible = false;
                SotrDtGrView.Columns[1].Visible = true;
                SotrDtGrView.Columns[1].HeaderText = "Логин";
                SotrDtGrView.Columns[2].Visible = true;
                SotrDtGrView.Columns[2].HeaderText = "Пароль";
                SotrDtGrView.Columns[3].Visible = true;
                SotrDtGrView.Columns[3].HeaderText = "Фамилия";
                SotrDtGrView.Columns[4].Visible = true;
                SotrDtGrView.Columns[4].HeaderText = "Имя";
                SotrDtGrView.Columns[5].Visible = true;
                SotrDtGrView.Columns[5].HeaderText = "Отчество";
                SotrDtGrView.Columns[6].Visible = true;
                SotrDtGrView.Columns[6].HeaderText = "Код должности";
                SotrDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connect.Close();
            }
            catch
            { }

        } // отображение данных из таблицы сотрудники

        private void LoadDataDolj()  
        {
            try
            {
                SqlConnection connect = new SqlConnection(pdkl);
                string podkl = "SELECT * FROM dolj";
                SqlCommand com = new SqlCommand(podkl, connect);
                connect.Open();
                SqlDataReader read = com.ExecuteReader();
                DataTable tabl = new DataTable();
                tabl.Load(read);
                DoljDtGrView.DataSource = tabl;
                DoljDtGrView.Columns[0].Visible = false;
                DoljDtGrView.Columns[1].Visible = true;
                DoljDtGrView.Columns[1].HeaderText = "Наименование должности";
                DoljDtGrView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                connect.Close();
            }
            catch
            { }
        } // отображение данных из таблицы должности

        private void loadform()
        {
            CriteryDtGrView.Show();
            FactoryDtGrView.Show();
            SotrDtGrView.Show();
            DoljDtGrView.Show();
        }
    }
}
