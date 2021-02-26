using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BackupProjects
{
    public class Functions
    {

        public static void addProject(Project project)
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile parametre olarak aldığımız projeyi xml dosyasına kaydediyoruz.
            */

            string xmlDocPath = "data.xml"; // xml dosyasının yolu alınıyor.

            XDocument x = XDocument.Load(xmlDocPath); // yeni bir xml dokümanı açılıyor.
            project.projectID = Project.nextProjectID(); // yeni projeye tanımlayıcı bir ID vermek için son eklenen projeye bakılarak bir fazla numara üretiliyor.
            x.Element("Projects").Add(project.toXml()); // proje ID'si atandıktan sonra proje xml formatına çevrilerek xml dosyasına ekleniyor.
            x.Save(xmlDocPath); // xml dosyası kaydediliyor.
        }
        public static void updateProject(Project project)
        {
            XDocument x = XDocument.Load("data.xml");
            XElement node = x.Element("Projects").Elements("Project").FirstOrDefault(a => a.Element("projectID").Value == project.projectID.ToString());
            if (node != null)
            {
                node.SetElementValue("backupFolder", project.backupFolder);
                node.SetElementValue("backupPeriod", project.backupPeriod);
                node.SetElementValue("lastBackup", project.lastBackup);
                node.SetElementValue("projectIcon", project.projectIcon);
                node.SetElementValue("programLocation", project.programLocation);
                node.SetElementValue("projectName", project.projectName);
                node.SetElementValue("projectFolder", project.projectFolder);
                x.Save("data.xml");
            }
        }
        public static void deleteProject(Project project)
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile parametre olarak aldığımız projeyi xml dosyasından siliyoruz.
            */
            XDocument x = XDocument.Load("data.xml");

            if (project == null)
            {
                MessageBox.Show("Proje silinemedi.");
                return;
            }
            x.Root.Elements().FirstOrDefault(a => a.Element("projectID").Value == project.projectID.ToString()).Remove();
            x.Save("data.xml");
            MessageBox.Show("Proje başarıyla silindi.");
            Program.openForm("editProject", "settings", null);

        }
        private static void backupProjects(Project project, Form activeForm)
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile belirlenen zaman aralığına ulaşan projeler yedekleniyor ve daha sonra projenin geliştirildiği ortam çalıştırılıyor.
            */
            Directory.CreateDirectory(project.backupFolder);
            DirectoryInfo backupDirInfo = new DirectoryInfo(project.backupFolder); // Parametre olarak gelen projenin klasör bilgisi alınıyor.

            bool backupTime = true; // Varsayılan olarak true atanan bu değişken döngü içerisinde false olursa yedekleme zamanı gelmemiş demektir.

            foreach (var item in backupDirInfo.GetDirectories()) // Yukarıda tanımlanan yedekleme klasörünün içindeki klasörler alınıyor.
            {
                /*
                
                Programın yedek klasörlerinin isimleri tarih olarak verilmektedir.
                Verilen isim formatı yyyy-MM-dd-HH-mm şeklindedir. Bundan dolayı klasör isim uzunluğu 16 karakter olmalıdır.

                 */
                if (item.Name.Length == 16)
                {
                    string dateString = Functions.showLastNChar(item.FullName, 16); // Hazırlanan fonksiyon ile ilgili yedek klasörünün yolunun son 16 karakterini alıyoruz.
                    /*
                     * Eğer klasör bir yedek klasörü ise dateString değeri 2020-12-31-23-59 gibi bir değer olacaktır.
                     * Oluşturduğumuz dateString isimli değişkeni aşağıda belirttiğimiz formatta bir tarih olarak kabul ederek dönüştürülecektir. 
                    */

                    if (!DateTime.TryParseExact(dateString, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime backupDate))
                        continue;
                    /*
                     * Eğer ki dateString uygun bir formatta değilse veya bir yedek klasörü değilde örneğin "C# Yedek Dosya" gibi daha sonra eklenmişse
                     * continue diyerek sıradaki klasörü okuyoruz.
                    */


                    switch (project.backupPeriod) // Gelen projenin yedekleme sıklığı alınıyor.
                    {
                        /*
                        Eğer backupDate değişkenine atanmış olan yedek tarihi ile şimdiki zamanın farkı yedekleme aralığından az ise yedekleme yapılmıyor.
                        Yani haftalık yedek aralığına sahip bir proje için, son yedek alınan tarih 10 Mayıs ise ve şu an 12 Mayıs ise yedek alınmaz. Çünkü gün farkı 2dir.
                        Ama eğer bugün 18 Mayıs olsaydı gün farkı 8 olacağı için if koşulu sağlanmayacak ve backupTime true olarak kalacağı için switch sonunda yedek alınacaktı.
                         */
                        case "Günlük":
                            {
                                if ((DateTime.Now - backupDate).Days < 1) // İki tarih arasındaki fark 1 günden az ise yedekleme yapılmaması için backupTime false yapılıyor.
                                    backupTime = false;
                                break;
                            }
                        case "Haftalık":
                            {
                                if ((DateTime.Now - backupDate).Days < 7) // İki tarih arasındaki fark 7 günden az ise yedekleme yapılmaması için backupTime false yapılıyor.
                                    backupTime = false;
                                break;
                            }
                        case "Aylık":
                            {
                                if ((DateTime.Now - backupDate).Days < 30) // İki tarih arasındaki fark 30 günden az ise yedekleme yapılmaması için backupTime false yapılıyor.
                                    backupTime = false;
                                break;
                            }
                        case "Her Açılışta":
                            {
                                backupTime = true; // Her açılışta yedek alınacağı için backupTime her zaman true kalacaktır.
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Güncelleme zaman aralığı alınamadı.");
                                break;
                            }
                    }
                }
            }

            if(backupTime)
                foreach (var item in backupDirInfo.GetFiles()) // Yukarıda tanımlanan yedekleme klasörünün içindeki dosyalar alınıyor. Arşivlenmiş yedekler için.
                {
                    /*

                    Programın yedek arşivlerinin isimleri tarih olarak verilmektedir.
                    Verilen isim formatı yyyy-MM-dd-HH-mm şeklindedir. Bundan dolayı klasör isim uzunluğu 16 karakter olmalıdır + '.zip' ile birlikte 20 karakter.

                     */
                    if (item.Name.Length == 20)
                    {
                        string dateString = Functions.showLastNChar(item.FullName, 20).Substring(0,16); // Hazırlanan fonksiyon ile ilgili yedek klasörünün yolunun son 20 karakterini alıyoruz. Bunun da ilk 16 karakterini alıyoruz.
                        /*
                         * Eğer klasör bir yedek arşivi ise dateString değeri 2020-12-31-23-59 gibi bir değer olacaktır.
                         * Oluşturduğumuz dateString isimli değişkeni aşağıda belirttiğimiz formatta bir tarih olarak kabul ederek dönüştürülecektir. 
                        */

                        if (!DateTime.TryParseExact(dateString, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime backupDate))
                            continue;
                        /*
                         * Eğer ki dateString uygun bir formatta değilse veya bir yedek klasörü değilde örneğin "C# Yedek Dosya" gibi daha sonra eklenmişse
                         * continue diyerek sıradaki klasörü okuyoruz.
                        */


                        switch (project.backupPeriod) // Gelen projenin yedekleme sıklığı alınıyor.
                        {
                            /*
                            Eğer backupDate değişkenine atanmış olan yedek tarihi ile şimdiki zamanın farkı yedekleme aralığından az ise yedekleme yapılmıyor.
                            Yani haftalık yedek aralığına sahip bir proje için, son yedek alınan tarih 10 Mayıs ise ve şu an 12 Mayıs ise yedek alınmaz. Çünkü gün farkı 2dir.
                            Ama eğer bugün 18 Mayıs olsaydı gün farkı 8 olacağı için if koşulu sağlanmayacak ve backupTime true olarak kalacağı için switch sonunda yedek alınacaktı.
                             */
                            case "Günlük":
                                {
                                    if ((DateTime.Now - backupDate).Days < 1) // İki tarih arasındaki fark 1 günden az ise yedekleme yapılmaması için backupTime false yapılıyor.
                                        backupTime = false;
                                    break;
                                }
                            case "Haftalık":
                                {
                                    if ((DateTime.Now - backupDate).Days < 7) // İki tarih arasındaki fark 7 günden az ise yedekleme yapılmaması için backupTime false yapılıyor.
                                        backupTime = false;
                                    break;
                                }
                            case "Aylık":
                                {
                                    if ((DateTime.Now - backupDate).Days < 30) // İki tarih arasındaki fark 30 günden az ise yedekleme yapılmaması için backupTime false yapılıyor.
                                        backupTime = false;
                                    break;
                                }
                            case "Her Açılışta":
                                {
                                    backupTime = true; // Her açılışta yedek alınacağı için backupTime her zaman true kalacaktır.
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Güncelleme zaman aralığı alınamadı.");
                                    break;
                                }
                        }
                    }
                }

            if (backupTime) // Eğer backupTime true ise yani yakın zamanda alınmış bir yedek yoksa yedekleme alınır.
            {
                activeForm.Hide(); // Yedekleme işlemi uzun sürebileceği için bekleme sayfası gözükeceğinden mevcut sayfa gizlenir.

                Loading loading = new Loading(); // Uzun sürebilecek işlemler için hazırlanan yükleniyor sayfası oluşturuluyor.
                loading.Show(); // Oluşturulan sayfa açılıyor.

                Task t = Task.Run(() => // Yedekleme işlemi uzun süreceği için program akışını kilitlememesi için bir task içerisinde gerçekleştirildi.
                {
                    //Proje yedekleme için iki seçenek var. Bir seçenek arşiv oluşturmadan direkt olarak klasörleri kopyalıyor.
                    //Diğer seçenekte ise proje klasörü arşivlendikten sonra yedek klasörüne atılıyor.

                    //directoryCopy fonksiyonu arşivlemeden direkt klasörü kopyalıyor. 
                    //ZipFile.CreateFromDirectory fonksiyonu ise bir zip dosyası oluşturuyor.

                    //Bu iki fonksiyonda da proje klasörü ve yedeklemenin yapılacağı klasör girilerek yedekleme işlemi başlatılıyor.
                    //Zip fonksiyonunda ekstra olarak sıkıştırma türünü ve ana klasörün dahil edilip edilmeyeceği de seçiliyor.
                    //Test edilen 1GB'lık proje sıkıştırıldığında klasöründe optimal modda 89sn. sürede boyut 425MB'a düşerken, fastest modda 39sn. sürede boyut 452MB'a düştü.
                    //Test edilen 1GB'lık proje sıkıştırılmadan klasör kopyalama fonksiyonu ile 21sn. sürede kopyalandı.

                    //Yedekleme klasörünün yanına eklenen zaman damgası şudur. Örneğin: ..Yedekler/C#/2020-12-31-23-59
                    //Yani yedek klasörüne şu anın tarihiyle bir klasör açıp, içine yedeklenecek dosyalar atılıyor.
                    //Zip arşivi oluşturulurken de Yedekler/C#/2020-12-31-23-59.zip şeklinde yedekleme zamanı isminde bir zip dosyası oluşturuluyor.


                    //string result = directoryCopy(project.projectFolder, project.backupFolder + "/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm"));
                    ZipFile.CreateFromDirectory(project.projectFolder, project.backupFolder + "/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".zip", CompressionLevel.Optimal, true);

                    project.lastBackup = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
                    Functions.updateProject(project); // Yedekleme fonksiyonundan gelen işlem sonucu mesaj olarak ekrana bastırılıyor.
                    MessageBox.Show("Yedekleme tamamlandı.");
                })
                    .ContinueWith(task => // Yedekleme işleminin tamamlanmasından sonra yükleniyor sayfası gizeniyor ve proje geliştirme ortamı açılıyor.
                    {
                        loading.Close();
                        System.Diagnostics.Process.Start(project.programLocation);

                    }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                if (!DateTime.TryParseExact(project.lastBackup, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime lastBackupDate))
                    MessageBox.Show("Güncelleme vakti gelmemiş.");
                else
                {
                    if ((DateTime.Now - lastBackupDate).Days < 1)
                    {
                        if ((DateTime.Now - lastBackupDate).Hours >= 1)
                            MessageBox.Show("Güncelleme vakti henüz gelmemiş.\nSon yedekleme zamanı: "+ (DateTime.Now - lastBackupDate).Hours + " saat, " + (DateTime.Now - lastBackupDate).Minutes + " dakika önce.");
                        else
                            MessageBox.Show("Güncelleme vakti henüz gelmemiş.\nSon yedekleme zamanı: " + (DateTime.Now - lastBackupDate).Minutes + " dakika önce.");
                    }
                    else
                        MessageBox.Show("Güncelleme vakti henüz gelmemiş.\nSon yedekleme zamanı: " + (DateTime.Now - lastBackupDate).Days + " gün önce.");

                }
                System.Diagnostics.Process.Start(project.programLocation);
            }
        }

        public static Panel createProjectButton(Project project, bool isPlusButton, Form activeForm)
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile parametre olarak aldığımız projeye göre ilgili projeyi açacak bir buton veya yeni bir proje eklemeyi sağlayacak olan bir buton oluşturulmaktadır.
            */

            // Yeni bir panel oluşturuluyor ve gerekli tasarımsal ayarlar yapılıyor.
            Panel projectButton = new Panel();
            projectButton.Cursor = Cursors.Hand;
            projectButton.Size = new Size(240, 80);
            projectButton.Margin = Padding.Empty;
            projectButton.Padding = Padding.Empty;

            PictureBox projectIcon = new PictureBox();
            projectIcon.Size = new Size(80, 80);
            projectIcon.BackgroundImageLayout = ImageLayout.Zoom;
            projectIcon.Location = new Point(0, 0);

            Label projectNameLabel = new Label();
            projectNameLabel.AutoSize = false;
            projectNameLabel.Size = new Size(160, 50);
            projectNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            projectNameLabel.Location = new Point(80, 0);
            projectNameLabel.Font = new Font(projectNameLabel.Font.FontFamily, 10f, FontStyle.Bold);
            projectNameLabel.Cursor = Cursors.Arrow;

            Label lastBackupTimeLabel = new Label();
            lastBackupTimeLabel.AutoSize = false;
            lastBackupTimeLabel.Size = new Size(160, 30);
            lastBackupTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            lastBackupTimeLabel.Location = new Point(80, 50);
            lastBackupTimeLabel.Cursor = Cursors.Arrow;


            if (isPlusButton) // Yeni proje eklemek için kullanılacak olan + butonunu oluşturmak istiyorsak yani parametre olarak gelen isPlusButton true ise burası çalışacaktır. 
            {
                projectIcon.Click += delegate
                {
                    Program.openForm(activeForm.AccessibleName, "addProject", null);// addProject formuna geçiş sağlayacak fonksiyon.
                };
                projectIcon.Size = new Size(240, 80); // Sadece picturebox olacağı için genişliği artırılıp gönderiliyor.
                projectIcon.BackgroundImage = Properties.Resources._new; // Oluşturulan pictureboxa bu ikon atanıyor.
                projectButton.Controls.Add(projectIcon);
                return projectButton; // Oluşturulan buton gönderiliyor.
            }
            else // + butonu değil de bir proje butonu oluşturulacaksa parametre ile gelen projenin ikonu seçiliyor.
            {

                //Çağrılan butona tıklanabilmesi için bir tetikleyici yazılacaktır. Bu sayede projenin yedekleme vakti geldiyse yedeklenip daha sonra ilgili editör açılacaktır.
                projectIcon.Click += delegate
                {
                    if (activeForm.AccessibleName == "home")
                        backupProjects(project, activeForm); // Backup projects fonksiyonunda gönderilen projenin yedekleme vakti geldiyse yedeklemesi yapılıyor ve daha sonra ilgili geliştirme ortamı açılıyor.
                    else
                        Program.openForm(activeForm.AccessibleName, "editProject", project);// addProject formuna geçiş sağlayacak fonksiyon.
                };

                //Butona eklenecek proje adı için gerekli tasarımsal değişiklikler yapılıyor.
                projectNameLabel.Text = project.projectName;

                // Projenin son yedeklenme tarihi alınarak yedekleme vakti geldiyse turuncu, yedeklenmiş ise yeşil, hiç yedeklenmemişse pembe bir arkaplan rengi verilecek.
                if (DateTime.TryParseExact(project.lastBackup, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime backupDate))
                {
                    if ((DateTime.Now - backupDate).Days < 1)
                    {
                        if ((DateTime.Now - backupDate).Hours >= 1)
                            lastBackupTimeLabel.Text = (DateTime.Now - backupDate).Hours + " saat, " + (DateTime.Now - backupDate).Minutes + " dakika önce yedeklendi.";
                        else
                            lastBackupTimeLabel.Text = (DateTime.Now - backupDate).Minutes + " dakika önce yedeklendi.";
                    }
                    else
                        lastBackupTimeLabel.Text = (DateTime.Now - backupDate).Days + " gün önce yedeklendi.";

                    switch (project.backupPeriod)
                    {
                        case "Günlük":
                            {
                                if ((DateTime.Now - backupDate).Days < 1) // İki tarih arasındaki fark 1 günden az ise yedek var demektir.
                                    projectButton.BackColor = Color.LightGreen;
                                else
                                    projectButton.BackColor = Color.FromArgb(125, Color.Orange);
                                break;
                            }
                        case "Haftalık":
                            {
                                if ((DateTime.Now - backupDate).Days < 7) // İki tarih arasındaki fark 7 günden az ise yedek var demektir
                                    projectButton.BackColor = Color.LightGreen;
                                else
                                    projectButton.BackColor = Color.FromArgb(125, Color.Orange);
                                break;
                            }
                        case "Aylık":
                            {
                                if ((DateTime.Now - backupDate).Days < 30) // İki tarih arasındaki fark 30 günden az ise yedek var demektir
                                    projectButton.BackColor = Color.LightGreen;
                                else
                                    projectButton.BackColor = Color.FromArgb(125, Color.Orange);
                                break;
                            }
                        case "Her Açılışta":
                            {
                                projectButton.BackColor = Color.LightPink; // Her açılışta yedek alınacağı için her zaman kırmızı kalacaktır.
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                else
                {
                    lastBackupTimeLabel.Text = "Henüz bir yedek alınmamış.";
                    projectButton.BackColor = Color.LightPink;
                }

                if (File.Exists(project.projectIcon)) // İlgili ikon varlığı kontrol ediliyor ve varsa ikon değişkenine atanıyor.
                    projectIcon.BackgroundImage = Bitmap.FromFile(project.projectIcon);
                else
                    projectIcon.BackgroundImage = Properties.Resources.icon;
            }

            projectButton.Controls.Add(projectIcon);
            projectButton.Controls.Add(projectNameLabel);
            projectButton.Controls.Add(lastBackupTimeLabel);

            return projectButton; // Oluşturulan buton gönderiliyor.
        }

        public static string showLastNChar(string word, int length)
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile parametre olarak aldığımız metnin sondan yine parametre olarak aldığımız sayı kadar karakterini gösteriyoruz.
            */
            if (word.Length > length) // gelen metnin uzunluğu gelen sayıdan büyükse işlem yapılıyor. Yoksa direkt gönderiliyor.
            {
                return word.Substring(word.Length - length, length);
            }
            return word;
        }
        public static string TurkishCharacterToEnglish(string text)
        {
            // Bu fonksiyon ile turkishChars dizisindeki karakterleri englishChars dizisindeki karakterlere dönüştürüyoruz.
            text = text.ToLower();
            char[] turkishChars = { 'ı', 'ğ', 'ç', 'ş', 'ö', 'ü', '|', '?', '!', '@', '.', ' ' };
            char[] englishChars = { 'i', 'g', 'c', 's', 'o', 'u', '-', '-', '-', '-', '-', '-' };

            for (int i = 0; i < turkishChars.Length; i++)
                text = text.Replace(turkishChars[i], englishChars[i]);

            return text;
        }

        string directoryCopy(string projectsFolderPath, string backupFolderPath)
        {
            //Bu fonksiyon ile projectsFolderPath değişkenindeki tüm klasör ve dosyalar, backupFolderPath değişkenindeki klasöre kopyalanıyor.


            DirectoryInfo projectFolder = new DirectoryInfo(projectsFolderPath); // Proje klasörü okunuyor.

            if (!projectFolder.Exists) // Eğer proje klasörü yoksa, klasör olmadığına dair uyarı döndürülüyor.
            {
                return "Proje klasörü bulunamadı.";
            }

            DirectoryInfo[] projectsFolderSubDirs = projectFolder.GetDirectories(); // Proje klasörü içindeki klasörler okunuyor.

            Directory.CreateDirectory(backupFolderPath); // Yedek klasörü yoksa oluşturuluyor.

            FileInfo[] projectsFolderFiles = projectFolder.GetFiles(); // Proje klasörü içerisindeki dosyalar okunuyor.
            foreach (FileInfo file in projectsFolderFiles)
            {
                string tempPath = Path.Combine(backupFolderPath, file.Name); // İlgili dosyanın dizin yolu oluşturuluyor.
                file.CopyTo(tempPath, true); // Proje klasöründeki dosya oluşturulan dizine aynı isimde bir dosya varsa, üzerine yazma yetkisiyle kopyalanıyor.
            }

            // Eğer proje klasöründeki klasörlerin alt klasörleri varsa onlar da okunarak alt klasörlerin kopyalanması da sağlanıyor.
            foreach (DirectoryInfo subdir in projectsFolderSubDirs)
            {
                string tempPath = Path.Combine(backupFolderPath, subdir.Name); // Alt klasörün dizin yolu belirleniyor.
                directoryCopy(subdir.FullName, tempPath); // Belirlenen dizin yolu fonksiyona tekrar gönderiliyor.
            }
            return "Yedekleme tamamlandı."; // Yedekleme işlemi bitince uyarı döndürülüyor ve işlem tamamlanıyor.
        }

    }
}
