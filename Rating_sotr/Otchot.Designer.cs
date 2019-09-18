namespace Rating_sotr
{
    partial class Otchot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Otchot));
            this.ExitImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ExitImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitImg
            // 
            this.ExitImg.BackColor = System.Drawing.Color.Transparent;
            this.ExitImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitImg.BackgroundImage")));
            this.ExitImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExitImg.Location = new System.Drawing.Point(536, 3);
            this.ExitImg.Name = "ExitImg";
            this.ExitImg.Size = new System.Drawing.Size(16, 18);
            this.ExitImg.TabIndex = 1;
            this.ExitImg.TabStop = false;
            this.ExitImg.Click += new System.EventHandler(this.ExitImg_Click);
            // 
            // Otchot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.ControlBox = false;
            this.Controls.Add(this.ExitImg);
            this.Name = "Otchot";
            this.Text = "Параметры отчета";
            this.Load += new System.EventHandler(this.Otchot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExitImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ExitImg;
    }
}