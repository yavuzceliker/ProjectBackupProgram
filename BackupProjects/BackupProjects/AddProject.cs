using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BackupProjects
{
    public partial class AddProject : Form
    {
        Project project = new Project(); // Eklenecek proje için yeni bir nesne oluşturuluyor.
        public AddProject()
        {
            InitializeComponent();
        }

        private void programLocationButton_Click(object sender, EventArgs e)
        {
            // Bu fonksiyon üzerinde geliştirme ortamının exe sinin seçilme işlemi gerçekleştirilmektedir.

            OpenFileDialog dialog = new OpenFileDialog(); // Projenin geliştirileceği geliştirme ortamının (Visual Studio, Android Studio vs.) exe dosyasını seçmek için bir fileDialog oluşturuluyor.
            DialogResult result = dialog.ShowDialog(); // Oluşturulan dialog açılıyor.
            if (result == DialogResult.OK) //Dialog üzerinden bir dosya seçimi yapıldıysa çalışacaktır.
            {
                project.programLocation = dialog.FileName; // Oluşturulan proje nesnesinin programLocation özelliğine dialog üzerinden seçilen dosya yolu ekleniyor.
                programLocationButton.Text = ".."+Functions.showLastNChar(dialog.FileName,25); //Önizleme için butonun text özelliğine program yolunun son 25 karakteri ekleniyor.
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
                backupFolderButton.Text = ".." + Functions.showLastNChar(dialog.SelectedPath, 25);
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
                browseIconButton.Text = ".." + Functions.showLastNChar(dialog.FileName, 25);
            }
        }
        private void projectIconDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bu fonksiyonda proje ikonunda metin yerine bir ikon ekleme seçeneğinin seçilmesi durumunda gerçekleşecek işlemler yapılacaktır.

            if (projectIconDropDown.SelectedIndex == 1) // 1. indis ikon seçeneğidir. Yani proje ikonunda metin yerine bir ikon seçmek anlamına gelmektedir.
            {
                //Bu durumda varsayılan olarak gizli olan yeni ikon seçeneği aktif ediliyor.

                //Gizli nesneler görüntüleniyor.
                browseIconButton.Visible = true;
                browseIconLabel.Visible = true;

                //Gizli nesnelerin diğer nesnelerin altında kalmaması için form ve formdaki nesneler aşağıya 25px kaydırılıyor.
                this.Height += 25;
                label5.Location = new Point(label5.Location.X, label5.Location.Y + 25);
                label6.Location = new Point(label6.Location.X, label6.Location.Y + 25);
                label7.Location = new Point(label7.Location.X, label7.Location.Y + 25);
                label10.Location = new Point(label10.Location.X, label10.Location.Y + 25);
                addProjectButton.Location = new Point(addProjectButton.Location.X, addProjectButton.Location.Y + 25);
            }
            else
            {
                //Varsayılan ikonlardan birisi tercih edildiği takdirde bu alan çalışacaktır.

                //Görüntülenmiş olan yeni ikon nesneleri gizleniyor.
                browseIconButton.Visible = false;
                browseIconLabel.Visible = false;

                //Gizli nesneler için aşağıya kaydırılmış olan form eski haline getiriliyor.
                this.Height = 381;
                label5.Location = new Point(label5.Location.X, 209);
                label6.Location = new Point(label6.Location.X, 243);
                label7.Location = new Point(label7.Location.X, 308);
                label10.Location = new Point(label10.Location.X, 274);
                addProjectButton.Location = new Point(addProjectButton.Location.X, 171);
            }
        }

        private void addProjectButton_Click(object sender, EventArgs e)
        {

            // Bu fonksiyon içinde yeni projenin kaydı yapılacaktır.

            //Gerekli elemanlardan boş olan olup olmadığı kontrol ediliyor. Boş eleman varsa uyarı döndürülüyor.
            if (project.programLocation == null || projectNameTextBox.Text == "" || project.projectFolder == null || project.backupFolder == null || backupPeriodDropDown.SelectedIndex == -1)
            {
                MessageBox.Show("Boş alan bırakmayınız.");
                return;
            }


            project.projectName = projectNameTextBox.Text; // Proje adı textboxtan, proje değişkenine atanıyor.
            project.backupPeriod = backupPeriodDropDown.SelectedItem.ToString(); // Yedekleme sıklığı dropdowndan proje değişkenine atanıyor.


            if (projectIconDropDown.SelectedIndex == -1) // Eğer bir ikon seçilmemişse uyarı döndürülüyor.
            {
                MessageBox.Show("Boş alan bırakmayınız.");
                return;
            }
            else
            {
                //Eğer seçilmiş bir ikon varsa burası çalışıyor.

                if (projectIconDropDown.SelectedIndex == 1) // Eğer metin yerine bir ikon seçilmiş ise if bloğu çalışıyor.
                {
                    if (project.projectIcon == null) // browseIconButton_Click fonksiyonu içerisinde seçilen ikon proje değişkenine atanmış mı kontrol ediliyor. Seçilmemişse uyarı döndürülüyor.
                    {
                        MessageBox.Show("Boş alan bırakmayınız.");
                        return;
                    }

                    int partCount = project.projectIcon.Split('.').Length; // Eklenen resmin formatını almak için gelen dosya yolu '.' karakterine göre parçalara ayrılıyor ve kaç parça olduğu alınıyor.
                    string fileType = project.projectIcon.Split('.')[partCount - 1]; // Son parça yani dosya uzantısı seçiliyor.

                    Directory.CreateDirectory("icons");
                    // Seçilmiş ikon isimlendirilerek icons klasörüne kaydediliyor.
                    File.Copy(project.projectIcon, "icons/" + Functions.TurkishCharacterToEnglish(project.projectName) + "." + fileType,true);

                    //ikon yolu proje değişkenine atanıyor.
                    project.projectIcon = "icons/" + Functions.TurkishCharacterToEnglish(project.projectName) + "." + fileType;
                }
                else
                {
                    project.projectIcon = "";
                }
            }

            
            Functions.addProject(project); // Oluşturulan proje değişkeni xml dosyasına yazılmak üzere addProject fonksiyonuna iletiliyor.

            Program.openForm( "addProject", "home", null); // Kayıt işlemi bitince home sayfasına yönlendiriliyor.
        }

        private void AddProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.openForm( "addProject", "home", null); // Form kapatıldığında home sayfasına yönlendiriliyor.
        }

    }
}
