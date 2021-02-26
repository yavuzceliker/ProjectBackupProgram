using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BackupProjects
{
    public partial class EditProject : Form
    {
        public Project project; // Parametre olarak gelecek projeyi tutacak değişken.
        public EditProject(Project project)
        {
            this.project = project; // parametre olarak gelen proje değişkene atanıyor.
            InitializeComponent();
        }

        private void EditProject_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) // Sayfa show edildiğinde proje içeriği doldurulacaktır.
            {
                // Proje içeriği ilgili alanlara getiriliyor.
                programLocationButton.Text = Functions.showLastNChar(project.programLocation, 40);
                projectNameLabel.Text = project.projectName;
                projectNameTextBox.Text = project.projectName;
                backupFolderButton.Text = Functions.showLastNChar(project.backupFolder, 40);
                projectFolderButton.Text = Functions.showLastNChar(project.projectFolder, 40);
                backupPeriodDropDown.SelectedItem = project.backupPeriod;

                // Proje ikonu metin modundaysa projectIcon null gelecektir. Bu durumda ikon resmi null hale getirilir ve text girilir.
                if (project.projectIcon=="")
                {
                    projectIconButton.BackgroundImage = Properties.Resources.icon;
                    projectIconDropDown.SelectedIndex = 0;
                }
                else // Eğer projectIcon null değil ise proje ikonu resim modundadır. Bu durumda text null olur ve resim girilir.
                {
                    projectIconButton.BackgroundImage = Bitmap.FromFile(project.projectIcon);
                    projectIconDropDown.SelectedIndex = 1;
                }
            }
        }


        private void programLocationButton_Click(object sender, EventArgs e)
        {
            // Bu fonksiyon üzerinde geliştirme ortamının exe sinin seçilme işlemi gerçekleştirilmektedir.

            OpenFileDialog dialog = new OpenFileDialog(); // Projenin geliştirileceği geliştirme ortamının (Visual Studio, Android Studio vs.) exe dosyasını seçmek için bir fileDialog oluşturuluyor.
            DialogResult result = dialog.ShowDialog(); // Oluşturulan dialog açılıyor.
            if (result == DialogResult.OK) //Dialog üzerinden bir dosya seçimi yapıldıysa çalışacaktır.
            {
                project.programLocation = dialog.FileName; // Oluşturulan proje nesnesinin programLocation özelliğine dialog üzerinden seçilen dosya yolu ekleniyor.
                programLocationButton.Text = ".." + Functions.showLastNChar(dialog.FileName, 40); //Önizleme için butonun text özelliğine program yolunun son 25 karakteri ekleniyor.
            }
        }
        private void browseIconButton_Click(object sender, EventArgs e)
        {
            // Bu fonksiyonda programLocationButton_Click fonksiyonunda yapılanların aynısı proje ikonu için yapılmaktadır.
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                project.projectIcon = dialog.FileName;
                projectIconButton.BackgroundImage = Bitmap.FromFile(dialog.FileName);
                browseIconButton.Text = Functions.showLastNChar(dialog.FileName, 40);
                projectIconButton.BackgroundImage = Bitmap.FromFile(dialog.FileName); // Seçilen varsayıllan ikon önizleme için pictureBox'a basılıyor.
            }
        }
        private void projectIconDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bu fonksiyonda proje ikonunda metin yerine bir ikon ekleme seçeneğinin seçilmesi durumunda gerçekleşecek işlemler yapılacaktır.

            if (projectIconDropDown.SelectedIndex == 1) // 1. indis ikon seçeneğidir. Yani buton içerisinde bir metin yerine bir ikon seçmek anlamına gelmektedir.
            {
                //Bu durumda varsayılan olarak gizli olan yeni ikon seçeneği aktif ediliyor.

                //Gizli nesneler görüntüleniyor.
                browseIconButton.Visible = true;
                browseIconLabel.Visible = true;
                //Gizli nesnelerin diğer nesnelerin altında kalmaması için form ve formdaki nesneler aşağıya 25px kaydırılıyor.
                this.Height += 25;
                editProjectButton.Location = new Point(editProjectButton.Location.X, editProjectButton.Location.Y + 25);
                deleteProjectButton.Location = new Point(deleteProjectButton.Location.X, deleteProjectButton.Location.Y + 25);

            }
            else
            {
                //Varsayılan ikonlardan birisi tercih edildiği takdirde bu alan çalışacaktır.

                //Görüntülenmiş olan yeni ikon nesneleri gizleniyor.
                browseIconButton.Visible = false;
                browseIconLabel.Visible = false;

                //Gizli nesneler için aşağıya kaydırılmış olan form eski haline getiriliyor.
                this.Height = 347;

                editProjectButton.Location = new Point(editProjectButton.Location.X, 266);
                deleteProjectButton.Location = new Point(deleteProjectButton.Location.X, 266);

                projectIconButton.BackgroundImage = Properties.Resources.icon; // Varsayılan ikon modu seçildiği için ikon atanıyor.
            }
        }
        private void projectFolderButton_Click(object sender, EventArgs e)
        {
            //Bu fonksiyon üzerinde yedeklenmesi istenen proje klasörünün seçilme işlemi yapılmaktadır.

            FolderBrowserDialog dialog = new FolderBrowserDialog(); // Proje klasörünü seçmek için bir folderDialog oluşturuluyor.
            DialogResult result = dialog.ShowDialog(); // dialog açılıyor.

            if (result == DialogResult.OK) // Eğer dialogtan bir klasör seçildiyse çalışacaktır.
            {
                project.projectFolder = dialog.SelectedPath; // Oluşturulan proje nesnesinin projectFolder özelliğine dialogtan seçilen klasör yolu ekleniyor.
                projectFolderButton.Text = ".." + Functions.showLastNChar(dialog.SelectedPath, 25); // Önizleme için seçilen klasör yolunun son 25 karakteri buton textine ekleniyor.
            }
        }
        private void backupFolderButton_Click(object sender, EventArgs e)
        {
            // Bu fonksiyon içerisinde projectFolderButton_Click fonksiyonunda yapılan işlemlerin aynısı yedekleme klasörü için yapılmaktadır.
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                project.backupFolder = dialog.SelectedPath;
                backupFolderButton.Text = Functions.showLastNChar(dialog.SelectedPath,40);
            }
        }


        private void editProjectButton_Click(object sender, EventArgs e)
        {
            // Bu fonksiyonda proje düzenlemeleri kontrol edilerek kayıt edilecektir.

            //Proje içeriğinde boş bırakılmış alan var mı kontrol ediliyor. Boş alan varsa uyarı döndürülüyor.
            if (project.programLocation == null || projectNameTextBox.Text == "" || project.projectFolder == null || project.backupFolder == null || backupPeriodDropDown.SelectedIndex == -1)
            {
                MessageBox.Show("Boş alan bırakmayınız.");
                return;
            }

            //İlgili değerler proje değişkenine atanıyor.
            project.projectName = projectNameTextBox.Text;
            project.backupPeriod = backupPeriodDropDown.SelectedItem.ToString();


            if (projectIconDropDown.SelectedIndex == -1) // Proje ikonu seçilmemiş ise uyarı döndürülür.
            {
                MessageBox.Show("Boş alan bırakmayınız.");
                return;
            }
            else
            {
                if (projectIconDropDown.SelectedIndex == 1) // Resim seçeneği aktif ise bu kısım çalışır.
                {
                    if (project.projectIcon == null) // Eğer browseIconButton_Click fonksiyonunda ikon seçilip proje değişkenine atanmamış ise uyarı döndürülür.
                    {
                        MessageBox.Show("Boş alan bırakmayınız.");
                        return;
                    }

                    int partCount = project.projectIcon.Split('.').Length; // İkon yolu '.' karakterine göre parçalanır ve parça sayısı değişkene atanır.
                    string fileType = project.projectIcon.Split('.')[partCount - 1]; // ikon yolundaki son parça alınır. Bu parça dosya uzantısını verir. 

                    //Gelen ikon dosyası icons klasörüne kaydedilir ve proje değişkenindeki ilgili alana ikon yolu atanır.
                    File.Copy(project.projectIcon, "icons/" + Functions.TurkishCharacterToEnglish(project.projectName) + "." + fileType,true); 
                    project.projectIcon = "icons/" + Functions.TurkishCharacterToEnglish(project.projectName) + "." + fileType;
                }
                else
                {  // Eğer resim modu seçili değil ise metin modu seçilidir ve projectIcon null hale getirilir.
                    project.projectIcon ="";
                }
            }

            Functions.updateProject(project); // Güncellenen proje değişkeni kaydedilmek üzere ilgili fonksiyona gönderilir.

            Program.openForm( "editProject", "settings", null); // İşlem tamamlandıktan sonra sttings sayfasına yönlendirilir.
        }


        private void deleteProjectButton_Click(object sender, EventArgs e)
        {
            //Bu fonksiyon üzerinden silmek istediğimiz projeyi siliyoruz.

            DialogResult dialog = new DialogResult(); // Projenin silinmek istendiğinden emin olmak için bir dialogResult oluşturuluyor.
            dialog = MessageBox.Show("Projeyi silmek istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo); // Dialog içeriği dolduruluyor.
            if (dialog == DialogResult.Yes) // Kullanıcı yes durumunu seçerse proje siliniyor.
            {
                Functions.deleteProject(project);
            }
            else // Kullanıcı no durumunu seçerse işlem iptal ediliyor.
            {
                MessageBox.Show("İşlem iptal edildi.");
            }
        }
        private void EditProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.openForm("editProject", "settings", null); // Sayfa kapatılınca settings sayfasına gönderiliyor.
        }

    }
}
