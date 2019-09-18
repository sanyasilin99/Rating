namespace Rating_sotr
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.ExitImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ExitImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitImg
            // 
            this.ExitImg.BackColor = System.Drawing.Color.Transparent;
            this.ExitImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitImg.BackgroundImage")));
            this.ExitImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExitImg.Location = new System.Drawing.Point(648, 3);
            this.ExitImg.Name = "ExitImg";
            this.ExitImg.Size = new System.Drawing.Size(16, 18);
            this.ExitImg.TabIndex = 0;
            this.ExitImg.TabStop = false;
            this.ExitImg.Click += new System.EventHandler(this.ExitImg_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 638);
            this.ControlBox = false;
            this.Controls.Add(this.ExitImg);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ГЛАВНАЯ СТРАНИЦА";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExitImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ExitImg;
    }
}