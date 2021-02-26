
namespace BackupProjects
{
    partial class Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.webSiteLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emailLink = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // webSiteLink
            // 
            this.webSiteLink.AutoSize = true;
            this.webSiteLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.webSiteLink.Location = new System.Drawing.Point(154, 347);
            this.webSiteLink.Name = "webSiteLink";
            this.webSiteLink.Size = new System.Drawing.Size(122, 16);
            this.webSiteLink.TabIndex = 2;
            this.webSiteLink.TabStop = true;
            this.webSiteLink.Text = "yavuzceliker.com.tr";
            this.webSiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webSiteLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proje Yedekleyici 1.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(12, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "22.02.2021";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 98);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // emailLink
            // 
            this.emailLink.AutoSize = true;
            this.emailLink.Location = new System.Drawing.Point(12, 305);
            this.emailLink.Name = "emailLink";
            this.emailLink.Size = new System.Drawing.Size(137, 13);
            this.emailLink.TabIndex = 1;
            this.emailLink.TabStop = true;
            this.emailLink.Text = "yavuz@yavuzceliker.com.tr";
            this.emailLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.emailLink_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::BackupProjects.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(66, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Info
            // 
            this.AccessibleName = "info";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 372);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.emailLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webSiteLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Hakkında";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Info_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel webSiteLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel emailLink;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}