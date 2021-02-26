using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BackupProjects
{
    public class Project
    {

        public Project()
        {

        }

        public Project(XElement item)
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu constructor ile xml dosyasından okunan veriler Project formatına dönüştürülmektedir.
            */

            int.TryParse(item.Element("projectID").Value, out int outprojectID); // Her projenin bir tanımlayıcı numarası vardır. Bu tanımlayıcı numara alınıyor.
            projectID = outprojectID; // Alınan numara değişkene atanıyor.

            //Diğer veriler de okunup ekleniyor.
            projectName = item.Element("projectName").Value;
            programLocation = item.Element("programLocation").Value;
            projectIcon = item.Element("projectIcon").Value;
            projectFolder = item.Element("projectFolder").Value;
            backupPeriod = item.Element("backupPeriod").Value;
            backupFolder = item.Element("backupFolder").Value;
            lastBackup = item.Element("lastBackup").Value;
        }

        public static List<Project> getAllProjects()
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile proje bilgilerini tuttuğumuz xml dosyasındaki tüm projeler okunup Project sınıfına dönüştürülüp liste halinde döndürülmektedir.
            */


            string xmlDocPath = "data.xml"; // Proje dosyalarının tutulacağı xml dosyasının konumu belirtiliyor.
            XDocument xmlDoc = XDocument.Load(xmlDocPath); // İlgili konumdaki  xml dosyası okunuyor.

            List<Project> projectList = new List<Project>(); // Gönderilecek projeleri tutacak liste tanımlanıyor.

            foreach (XElement item in xmlDoc.Root.Elements())//xml dosyasındaki elemanlar okunuyor.
            {
                projectList.Add(new Project(item)); // okunan Xelement tipindeki dosyalar daha önce hazırlanan constructor üzerinde Project sınıfına dönüştürülüp listeye ekleniyor.
            }
            return projectList; // Oluşturulan liste gönderiliyor.
        }

        public static int nextProjectID()
        {
            /*
                 * Tarih:23.02.2020
                 * Yazan: Yavuz ÇELİKER
                 * Email: yavuz@yavuzceliker.com.tr
                 * Kod Türü: C#
                 * Tanım: Bu fonksiyon ile eklenen son projenin ID numarası alınıp 1 artırılarak yeni eklenecek projeye eklemek üzere döndürülüyor..
            */

            List<Project> allProjects = Project.getAllProjects(); // Tüm projeler alınarak bir listeye atanıyor.
            if (allProjects.Count == 0) // Eğer eklenmiş bir proje yoksa varsayılan olarak 0 döndürülüyor.
                return 0;

            Project project = allProjects.OrderByDescending(x => Convert.ToInt32(x.projectID)).First(); // Projeler ID'ye göre sıralanarak en son proje alınıyor.
            if (project != null) // Eğer proje varsa proje ID'si 1 artırılarak gönderiliyor.
                return project.projectID + 1;
            else // Eğer proje yoksa 0 döndürülüyor.
                return 0;
        }


        public XElement toXml()
        {
            XElement item = new XElement("Project",
            new XElement("projectID", projectID),
            new XElement("projectName", projectName),
            new XElement("programLocation", programLocation),
            new XElement("projectIcon", projectIcon),
            new XElement("projectFolder", projectFolder),
            new XElement("backupPeriod", backupPeriod),
            new XElement("backupFolder", backupFolder),
            new XElement("lastBackup", lastBackup??""));
            return item;
        }

        public int projectID { get; set; }
        public string backupFolder { get; set; }
        public string projectName { get; set; }
        public string programLocation { get; set; }
        public string projectIcon { get; set; }
        public string projectFolder { get; set; }
        public string backupPeriod { get; set; }
        public string lastBackup { get; set; }
    }
}
