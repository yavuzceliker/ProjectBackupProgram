using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BackupProjects
{
    public partial class Home : Form
    {
        /*
             * Tarih:22.02.2020
             * Yazan: Yavuz ÇELİKER
             * Email: yavuz@yavuzceliker.com.tr
             * Kod Türü: C#
             * Tanım: Hazırlanan projenin açılış sayfasını çalıştıracak form.
        */

        public Home()
        {
            InitializeComponent();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Program.openForm("home", "settings", null); // Settings formuna geçiş sağlayacak fonksiyon.
        }
        private void infoButton_Click(object sender, EventArgs e)
        {
            Program.openForm("home", "info", null); // Info formuna geçiş sağlayacak fonksiyon.
        }
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Proje kapatılırken arkada gizli bir form olması durumunda proje kapatılmayacağından dolayı, proje manuel olarak sonlandırılıyor.
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
            }
        }


        private void Home_VisibleChanged(object sender, EventArgs e)
        {
            //Bu fonksiyon içerisinde form her görünür olduğunda içeriğin güncellenmesini sağlayacak kodlar vardır.

            if (this.Visible)//Mevcut form görünür ise çalışacaktır.
            {
                projectsTable.Controls.Clear(); // Çalıştırılabilecek projeleri tutacak olan tablodaki elemanlar temizleniyor.

                foreach (var item in Project.getAllProjects()) // Daha önce programa kaydedilmiş tüm projeler getiriliyor.
                {
                    Panel projectButton = Functions.createProjectButton(item, false, this); // Getirilen proje bilgisi createProjectIcon fonksiyonuna iletilerek ilgili projeyi açmak için kullanılacak bir button çağrılıyor.

                    if (projectButton != null) // Bir buton çağrılıp çağrılmadığı kontrol ediliyor.
                    {
                        projectsTable.Controls.Add(projectButton); // Oluşturulan buton tabloya ekleniyor.
                    }
                }

                if (projectsTable.Controls.Count < 25) // Mevcutta bulunan 25 proje ekleme sınırından daha az proje varsa, yeni proje eklemek için bir + butonu oluşturuluyor. 
                {
                    Panel projectButton = Functions.createProjectButton(null, true, this); // Bir + butonu oluşturulacağı için parametre olarak bir proje göndermeye gerek yoktur.
                    if (projectButton != null)
                    {
                        projectsTable.Controls.Add(projectButton); // Oluşturulan buton tabloya ekleniyor.
                    }
                }
            }

        }
    }
}
