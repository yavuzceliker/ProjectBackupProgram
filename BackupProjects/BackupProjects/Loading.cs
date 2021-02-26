using System.Windows.Forms;

namespace BackupProjects
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://yavuzceliker.com.tr");
        }
    }
}
