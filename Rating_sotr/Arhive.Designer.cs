namespace Rating_sotr
{
    partial class Arhive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arhive));
            this.Exit = new System.Windows.Forms.PictureBox();
            this.ExitBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.FolderArhiveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.FileArhiveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.FolderSearchBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.FileSearchBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.FolderNameTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.FileNameTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.Location = new System.Drawing.Point(490, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(16, 18);
            this.Exit.TabIndex = 13;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.AutoSize = true;
            this.ExitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitBtn.Depth = 0;
            this.ExitBtn.Icon = null;
            this.ExitBtn.Location = new System.Drawing.Point(421, 193);
            this.ExitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Primary = true;
            this.ExitBtn.Size = new System.Drawing.Size(85, 36);
            this.ExitBtn.TabIndex = 15;
            this.ExitBtn.Text = "Закрыть";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // FolderArhiveBtn
            // 
            this.FolderArhiveBtn.AutoSize = true;
            this.FolderArhiveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FolderArhiveBtn.Depth = 0;
            this.FolderArhiveBtn.Icon = null;
            this.FolderArhiveBtn.Location = new System.Drawing.Point(377, 82);
            this.FolderArhiveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.FolderArhiveBtn.Name = "FolderArhiveBtn";
            this.FolderArhiveBtn.Primary = true;
            this.FolderArhiveBtn.Size = new System.Drawing.Size(129, 36);
            this.FolderArhiveBtn.TabIndex = 16;
            this.FolderArhiveBtn.Text = "Архивировать";
            this.FolderArhiveBtn.UseVisualStyleBackColor = true;
            this.FolderArhiveBtn.Click += new System.EventHandler(this.FolderArhiveBtn_Click);
            // 
            // FileArhiveBtn
            // 
            this.FileArhiveBtn.AutoSize = true;
            this.FileArhiveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileArhiveBtn.Depth = 0;
            this.FileArhiveBtn.Icon = null;
            this.FileArhiveBtn.Location = new System.Drawing.Point(377, 131);
            this.FileArhiveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.FileArhiveBtn.Name = "FileArhiveBtn";
            this.FileArhiveBtn.Primary = true;
            this.FileArhiveBtn.Size = new System.Drawing.Size(129, 36);
            this.FileArhiveBtn.TabIndex = 17;
            this.FileArhiveBtn.Text = "Восстановить";
            this.FileArhiveBtn.UseVisualStyleBackColor = true;
            this.FileArhiveBtn.Click += new System.EventHandler(this.FileArhiveBtn_Click);
            // 
            // FolderSearchBtn
            // 
            this.FolderSearchBtn.AutoSize = true;
            this.FolderSearchBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FolderSearchBtn.Depth = 0;
            this.FolderSearchBtn.Icon = null;
            this.FolderSearchBtn.Location = new System.Drawing.Point(329, 131);
            this.FolderSearchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.FolderSearchBtn.Name = "FolderSearchBtn";
            this.FolderSearchBtn.Primary = true;
            this.FolderSearchBtn.Size = new System.Drawing.Size(32, 36);
            this.FolderSearchBtn.TabIndex = 18;
            this.FolderSearchBtn.Text = "...";
            this.FolderSearchBtn.UseVisualStyleBackColor = true;
            this.FolderSearchBtn.Click += new System.EventHandler(this.FolderSearchBtn_Click);
            // 
            // FileSearchBtn
            // 
            this.FileSearchBtn.AutoSize = true;
            this.FileSearchBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileSearchBtn.Depth = 0;
            this.FileSearchBtn.Icon = null;
            this.FileSearchBtn.Location = new System.Drawing.Point(329, 80);
            this.FileSearchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.FileSearchBtn.Name = "FileSearchBtn";
            this.FileSearchBtn.Primary = true;
            this.FileSearchBtn.Size = new System.Drawing.Size(32, 36);
            this.FileSearchBtn.TabIndex = 19;
            this.FileSearchBtn.Text = "...";
            this.FileSearchBtn.UseVisualStyleBackColor = true;
            this.FileSearchBtn.Click += new System.EventHandler(this.FileSearchBtn_Click);
            // 
            // FolderNameTextBox
            // 
            this.FolderNameTextBox.Depth = 0;
            this.FolderNameTextBox.Hint = "Путь к каталогу";
            this.FolderNameTextBox.Location = new System.Drawing.Point(122, 85);
            this.FolderNameTextBox.MaxLength = 32767;
            this.FolderNameTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.FolderNameTextBox.Name = "FolderNameTextBox";
            this.FolderNameTextBox.PasswordChar = '\0';
            this.FolderNameTextBox.SelectedText = "";
            this.FolderNameTextBox.SelectionLength = 0;
            this.FolderNameTextBox.SelectionStart = 0;
            this.FolderNameTextBox.Size = new System.Drawing.Size(187, 23);
            this.FolderNameTextBox.TabIndex = 20;
            this.FolderNameTextBox.TabStop = false;
            this.FolderNameTextBox.UseSystemPasswordChar = false;
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Depth = 0;
            this.FileNameTextBox.Hint = "Путь к архиву";
            this.FileNameTextBox.Location = new System.Drawing.Point(122, 136);
            this.FileNameTextBox.MaxLength = 32767;
            this.FileNameTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.PasswordChar = '\0';
            this.FileNameTextBox.SelectedText = "";
            this.FileNameTextBox.SelectionLength = 0;
            this.FileNameTextBox.SelectionStart = 0;
            this.FileNameTextBox.Size = new System.Drawing.Size(187, 23);
            this.FileNameTextBox.TabIndex = 21;
            this.FileNameTextBox.TabStop = false;
            this.FileNameTextBox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 80);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(104, 38);
            this.materialLabel1.TabIndex = 22;
            this.materialLabel1.Text = "Укажите путь\r\nк каталогу";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 131);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(104, 38);
            this.materialLabel2.TabIndex = 23;
            this.materialLabel2.Text = "Укажите путь\r\n к архиву\r\n";
            // 
            // Arhive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 251);
            this.ControlBox = false;
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.FolderNameTextBox);
            this.Controls.Add(this.FileSearchBtn);
            this.Controls.Add(this.FolderSearchBtn);
            this.Controls.Add(this.FileArhiveBtn);
            this.Controls.Add(this.FolderArhiveBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.Exit);
            this.Name = "Arhive";
            this.Text = "Архивация";
            this.Load += new System.EventHandler(this.Arhive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Exit;
        private MaterialSkin.Controls.MaterialRaisedButton ExitBtn;
        private MaterialSkin.Controls.MaterialRaisedButton FolderArhiveBtn;
        private MaterialSkin.Controls.MaterialRaisedButton FileArhiveBtn;
        private MaterialSkin.Controls.MaterialRaisedButton FolderSearchBtn;
        private MaterialSkin.Controls.MaterialRaisedButton FileSearchBtn;
        private MaterialSkin.Controls.MaterialSingleLineTextField FolderNameTextBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField FileNameTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}