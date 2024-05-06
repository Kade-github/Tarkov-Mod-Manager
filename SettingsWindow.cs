using System;
using System.IO;
using System.Windows.Forms;

namespace TarkovModManager
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            
            instances_txbox.Text = Settings.Instance.InstancePath;
            spt_install_txbox.Text = Settings.Instance.SPTPath;
            moddir_txbox.Text = Settings.Instance.ModPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // browse for instances path
            
            string path = "";
            
            OpenFileDialog folderBrowser = new OpenFileDialog();
            
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            
            folderBrowser.FileName = "Select Folder";
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                path = Path.GetDirectoryName(folderBrowser.FileName);
            
            instances_txbox.Text = path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // browse for spt install path
            
            string path = "";
            
            OpenFileDialog folderBrowser = new OpenFileDialog();
            
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            
            folderBrowser.FileName = "Select Folder";
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                path = Path.GetDirectoryName(folderBrowser.FileName);

            spt_install_txbox.Text = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save settings and close

            if (Directory.Exists(instances_txbox.Text))
                Settings.Instance.InstancePath = instances_txbox.Text;
            else
                MessageBox.Show("Couldn't find the Instances Path", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            if (Directory.Exists(spt_install_txbox.Text))
                Settings.Instance.SPTPath = spt_install_txbox.Text;
            else
                MessageBox.Show("Couldn't find the SPT Install Path", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            
            if (string.IsNullOrEmpty(moddir_txbox.Text))
                MessageBox.Show("Mod Directory is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Settings.Instance.ModPath = moddir_txbox.Text;

            byte[] data = MessagePack.MessagePackSerializer.Serialize(Settings.Instance);
            
            System.IO.File.WriteAllBytes("settings.msgpack", data);
            
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Mod directory browser
            
            string path = "";
            
            OpenFileDialog folderBrowser = new OpenFileDialog();
            
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            
            folderBrowser.FileName = "Select Folder";
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                path = Path.GetDirectoryName(folderBrowser.FileName);
            
            moddir_txbox.Text = path;
        }
    }
}