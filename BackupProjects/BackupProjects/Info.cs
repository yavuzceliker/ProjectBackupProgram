using System.Windows.Forms;

namespace BackupProjects
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void emailLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            System.Diagnostics.Process.Start("mailto:yavuz@yavuzceliker.com.tr");
        }

        private void webSiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://yavuz@yavuzceliker.com.tr");
        }


        private void Info_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.openForm( "info", "home", null);
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("https://yavuz@yavuzceliker.com.tr");
        }
    }
}
