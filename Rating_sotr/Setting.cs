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

namespace Rating_sotr
{
    public partial class Setting : MaterialForm
    {
        
        private readonly MaterialSkinManager materialSkinManager;
        public Setting()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void materialRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton5.Checked == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }  // Изменение фона программы

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton4.Checked == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
        }    // Изменение фона программы

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked == true)
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            }
        }  // Изменение цвета объектов программы

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked == true)
            {               
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            }
        }  // Изменение цвета объектов программы

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton3.Checked == true)
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
            }
        }  // Изменение цвета объектов программы

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }  // Закрытие формы без отмены настроек

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.Close();
        }  // Отмена изменений


        private void Exit_Click(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme != MaterialSkinManager.Themes.LIGHT)
            {
                if (DialogResult.Yes == MessageBox.Show("Сохранить текущие настройки?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    this.Close();
                }
                else
                {
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

                    this.Close();
                }
            }
            else
            {
                this.Close();
            }

        }  // Закрытие настроек
    }
}
