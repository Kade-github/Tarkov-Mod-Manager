using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TarkovModManager
{
    public partial class InstanceView : Form
    {
        private Instance _i;

        private bool hasCopied = false;

        private bool serverStarted = false;

        private Process server;
        
        List<string> GetAvailableMods()
        {
            List<string> mods = new List<string>();

            foreach (string d in Directory.GetDirectories(Settings.Instance.ModPath + "/BepInEx/Plugins"))
                mods.Add(Path.GetFileName(d));

            foreach (string f in Directory.GetFiles(Settings.Instance.ModPath + "/BepInEx/Plugins"))
            {
                if (f.Contains(".dll"))
                {
                    // add the name of the file
                    string name = Path.GetFileName(f);
                    mods.Add(name.Substring(0, name.Length - 4));
                }
            }

            foreach (string mod in _i.Mods)
                mods.Remove(mod);

            return mods;
        }

        List<string> GetAvaliableServerMods()
        {
            List<string> mods = new List<string>();

            foreach (string f in Directory.GetDirectories(Settings.Instance.ModPath + "/user/mods"))
                mods.Add(Path.GetFileName(f));

            string[] serverMods = Directory.GetDirectories(Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods");
            
            foreach (string mod in serverMods)
                mods.Remove(Path.GetFileName(mod));
            
            return mods;
        }
        
        List<string> GetSelectedMods()
        {
            return _i.Mods;
        }
        
        List<string> GetSelectedServerMods()
        {
            List<string> mods = new List<string>();

            foreach (string d in Directory.GetDirectories(Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods"))
                mods.Add(Path.GetFileName(d));

            return mods;
        }

        public void PopulateMods()
        {
            instance_mod_list.Items.Clear();
            foreach (string mod in GetSelectedMods())
            {
                instance_mod_list.Items.Add(mod);
            }
            
            mod_list.Items.Clear();
            foreach (string mod in GetAvailableMods())
            {
                mod_list.Items.Add(mod);
            }
            
            mod_search_box.Text = "";
            textBox1.Text = "";
            
            mods_user_mods.Items.Clear();
            foreach (string mod in GetAvaliableServerMods())
            {
                mods_user_mods.Items.Add(mod);
            }
            
            server_user_mods.Items.Clear();
            foreach (string mod in GetSelectedServerMods())
            {
                server_user_mods.Items.Add(mod);
            }
            
            server_um_searchbox.Text = "";
            mods_um_searchbox.Text = "";
            
            _i.Save();
        }

        public void AutoDetectServerMods()
        {
            // Remove all mods
            
            foreach (string d in Directory.GetDirectories(Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods"))
            {
                Directory.Delete(d, true);
            }
            
            // Copy from our mod path

            foreach (string d in Directory.GetDirectories(Settings.Instance.ModPath + "/user/mods"))
            {
                string name = Path.GetFileName(d);
                foreach (string mod in _i.Mods)
                {
                    if (name.ToLower().Contains(mod.ToLower()))
                        CopyFilesRecursively(d, Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods/" + name);
                }
            }
        }
        
        public void CopyFiles(string pluginPath, string userConfigs, string configPath)
        {
            // Remove all mods
            
            foreach (string f in Directory.GetFiles(pluginPath))
                File.Delete(f);
            
            foreach (string d in Directory.GetDirectories(pluginPath))
                Directory.Delete(d, true);
            
            // Copy all mods

            foreach (string f in Directory.GetFiles(Settings.Instance.ModPath + "/BepInEx/Plugins"))
            {
                string name = Path.GetFileName(f);
                if (_i.Mods.Contains(name.Substring(0, name.Length - 4)))
                    File.Copy(f, pluginPath + "/" + name + ".dll");
            }
            
            foreach (string d in Directory.GetDirectories(Settings.Instance.ModPath + "/BepInEx/Plugins"))
            {
                string name = Path.GetFileName(d);
                if (_i.Mods.Contains(name))
                    CopyFilesRecursively(d, pluginPath + "/" + name);
            }

            // Copy server mods to user mods
            
            CopyFilesRecursively(Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods", userConfigs);
            
            // Copy our profiles
            
            CopyFilesRecursively(Settings.Instance.InstancePath + "/" + _i.Name + "/user/profiles", Settings.Instance.SPTPath + "/user/profiles");
            
            // Copy our configs
            
            CopyFilesRecursively(Settings.Instance.InstancePath + "/" + _i.Name +  "/BepInEx/config", configPath);
            
            hasCopied = true;
        }

        public void CopyBack(string pluginPath, string userConfigs, string configPath)
        {
            // Remove mods
            
            foreach (string f in Directory.GetFiles(pluginPath))
                File.Delete(f);
            
            foreach (string d in Directory.GetDirectories(pluginPath))
                Directory.Delete(d, true);
            
            // Remove server mods
            
            foreach (string f in Directory.GetFiles(userConfigs))
                File.Delete(f);
            
            foreach (string d in Directory.GetDirectories(userConfigs))
                Directory.Delete(d, true);
            
            // Copy configs back
            
            CopyFilesRecursively(configPath, Settings.Instance.InstancePath + "/" + _i.Name + "/BepInEx/config");
            
            // Copy profiles back
            
            CopyFilesRecursively(Settings.Instance.SPTPath + "/user/profiles", Settings.Instance.InstancePath + "/" + _i.Name + "/user/profiles");
            
            // Remove configs
            
            foreach (string f in Directory.GetFiles(configPath))
                File.Delete(f);

            // Remove profiles
            
            foreach (string f in Directory.GetFiles(Settings.Instance.SPTPath + "/user/profiles"))
                File.Delete(f);
            
            hasCopied = false;
        }
        
        public InstanceView(Instance i)
        {
            InitializeComponent();
            
            _i = i;
            
            Text = "Tarkov Mod Manager | " + i.Name;

            label1.Text = i.Name;
            
            addr_textbx.Text = i.ServerAddress;
            
            PopulateMods();
            
        }

        public void Clean()
        {
            if (serverStarted && !server.HasExited)
                server.Kill();
            
            string pluginPath = Settings.Instance.SPTPath + "/BepInEx/Plugins";
            
            string userConfigs = Settings.Instance.SPTPath + "/user/mods";
            
            string configPath = Settings.Instance.SPTPath + "/BepInEx/config";
            
            if (hasCopied && Directory.Exists(pluginPath) && Directory.Exists(userConfigs) && Directory.Exists(configPath))
                CopyBack(pluginPath, userConfigs, configPath);
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Clean();
            
            InstanceManager.instance.Show();

            base.OnFormClosing(e);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            _i.Save();
            
            Close();
        }

        private void mod_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mod_list.SelectedIndex == -1)
                return;
            
            _i.Mods.Add(mod_list.SelectedItem.ToString());
            PopulateMods();
        }

        private void instance_mod_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (instance_mod_list.SelectedIndex == -1)
                return;
            
            _i.Mods.Remove(instance_mod_list.SelectedItem.ToString());
            PopulateMods();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                instance_mod_list.Items.Clear();
                foreach (string mod in GetSelectedMods())
                {
                    if (mod.ToLower().Contains(textBox1.Text.ToLower()))
                        instance_mod_list.Items.Add(mod);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void mod_search_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mod_list.Items.Clear();
                foreach (string mod in GetAvailableMods())
                {
                    if (mod.ToLower().Contains(mod_search_box.Text.ToLower()))
                        mod_list.Items.Add(mod);
                }
                e.SuppressKeyPress = true;
            }
        }
        
        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                if (!Directory.Exists(dirPath.Replace(sourcePath, targetPath)))
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Settings.Instance.SPTPath))
            {
                MessageBox.Show("SPT Path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string spt = Settings.Instance.SPTPath + "/Aki.Launcher.exe";
            
            if (!File.Exists(spt))
            {
                MessageBox.Show("SPT not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pluginPath = Settings.Instance.SPTPath + "/BepInEx/Plugins";
            
            if (!Directory.Exists(pluginPath))
            {
                MessageBox.Show("Plugin path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string userConfigs = Settings.Instance.SPTPath + "/user/mods";
            
            if (!Directory.Exists(userConfigs))
            {
                MessageBox.Show("User configs path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Change launcher config to add the new address
            
            string configPath = Settings.Instance.SPTPath + "/user/launcher/config.json";
            
            if (!File.Exists(configPath))
            {
                MessageBox.Show("Launcher config not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string cfgPath = Settings.Instance.SPTPath + "/BepInEx/config";
           
            if (!Directory.Exists(cfgPath))
            {
                MessageBox.Show("BepInEx config path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
            string config = File.ReadAllText(configPath);
            
            // convert to json object
            
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(config);

            if (json != null)
            {
                _i.ServerAddress = addr_textbx.Text;

                json["Server"]["Url"] = _i.ServerAddress;
                
                File.WriteAllText(configPath, Newtonsoft.Json.JsonConvert.SerializeObject(json));
            }
            else
            {
                MessageBox.Show("Couldn't parse the Launcher Config", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            int mods = Directory.GetFiles(pluginPath).Length + Directory.GetDirectories(pluginPath).Length;
            
            if (mods > 0 && !hasCopied)
            {
                hasCopied = false;
                DialogResult dialogResult = MessageBox.Show("Looks like you have some mods already installed, they will be removed. Are you sure you want to do this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                    return;
            }
            
            if (!hasCopied)
                CopyFiles(pluginPath, userConfigs, cfgPath);
            
            // quick save
            
            _i.Save();
            
            // Start SPT
            
            var startInfo = new ProcessStartInfo();
            
            startInfo.FileName = spt;
            startInfo.WorkingDirectory = Settings.Instance.SPTPath;
            
            Process p = Process.Start(startInfo);
            
            Hide();

            
            if (p != null)
            {
                p.WaitForExit();
                if (p.ExitCode != 0)
                    MessageBox.Show("SPT exited with code " + p.ExitCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Failed to start SPT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (hasCopied && !serverStarted)
                CopyBack(pluginPath, userConfigs, cfgPath);

            Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serverStarted && !server.HasExited)
            {
                server.Kill();
                serverStarted = false;
                button2.Text = "Start Server";
                return;
            }
            else if (serverStarted)
            {
                serverStarted = false;
                button2.Text = "Start Server";
                return;
            }
            
            if (!Directory.Exists(Settings.Instance.SPTPath))
            {
                MessageBox.Show("SPT Path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string spt = Settings.Instance.SPTPath + "/Aki.Server.exe";
            
            if (!File.Exists(spt))
            {
                MessageBox.Show("SPT not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pluginPath = Settings.Instance.SPTPath + "/BepInEx/Plugins";
            
            if (!Directory.Exists(pluginPath))
            {
                MessageBox.Show("Plugin path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string userConfigs = Settings.Instance.SPTPath + "/user/mods";
            
            if (!Directory.Exists(userConfigs))
            {
                MessageBox.Show("User configs path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string cfgPath = Settings.Instance.SPTPath + "/BepInEx/config";
            
            if (!Directory.Exists(cfgPath))
            {
                MessageBox.Show("BepInEx config path not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            int mods = Directory.GetFiles(pluginPath).Length + Directory.GetDirectories(pluginPath).Length;
            
            if (mods > 0 && !hasCopied)
            {
                hasCopied = false;
                DialogResult dialogResult = MessageBox.Show("Looks like you have some mods already installed, they will be removed. Are you sure you want to do this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                    return;
            }
            
            if (!hasCopied)
                CopyFiles(pluginPath, userConfigs, cfgPath);
            
            // Start SPT
            
            var startInfo = new ProcessStartInfo();
            
            startInfo.FileName = spt;
            startInfo.WorkingDirectory = Settings.Instance.SPTPath;
            
            server = Process.Start(startInfo);
            
            serverStarted = true;
            
            button2.Text = "Stop Server";
        }

        private void mods_user_mods_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add mod
            
            if (mods_user_mods.SelectedIndex == -1)
                return;
            
            string mod = mods_user_mods.SelectedItem.ToString();
            
            if (!Directory.Exists(Settings.Instance.ModPath + "/user/mods/" + mod))
                return;
            
            CopyFilesRecursively(Settings.Instance.ModPath + "/user/mods/" + mod, Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods/" + mod);
            
            PopulateMods();
            
        }

        private void server_user_mods_SelectedIndexChanged(object sender, EventArgs e)
        {
            // remove mod
            
            if (server_user_mods.SelectedIndex == -1)
                return;
            
            string mod = server_user_mods.SelectedItem.ToString();
            
            if (!Directory.Exists(Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods/" + mod))
                return;
            
            Directory.Delete(Settings.Instance.InstancePath + "/" + _i.Name + "/user/mods/" + mod, true);
            
            PopulateMods();
        }

        private void autoPopulate_Click(object sender, EventArgs e)
        {
            AutoDetectServerMods();
            PopulateMods();
        }

        private void server_um_searchbox_TextChanged(object sender, EventArgs e)
        {
            server_user_mods.Items.Clear();
            
            foreach (string mod in GetSelectedServerMods())
            {
                if (mod.ToLower().Contains(server_um_searchbox.Text.ToLower()))
                    server_user_mods.Items.Add(mod);
            }
        }

        private void mods_um_searchbox_TextChanged(object sender, EventArgs e)
        {
            mods_user_mods.Items.Clear();
            
            foreach (string mod in GetAvaliableServerMods())
            {
                if (mod.ToLower().Contains(mods_um_searchbox.Text.ToLower()))
                    mods_user_mods.Items.Add(mod);
            }
            
        }
    }
}