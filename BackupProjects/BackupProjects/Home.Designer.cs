
namespace BackupProjects
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.projectsTable = new System.Windows.Forms.TableLayoutPanel();
            this.settingsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.infoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectsTable
            // 
            this.projectsTable.AutoSize = true;
            this.projectsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.projectsTable.ColumnCount = 2;
            this.projectsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.projectsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.projectsTable.Location = new System.Drawing.Point(2, 42);
            this.projectsTable.Name = "projectsTable";
            this.projectsTable.RowCount = 6;
            this.projectsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.projectsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.projectsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.projectsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.projectsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.projectsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.projectsTable.Size = new System.Drawing.Size(489, 501);
            this.projectsTable.TabIndex = 3;
            // 
            // settingsButton
            // 
            this.settingsButton.BackgroundImage = global::BackupProjects.Properties.Resources.settings;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingsButton.Location = new System.Drawing.Point(456, 4);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(35, 35);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(92, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Başlatacağınız projeyi seçiniz.";
            // 
            // infoButton
            // 
            this.infoButton.BackgroundImage = global::BackupProjects.Properties.Resources.info;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.infoButton.Location = new System.Drawing.Point(415, 4);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(35, 35);
            this.infoButton.TabIndex = 1;
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // Home
            // 
            this.AccessibleName = "home";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(493, 544);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.projectsTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Yedekleyici 1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Home_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel projectsTable;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button infoButton;
    }
}

