using System;
using System.Windows.Forms;

namespace BackupProjects
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.openForm("settings", "home", null); // Ayarlar sayfası kapatılınca geri home sayfasına yönlendiriliyor.
        }

        private void Settings_VisibleChanged(object sender, EventArgs e)
        {
            // Bu fonksiyon içerisinde sayfa her açıldığında projectsTable tablosunun içeriği dolduruluyor.
            if (this.Visible) // Sayfa show edildiğinde çalışacak.
            {
                projectsTable.Controls.Clear(); // Tablonun içeriği temizleniyor.

                foreach (var item in Project.getAllProjects()) // Kayıtlı tüm projeler okunuyor.
                {
                    Panel projectButton = Functions.createProjectButton(item, false,this); // Düzenleme butonları oluşturmak üzere createProjectIcon fonksiyonuna mevcut proje gönderiliyor.
                    if (projectButton != null) // Eğer buton oluşturulduysa çalışacak.
                    {
                        projectsTable.Controls.Add(projectButton); // Oluşturulan buton tabloya ekleniyor.
                    }
                }
            }
            
        }
    }
}
