namespace Rating_sotr
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.CompleteBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.CancelBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialRadioButton3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialRadioButton4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton5 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.AutoSize = true;
            this.CompleteBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CompleteBtn.Depth = 0;
            this.CompleteBtn.Icon = null;
            this.CompleteBtn.Location = new System.Drawing.Point(150, 262);
            this.CompleteBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Primary = true;
            this.CompleteBtn.Size = new System.Drawing.Size(105, 36);
            this.CompleteBtn.TabIndex = 8;
            this.CompleteBtn.Text = "Применить";
            this.CompleteBtn.UseVisualStyleBackColor = true;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(67, 262);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = true;
            this.CancelBtn.Size = new System.Drawing.Size(77, 36);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(1, 84);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(279, 172);
            this.materialTabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.materialRadioButton3);
            this.tabPage1.Controls.Add(this.materialRadioButton2);
            this.tabPage1.Controls.Add(this.materialRadioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(271, 146);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Цвет объектов";
            // 
            // materialRadioButton3
            // 
            this.materialRadioButton3.AutoSize = true;
            this.materialRadioButton3.Depth = 0;
            this.materialRadioButton3.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton3.Location = new System.Drawing.Point(99, 118);
            this.materialRadioButton3.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton3.Name = "materialRadioButton3";
            this.materialRadioButton3.Ripple = true;
            this.materialRadioButton3.Size = new System.Drawing.Size(87, 30);
            this.materialRadioButton3.TabIndex = 2;
            this.materialRadioButton3.TabStop = true;
            this.materialRadioButton3.Text = "Зеленый";
            this.materialRadioButton3.UseVisualStyleBackColor = true;
            this.materialRadioButton3.CheckedChanged += new System.EventHandler(this.materialRadioButton3_CheckedChanged);
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton2.Location = new System.Drawing.Point(99, 78);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(69, 30);
            this.materialRadioButton2.TabIndex = 1;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "Синий";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            this.materialRadioButton2.CheckedChanged += new System.EventHandler(this.materialRadioButton2_CheckedChanged);
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton1.Location = new System.Drawing.Point(99, 37);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(82, 30);
            this.materialRadioButton1.TabIndex = 0;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "Темный";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            this.materialRadioButton1.CheckedChanged += new System.EventHandler(this.materialRadioButton1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.materialRadioButton4);
            this.tabPage2.Controls.Add(this.materialRadioButton5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(271, 146);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Цвет фона";
            // 
            // materialRadioButton4
            // 
            this.materialRadioButton4.AutoSize = true;
            this.materialRadioButton4.Depth = 0;
            this.materialRadioButton4.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton4.Location = new System.Drawing.Point(101, 106);
            this.materialRadioButton4.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton4.Name = "materialRadioButton4";
            this.materialRadioButton4.Ripple = true;
            this.materialRadioButton4.Size = new System.Drawing.Size(87, 30);
            this.materialRadioButton4.TabIndex = 3;
            this.materialRadioButton4.TabStop = true;
            this.materialRadioButton4.Text = "Светлый";
            this.materialRadioButton4.UseVisualStyleBackColor = true;
            this.materialRadioButton4.CheckedChanged += new System.EventHandler(this.materialRadioButton4_CheckedChanged);
            // 
            // materialRadioButton5
            // 
            this.materialRadioButton5.AutoSize = true;
            this.materialRadioButton5.Depth = 0;
            this.materialRadioButton5.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton5.Location = new System.Drawing.Point(101, 58);
            this.materialRadioButton5.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton5.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton5.Name = "materialRadioButton5";
            this.materialRadioButton5.Ripple = true;
            this.materialRadioButton5.Size = new System.Drawing.Size(82, 30);
            this.materialRadioButton5.TabIndex = 2;
            this.materialRadioButton5.TabStop = true;
            this.materialRadioButton5.Text = "Темный";
            this.materialRadioButton5.UseVisualStyleBackColor = true;
            this.materialRadioButton5.CheckedChanged += new System.EventHandler(this.materialRadioButton5_CheckedChanged);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-5, 63);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(291, 37);
            this.materialTabSelector1.TabIndex = 11;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.Location = new System.Drawing.Point(260, 1);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(16, 18);
            this.Exit.TabIndex = 12;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 308);
            this.ControlBox = false;
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CompleteBtn);
            this.Name = "Setting";
            this.Text = "Настройки";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton CompleteBtn;
        private MaterialSkin.Controls.MaterialRaisedButton CancelBtn;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton3;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton4;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton5;
        private System.Windows.Forms.PictureBox Exit;
    }
}