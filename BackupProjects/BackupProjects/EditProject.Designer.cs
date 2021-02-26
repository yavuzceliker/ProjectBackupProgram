
namespace BackupProjects
{
    partial class EditProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProject));
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteProjectButton = new System.Windows.Forms.Button();
            this.backupFolderButton = new System.Windows.Forms.Button();
            this.projectFolderButton = new System.Windows.Forms.Button();
            this.programLocationButton = new System.Windows.Forms.Button();
            this.browseIconButton = new System.Windows.Forms.Button();
            this.browseIconLabel = new System.Windows.Forms.Label();
            this.projectIconDropDown = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.editProjectButton = new System.Windows.Forms.Button();
            this.backupPeriodDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.projectIconButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.projectNameLabel.Location = new System.Drawing.Point(132, 12);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(277, 75);
            this.projectNameLabel.TabIndex = 1;
            this.projectNameLabel.Text = "Visual Studio";
            this.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Program Konumu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proje Klasörü:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Yedekleme Klasörü:";
            // 
            // deleteProjectButton
            // 
            this.deleteProjectButton.ForeColor = System.Drawing.Color.Red;
            this.deleteProjectButton.Location = new System.Drawing.Point(225, 266);
            this.deleteProjectButton.Name = "deleteProjectButton";
            this.deleteProjectButton.Size = new System.Drawing.Size(197, 35);
            this.deleteProjectButton.TabIndex = 9;
            this.deleteProjectButton.Text = "Projeyi Sil";
            this.deleteProjectButton.UseVisualStyleBackColor = true;
            this.deleteProjectButton.Click += new System.EventHandler(this.deleteProjectButton_Click);
            // 
            // backupFolderButton
            // 
            this.backupFolderButton.Location = new System.Drawing.Point(137, 183);
            this.backupFolderButton.Name = "backupFolderButton";
            this.backupFolderButton.Size = new System.Drawing.Size(285, 23);
            this.backupFolderButton.TabIndex = 4;
            this.backupFolderButton.Text = "Yedek Klasörünü Değiştir";
            this.backupFolderButton.UseVisualStyleBackColor = true;
            this.backupFolderButton.Click += new System.EventHandler(this.backupFolderButton_Click);
            // 
            // projectFolderButton
            // 
            this.projectFolderButton.Location = new System.Drawing.Point(137, 154);
            this.projectFolderButton.Name = "projectFolderButton";
            this.projectFolderButton.Size = new System.Drawing.Size(285, 23);
            this.projectFolderButton.TabIndex = 3;
            this.projectFolderButton.Text = "Proje Klasörünü Değiştir";
            this.projectFolderButton.UseVisualStyleBackColor = true;
            this.projectFolderButton.Click += new System.EventHandler(this.projectFolderButton_Click);
            // 
            // programLocationButton
            // 
            this.programLocationButton.Location = new System.Drawing.Point(137, 125);
            this.programLocationButton.Name = "programLocationButton";
            this.programLocationButton.Size = new System.Drawing.Size(285, 23);
            this.programLocationButton.TabIndex = 2;
            this.programLocationButton.Text = "Program Konumunu Değiştir";
            this.programLocationButton.UseVisualStyleBackColor = true;
            this.programLocationButton.Click += new System.EventHandler(this.programLocationButton_Click);
            // 
            // browseIconButton
            // 
            this.browseIconButton.Location = new System.Drawing.Point(137, 266);
            this.browseIconButton.Name = "browseIconButton";
            this.browseIconButton.Size = new System.Drawing.Size(285, 21);
            this.browseIconButton.TabIndex = 7;
            this.browseIconButton.Text = "İkon Seç";
            this.browseIconButton.UseVisualStyleBackColor = true;
            this.browseIconButton.Visible = false;
            this.browseIconButton.Click += new System.EventHandler(this.browseIconButton_Click);
            // 
            // browseIconLabel
            // 
            this.browseIconLabel.AutoSize = true;
            this.browseIconLabel.Location = new System.Drawing.Point(12, 270);
            this.browseIconLabel.Name = "browseIconLabel";
            this.browseIconLabel.Size = new System.Drawing.Size(52, 13);
            this.browseIconLabel.TabIndex = 23;
            this.browseIconLabel.Text = "Yeni İkon";
            this.browseIconLabel.Visible = false;
            // 
            // projectIconDropDown
            // 
            this.projectIconDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectIconDropDown.FormattingEnabled = true;
            this.projectIconDropDown.Items.AddRange(new object[] {
            "Varsayılan İkon",
            "Yeni İkon"});
            this.projectIconDropDown.Location = new System.Drawing.Point(137, 239);
            this.projectIconDropDown.Name = "projectIconDropDown";
            this.projectIconDropDown.Size = new System.Drawing.Size(285, 21);
            this.projectIconDropDown.TabIndex = 6;
            this.projectIconDropDown.SelectedIndexChanged += new System.EventHandler(this.projectIconDropDown_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Proje İkonu";
            // 
            // editProjectButton
            // 
            this.editProjectButton.Location = new System.Drawing.Point(15, 266);
            this.editProjectButton.Name = "editProjectButton";
            this.editProjectButton.Size = new System.Drawing.Size(208, 35);
            this.editProjectButton.TabIndex = 8;
            this.editProjectButton.Text = "Projeyi Kaydet";
            this.editProjectButton.UseVisualStyleBackColor = true;
            this.editProjectButton.Click += new System.EventHandler(this.editProjectButton_Click);
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
            this.backupPeriodDropDown.Location = new System.Drawing.Point(137, 212);
            this.backupPeriodDropDown.Name = "backupPeriodDropDown";
            this.backupPeriodDropDown.Size = new System.Drawing.Size(285, 21);
            this.backupPeriodDropDown.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Yedekleme Sıklığı";
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(204, 92);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(218, 20);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Proje Adı:";
            // 
            // projectIconButton
            // 
            this.projectIconButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.projectIconButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.projectIconButton.Location = new System.Drawing.Point(12, 13);
            this.projectIconButton.Name = "projectIconButton";
            this.projectIconButton.Size = new System.Drawing.Size(101, 99);
            this.projectIconButton.TabIndex = 27;
            this.projectIconButton.UseVisualStyleBackColor = true;
            // 
            // EditProject
            // 
            this.AccessibleName = "editProject";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 308);
            this.Controls.Add(this.projectIconButton);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.browseIconButton);
            this.Controls.Add(this.browseIconLabel);
            this.Controls.Add(this.projectIconDropDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.editProjectButton);
            this.Controls.Add(this.backupPeriodDropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.projectFolderButton);
            this.Controls.Add(this.backupFolderButton);
            this.Controls.Add(this.programLocationButton);
            this.Controls.Add(this.deleteProjectButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Düzenle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditProject_FormClosed);
            this.VisibleChanged += new System.EventHandler(this.EditProject_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteProjectButton;
        private System.Windows.Forms.Button backupFolderButton;
        private System.Windows.Forms.Button projectFolderButton;
        private System.Windows.Forms.Button programLocationButton;
        private System.Windows.Forms.Button browseIconButton;
        private System.Windows.Forms.Label browseIconLabel;
        private System.Windows.Forms.ComboBox projectIconDropDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button editProjectButton;
        private System.Windows.Forms.ComboBox backupPeriodDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button projectIconButton;
    }
}