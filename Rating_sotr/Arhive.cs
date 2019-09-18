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
using Microsoft.Win32;
using System.Threading;
using Ionic.Zip;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.IO.Compression;

namespace Rating_sotr
{
    public partial class Arhive : MaterialForm
    {
        
        MaterialSkinManager skinManager;
        public Arhive()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
        }

        private void Exit_Click(object sender, EventArgs e) => this.Close();

        private void Arhive_Load(object sender, EventArgs e)
        {
        }

        private void ExitBtn_Click(object sender, EventArgs e) => this.Close();

        private void FileSearchBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbg = new FolderBrowserDialog();
            fbg.Description = "Выберете путь к каталогу";
            if (fbg.ShowDialog() == DialogResult.OK)
                FolderNameTextBox.Text = fbg.SelectedPath;
        } // выбор архива для восстановления

        private void FolderSearchBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    FileNameTextBox.Text = ofd.FileName;
            }
        } // выбор каталога для сохранения архива

        private void FolderArhiveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Server srv = new Server("DESKTOP-EPNEITS");
                Database db = default(Database);
                db = srv.Databases["Rating"];

                int recoverymod;
                recoverymod = (int)db.DatabaseOptions.RecoveryModel;

                Backup bk = new Backup();

                bk.Action = BackupActionType.Database;
                bk.BackupSetDescription = "Full backup of Rating";
                bk.BackupSetName = "Rating Backup";
                bk.Database = "Rating";

                BackupDeviceItem bdi = default(BackupDeviceItem);
                bdi = new BackupDeviceItem("Rating " + DateTime.Now.ToString("yyyy-MM-dd") + " Backup", DeviceType.File);

                bk.Devices.Add(bdi);
                bk.Incremental = false;

                System.DateTime backupdate = new System.DateTime();
                backupdate = new System.DateTime(2018, 10, 5);
                bk.ExpirationDate = backupdate;

                bk.LogTruncation = BackupTruncateLogType.Truncate;

                bk.SqlBackup(srv);

                bk.Devices.Remove(bdi);

                if (string.IsNullOrEmpty(FolderNameTextBox.Text))
                {
                    MessageBox.Show("Выберете папку!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FolderNameTextBox.Focus();
                    return;
                }

                string pat = "BackupDB.zip";
                string path = FolderNameTextBox.Text;

                using (ZipFile zip = new ZipFile())
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    zip.AddDirectory(@"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\Backup");
                    zip.Save(path + " " + DateTime.Now.ToString("yyyy-MM-dd") + " " + pat);
                }

                MessageBox.Show("Архивирование данных прошло успешно!");
            }
            catch
            {
                MessageBox.Show("Во время архивации данных произошла ошибка, убедитесь в правильности указания каталога!");
            }
            
        } // архивация бекапа БД

        private void FileArhiveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FileNameTextBox.Text))
                {
                    MessageBox.Show("Выберете Файл!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileNameTextBox.Focus();
                    return;
                }

                String sourcePath = FileNameTextBox.Text;
                using (ZipFile zip = ZipFile.Read(sourcePath))
                {

                    zip.ExtractAll(@"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\Backup", ExtractExistingFileAction.DoNotOverwrite);

                }

                Server srv = new Server("DESKTOP-EPNEITS");
                Database db = default(Database);
                db = srv.Databases["Rating"];

                int recoverymod;
                recoverymod = (int)db.DatabaseOptions.RecoveryModel;

                BackupDeviceItem bdi = default(BackupDeviceItem);
                bdi = new BackupDeviceItem("Rating " + DateTime.Now.ToString("yyyy-MM-dd") + " Backup", DeviceType.File);

                Restore rs = new Restore();

                rs.NoRecovery = true;

                rs.Devices.Add(bdi);

                rs.Database = "Rating";

                // rs.SqlRestore(srv);

                db = srv.Databases["Rating"];

                rs.Devices.Remove(bdi);

                rs.NoRecovery = false;

                db.RecoveryModel = (RecoveryModel)recoverymod;

                db.Alter();

                MessageBox.Show("Восстановление данных прошло успешно!");
            }
            catch
            {
                MessageBox.Show("Данный файл не является архивом, либо не относиться к текущей базе данных!");
            }
        } // Восстановление архива
    }
}
