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
using Bcrypt = BCrypt.Net.BCrypt;
using Rating_sotr.Properties;
using Microsoft.Win32;

namespace Rating_sotr
{
    public partial class Log_Form : MaterialForm
    {
        Main_Form form = new Main_Form();
        private readonly MaterialSkinManager skinManager;

        MaterialLabel SelectServerLbl;
        MaterialRaisedButton AuthBtn;
        PictureBox LogoImg, PassImg, DownImg, UpImg, ServerImg, CharImg, CharHideImg;
        MaterialCheckBox RememberChBox;
        MaterialSingleLineTextField LogoTextBox, PassTextBox;
        ComboBox ServerComBox;

        public Log_Form()
        {
           
            InitializeComponent();
            this.Size = new Size(240, 360);
            skinManager = MaterialSkinManager.Instance; 
            skinManager.AddFormToManage(this);
        }

        private void exit_picture_Click(object sender, EventArgs e) => Application.Exit();

        private void Log_Form_Load(object sender, EventArgs e)
        {

            Bitmap Logo = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\logo_log.png");

            LogoImg = new PictureBox
            {
                Location = new Point(9, 72),
                Size = new Size(43, 40),
                BackgroundImage = Logo,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            this.Controls.Add(LogoImg);

            Bitmap Pass = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\pass_logo.png");

            PassImg = new PictureBox
            {
                Location = new Point(9, 124),
                Size = new Size(43, 38),
                BackgroundImage = Pass,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            this.Controls.Add(PassImg);

            Bitmap Down = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\down.png");

            DownImg = new PictureBox
            {
                Location = new Point(82, 227),
                Size = new Size(78, 25),
                BackgroundImage = Down,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            DownImg.Click += new EventHandler(DownImg_Click);
            this.Controls.Add(DownImg);

            Bitmap Up = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\up.png");

            UpImg = new PictureBox
            {
                Location = new Point(82, 227),
                Size = new Size(78, 25),
                BackgroundImage = Up,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            UpImg.Click += new EventHandler(UpImg_Click);

            Bitmap Server = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\server.png");

            ServerImg = new PictureBox
            {
                Location = new Point(9, 299),
                Size = new Size(43, 38),
                BackgroundImage = Server,
                BackgroundImageLayout = ImageLayout.Zoom
            };

            Bitmap Char = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\eyes.png");

            CharImg = new PictureBox
            {
                Location = new Point(196, 132),
                Size = new Size(43, 38),
                BackgroundImage = Char,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            this.Controls.Add(CharImg);
            CharImg.Click += new EventHandler(CharImg_Click);

            Bitmap CharHide = new Bitmap(@"D:\Флешка\4 курс\Программа работа\Rating_sotr\hide.png");

            CharHideImg = new PictureBox
            {
                Location = new Point(196, 132),
                Size = new Size(43, 38),
                BackgroundImage = CharHide,
                BackgroundImageLayout = ImageLayout.Zoom
            };
            CharHideImg.Click += new EventHandler(CharHideImg_Click);

            AuthBtn = new MaterialRaisedButton
            {
                Text = "ВХОД",
                Location = new Point(150, 186)
            }; 
            AuthBtn.Click += new EventHandler(AuthBtn_Click);
            this.Controls.Add(AuthBtn);

            SelectServerLbl = new MaterialLabel
            {
                Location = new Point(56, 274),
                Text = "Выбор базы данных",
                AutoSize = true
            };

            ServerComBox = new ComboBox()
            {
                Location = new Point(56, 316),
                Size = new Size(182, 21),
            }; 

            RememberChBox = new MaterialCheckBox
            {
                Text = "Запомнить",
                Location = new Point(9, 190),
                Checked = true
            }; 
            this.Controls.Add(RememberChBox);

            LogoTextBox = new MaterialSingleLineTextField
            {
                Hint = "Логин",
                Location = new Point(56, 81),
                Size = new Size(140, 23)
            };
            this.Controls.Add(LogoTextBox);

            PassTextBox = new MaterialSingleLineTextField
            {
                Hint = "Пароль",
                Location = new Point(56, 132),
                Size = new Size(140, 23),
                PasswordChar = '*'
            };
            this.Controls.Add(PassTextBox);

            try  
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey helloKey = currentUserKey.OpenSubKey("HelloKey", true);
                string login = helloKey.GetValue("login").ToString();
                string password = helloKey.GetValue("password").ToString();
                LogoTextBox.Text = login;
                PassTextBox.Text = password;
                helloKey.Close();
            }
            catch
            {

            }

            using (SqlConnection sqlConn = new SqlConnection(@"Server=DESKTOP-EPNEITS;Integrated Security=SSPI")) 
            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "sp_helpdb";

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ServerComBox.Items.Add(row["name"].ToString());
                }

                ServerComBox.Text = ServerComBox.Items[3].ToString();

            } 
            Height = 260;
        }

        private void ExitImg_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                Application.Exit();
            }
        } // Подтверждение выхода

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Program.server = ServerComBox.SelectedItem.ToString(); 
                string connect = @"Data Source = DESKTOP-EPNEITS; Initial Catalog = " + Program.server + "; Integrated Security = True"; 
                SqlConnection con = new SqlConnection(connect);
                SqlDataAdapter sd = new SqlDataAdapter("Select Count (*) From sotr where login_sotr = '" + LogoTextBox.Text + "' and password_sotr = '" + Bcrypt.HashPassword(PassTextBox.Text, Settings.Default.Heach) + "'", con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select i_s From sotr where login_sotr = '" + LogoTextBox.Text + "' and password_sotr = '" + Bcrypt.HashPassword(PassTextBox.Text, Settings.Default.Heach) + "'", con);
                    string namesotr = command.ExecuteScalar().ToString();
                    Program.Name = namesotr;
                    SqlCommand commande = new SqlCommand("Select id_dolj From sotr where login_sotr = '" + LogoTextBox.Text + "' and password_sotr = '" + Bcrypt.HashPassword(PassTextBox.Text, Settings.Default.Heach) + "'", con);
                    string doljsotr = commande.ExecuteScalar().ToString();
                    Program.Dolj = doljsotr;
                    con.Close();
                    Form Main = new Main_Form();
                    Main.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка соединения с сервером. Повторите попытку!");
            }
            if (RememberChBox.Checked == true) 
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey helloKey = currentUserKey.CreateSubKey("HelloKey");
                helloKey.SetValue("login", LogoTextBox.Text);
                helloKey.SetValue("password", PassTextBox.Text);
                helloKey.Close();

            }
            else 
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey helloKey = currentUserKey.OpenSubKey("HelloKey", true);
                helloKey.DeleteValue("login");
                helloKey.DeleteValue("password");
                helloKey.Close();
                currentUserKey.DeleteSubKey("HelloKey");
            }
        }  // Авторизация пользователя

        private void DownImg_Click(object sender, EventArgs e)
        {
            Height = 380;
            this.Controls.Remove(DownImg);
            this.Controls.Add(UpImg);


            this.Controls.Add(ServerImg);
            this.Controls.Add(SelectServerLbl);
            this.Controls.Add(ServerComBox);
        } // Открытие части формы с серверами

        private void UpImg_Click(object sender, EventArgs e)
        {
             Height = 260;
             this.Controls.Remove(UpImg);
             this.Controls.Add(DownImg);

            this.Controls.Remove(ServerImg);
            this.Controls.Remove(SelectServerLbl);
            this.Controls.Remove(ServerComBox);
        }// Закрытие части формы с серверами

        private void CharHideImg_Click(object sender, EventArgs e)
        {
            PassTextBox.PasswordChar = '*';
            this.Controls.Remove(CharHideImg);
            this.Controls.Add(CharImg);
        } // Скрытие пароля

        private void CharImg_Click(object sender, EventArgs e)
        {
            PassTextBox.PasswordChar = '\0';
            this.Controls.Remove(CharImg);
            this.Controls.Add(CharHideImg);
        } // Открытие пароля
    }
}
