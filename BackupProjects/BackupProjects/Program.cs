using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BackupProjects
{
    static class Program
    {
        public static List<Form> formList = new List<Form>(); // Program ilk çalıştırıldığı anda bu liste içerisine tüm formlar eklenecektir.


        public static void openForm(string currentformName, string newformName, Project project)
        {
            /*
                 * Tarih:22.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile form geçişleri sırasında mevcut formu gizleyip, geri açarken ise her defasında new form diyerek belleği doldurmanın önüne geçiliyor.
                 * Program ilk oluşturulurken mevcut formlar tanımlanıyor ve bu formlar üzerinden sayfalar arası geçiş yapılıyor.
            */

            Form form = formList.FirstOrDefault(x => x.AccessibleName == newformName); // Form geçiş isteği geldiği takdirde açılacak olan form bilgisi buraya çekilecektir.

            if (form == null) // Eğer ki eşleşen bir form bulunamadıysa fonksiyon terkediliyor.
                return;

            if (form.IsDisposed) // Form kullanılabilir durumda değilse listenin ilgili indisindeki formu kapatıp yeni bir form tanımlaması yapılacaktır.
            {
                Form oldForm = form; // Kullanılamaz durumdaki formu geçici bir değişkene atıyoruz.

                switch (newformName) // Formlar tanımlanırken AccessibleName özelliği içerisine her formun ismi belirtildi. Bu isimler kullanılarak mevcut form bulunuyor.
                {
                    /*
                    
                    case ler içerisinde ilgili indise uygun olan yeni bir form tanımlanıyor ve o indise atanıyor.

                     */
                    case "home":
                        {
                            formList[0] = new Home();
                            form = formList[0];
                            break;
                        }
                    case "settings":
                        {
                            formList[1] = new Settings();
                            form = formList[1];
                            break;
                        }
                    case "addProject":
                        {
                            formList[2] = new AddProject();
                            form = formList[2];
                            break;
                        }
                    case "editProject":
                        {
                            formList[3] = new EditProject(project); // EditProject formu parametre alarak çalıştığı için, formdan gönderilen proje bilgisi atanıyor.
                            form = formList[3];
                            break;
                        }
                    case "info":
                        {
                            formList[4] = new Info();
                            form = formList[4];
                            break;
                        }
                    default:
                        break;
                }

                oldForm.Close(); // Kullanılamaz durumdaki form kapatılıyor.
            }
            else
            {
                if (newformName == "editProject")
                {
                    ((EditProject)formList[3]).project = project; // EditProject formu parametre alarak çalıştığı için, formdan gönderilen proje bilgisi atanıyor.
                }
            }
            form.Show(); // Tanımlanan form açılıyor.

            closeForm(currentformName, project); // Mevcut formun kapatılması için kullanılacak olan fonksiyon çağrılıyor.
        }

        static void closeForm(string formName, Project program)
        {
            /*
                 * Tarih:22.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon openForm fonksiyonunun devamı niteliğindedir.
            */

            Form form = formList.FirstOrDefault(x => x.AccessibleName == formName); // Kapatılacak form, tanımlama aşamasında AccessibleName özelliğine atanan isim üzerinden form listesinden çağrılıyor.

            if (form == null) // Eğer ki eşleşen bir form bulunamadıysa fonksiyon terkediliyor.
                return;

            if (form.IsDisposed) // Form kullanılabilir durumda değilse listenin ilgili indisindeki formu kapatıp yeni bir form tanımlaması yapılacaktır.
            {
                Form oldForm = form; // Kullanılamaz durumdaki formu geçici bir değişkene atıyoruz.

                switch (formName) // Formlar tanımlanırken AccessibleName özelliği içerisine her formun ismi belirtildi. Bu isimler kullanılarak mevcut form bulunuyor.
                {
                    /*
                    case ler içerisinde ilgili indise uygun olan yeni bir form tanımlanıyor ve o indise atanıyor.
                     */

                    case "home":
                        {
                            formList[0] = new Home();
                            form = formList[0];
                            break;
                        }
                    case "settings":
                        {
                            formList[1] = new Settings();
                            form = formList[1];
                            break;
                        }
                    case "addProject":
                        {
                            formList[2] = new AddProject();
                            form = formList[2];
                            break;
                        }
                    case "editProject":
                        {
                            formList[3] = new EditProject(program);
                            form = formList[3];
                            break;
                        }
                    case "info":
                        {
                            formList[4] = new Info();
                            form = formList[4];
                            break;
                        }
                    default:
                        break;
                }

                oldForm.Close(); // Kullanılamaz durumdaki form kapatılıyor.
            }
            form.Hide(); // Form gizleniyor.
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Sistemde geçişlerin yapılacağı formlar formList değişkenine atanıyor. Bu sayede formlar arası geçişler kontrol altına alınacaktır. Daha detaylı bilgi openForm fonksiyonu içerisinde mevcuttur.
            formList.Add(new Home());
            formList.Add(new Settings());
            formList.Add(new AddProject());
            formList.Add(new EditProject(null));
            formList.Add(new Info());


            //Programın çalışmasında önemli olan data.xml dosyası mevcut değilse oluşturulup, kapsayıcı eleman ataması yapılıyor.
            string xmlDocPath = "data.xml";
            if (!File.Exists(xmlDocPath))
            {
                XmlWriter xmlWriter = XmlWriter.Create(xmlDocPath);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Projects");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }

            Application.Run(formList[0]);
        }
    }
}
