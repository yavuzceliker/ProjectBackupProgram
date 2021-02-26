
namespace BackupProjects
{
    partial class AddProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProject));
            this.label1 = new System.Windows.Forms.Label();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.programLocationButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backupPeriodDropDown = new System.Windows.Forms.ComboBox();
            this.projectFolderButton = new System.Windows.Forms.Button();
            this.addProjectButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.projectIconDropDown = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.browseIconLabel = new System.Windows.Forms.Label();
            this.browseIconButton = new System.Windows.Forms.Button();
            this.backupFolderButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proje Adı";
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(103, 12);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Program Konumu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proje Klasörü";
            // 
            // programLocationButton
            // 
            this.programLocationButton.Location = new System.Drawing.Point(103, 37);
            this.programLocationButton.Name = "programLocationButton";
            this.programLocationButton.Size = new System.Drawing.Size(184, 21);
            this.programLocationButton.TabIndex = 2;
            this.programLocationButton.Text = "Program Konumu Seç";
            this.programLocationButton.UseVisualStyleBackColor = true;
            this.programLocationButton.Click += new System.EventHandler(this.programLocationButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Yedekleme Sıklığı";
            // 
            // backupPeriodDropDown
            // 
            this.backupPeriodDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backupPeriodDropDown.FormattingEnabled = true;
            this.backupPeriodDropDown.Items.AddRange(new object[] {
            "Günlük",
            "Haftalık",
            "Aylık",
            "Her Açılışta"});
            this.backupPeriodDropDown.Location = new System.Drawing.Point(103, 117);
            this.backupPeriodDropDown.Name = "backupPeriodDropDown";
            this.backupPeriodDropDown.Size = new System.Drawing.Size(184, 21);
            this.backupPeriodDropDown.TabIndex = 5;
            // 
            // projectFolderButton
            // 
            this.projectFolderButton.Location = new System.Drawing.Point(103, 63);
            this.projectFolderButton.Name = "projectFolderButton";
            this.projectFolderButton.Size = new System.Drawing.Size(184, 21);
            this.projectFolderButton.TabIndex = 3;
            this.projectFolderButton.Text = "Proje Klasörü Seç";
            this.projectFolderButton.UseVisualStyleBackColor = true;
            this.projectFolderButton.Click += new System.EventHandler(this.projectFolderButton_Click);
            // 
            // addProjectButton
            // 
            this.addProjectButton.Location = new System.Drawing.Point(15, 171);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(272, 35);
            this.addProjectButton.TabIndex = 8;
            this.addProjectButton.Text = "Projeyi Kaydet";
            this.addProjectButton.UseVisualStyleBackColor = true;
            this.addProjectButton.Click += new System.EventHandler(this.addProjectButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(284, 34);
            this.label5.TabIndex = 11;
            this.label5.Text = "* Program konumu: Geliştirme ortamınızın exe dosyasının konumudur.";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 34);
            this.label6.TabIndex = 12;
            this.label6.Text = "* Proje Klasörü: Yedeklenmesini istediğiniz projeye ait klasörün konumudur.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(284, 34);
            this.label7.TabIndex = 13;
            this.label7.Text = "* Yedekeme Sıklığı: Kapsayıcı klasörde bulunan proje klasörlerinin ne sıklıkla ye" +
    "dekleneceğidir.";
            // 
            // projectIconDropDown
            // 
            this.projectIconDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectIconDropDown.FormattingEnabled = true;
            this.projectIconDropDown.Items.AddRange(new object[] {
            "Varsayılan İkon",
            "Yeni İkon"});
            this.projectIconDropDown.Location = new System.Drawing.Point(103, 144);
            this.projectIconDropDown.Name = "projectIconDropDown";
            this.projectIconDropDown.Size = new System.Drawing.Size(184, 21);
            this.projectIconDropDown.TabIndex = 6;
            this.projectIconDropDown.SelectedIndexChanged += new System.EventHandler(this.projectIconDropDown_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Proje İkonu";
            // 
            // browseIconLabel
            // 
            this.browseIconLabel.AutoSize = true;
            this.browseIconLabel.Location = new System.Drawing.Point(12, 174);
            this.browseIconLabel.Name = "browseIconLabel";
            this.browseIconLabel.Size = new System.Drawing.Size(52, 13);
            this.browseIconLabel.TabIndex = 16;
            this.browseIconLabel.Text = "Yeni İkon";
            this.browseIconLabel.Visible = false;
            // 
            // browseIconButton
            // 
            this.browseIconButton.Location = new System.Drawing.Point(103, 170);
            this.browseIconButton.Name = "browseIconButton";
            this.browseIconButton.Size = new System.Drawing.Size(184, 21);
            this.browseIconButton.TabIndex = 8;
            this.browseIconButton.Text = "İkon Seç";
            this.browseIconButton.UseVisualStyleBackColor = true;
            this.browseIconButton.Visible = false;
            this.browseIconButton.Click += new System.EventHandler(this.browseIconButton_Click);
            // 
            // backupFolderButton
            // 
            this.backupFolderButton.Location = new System.Drawing.Point(103, 90);
            this.backupFolderButton.Name = "backupFolderButton";
            this.backupFolderButton.Size = new System.Drawing.Size(184, 21);
            this.backupFolderButton.TabIndex = 4;
            this.backupFolderButton.Text = "Yedek Klasörü Seç";
            this.backupFolderButton.UseVisualStyleBackColor = true;
            this.backupFolderButton.Click += new System.EventHandler(this.backupFolderButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Yedek Klasörü";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(284, 34);
            this.label10.TabIndex = 20;
            this.label10.Text = "* Yedek Klasörü: Proje klasörünün vakti geldikçe yedekleneceği klasörün konumudur" +
    ".";
            // 
            // AddProject
            // 
            this.AccessibleName = "addProject";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(299, 342);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.backupFolderButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.browseIconButton);
            this.Controls.Add(this.browseIconLabel);
            this.Controls.Add(this.projectIconDropDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addProjectButton);
            this.Controls.Add(this.backupPeriodDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.programLocationButton);
            this.Controls.Add(this.projectFolderButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Proje";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddProject_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button programLocationButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox backupPeriodDropDown;
        private System.Windows.Forms.Button projectFolderButton;
        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox projectIconDropDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label browseIconLabel;
        private System.Windows.Forms.Button browseIconButton;
        private System.Windows.Forms.Button backupFolderButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}