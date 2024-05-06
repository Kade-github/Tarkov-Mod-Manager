using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TarkovModManager.Users;

namespace TarkovModManager
{
    public partial class InstanceManager : Form
    {
        public static InstanceManager instance = null;
        public void SelectInstance(Instance i)
        {
            InstanceView iv = new InstanceView(i);
            
            iv.Show();
            Hide();
        }

        public void LoadInstances()
        {
            // Check to see if our mods folder is good
            
            if (!Directory.Exists(Settings.Instance.ModPath))
                Directory.CreateDirectory(Settings.Instance.ModPath);
            
            if (!Directory.Exists(Settings.Instance.ModPath + "/user"))
                Directory.CreateDirectory(Settings.Instance.ModPath + "/user");
            
            if (!Directory.Exists(Settings.Instance.ModPath + "/user/mods"))
                Directory.CreateDirectory(Settings.Instance.ModPath + "/user/mods");
            
            if (!Directory.Exists(Settings.Instance.ModPath + "/BepInEx"))
                Directory.CreateDirectory(Settings.Instance.ModPath + "/BepInEx");
            
            if (!Directory.Exists(Settings.Instance.ModPath + "/BepInEx/plugins"))
                Directory.CreateDirectory(Settings.Instance.ModPath + "/BepInEx/plugins");
        
            SuspendLayout();
            // Load Instances
            
            List<string> toRemove = new List<string>();

            instance_group.Controls.Clear();
            
            Settings.Instance.Instances.Clear();

            foreach (string d in Directory.GetDirectories(Settings.Instance.InstancePath))
            {
                string name = Path.GetFileName(d);
                Settings.Instance.Instances.Add(name);
            }

            foreach (var ins in Settings.Instance.Instances)
            {
                string path = Settings.Instance.InstancePath + "/" + ins + "/instance.msgpack";
                if (!File.Exists(path))
                {
                    toRemove.Add(ins);
                    continue;
                }
                
                byte[] data = File.ReadAllBytes(Settings.Instance.InstancePath + "/" + ins + "/instance.msgpack");
                
                Instance i = MessagePack.MessagePackSerializer.Deserialize<Instance>(data);
                
                if (i.Name != Directory.GetParent(path)?.Name)
                {
                    i.Name = Directory.GetParent(path)?.Name;
                    i.Save();
                }
                
                AddInstance(i);
                
                if (!Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name + "/user")) 
                    Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name + "/user");
                if (!Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name + "/user/profiles"))
                    Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name + "/user/profiles");
                if (!Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name + "/user/mods"))
                    Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name + "/user/mods");
            }
            
            foreach (var ins in toRemove)
            {
                Settings.Instance.Instances.Remove(ins);
            }

            ResumeLayout();
        }
        
        public void RemoveInstance(Instance i)
        {
            if (MessageBox.Show("Are you sure you want to delete this instance?", "Delete Instance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            instance_group.Controls.Clear();
            
            Settings.Instance.Instances.Remove(i.Name);
            
            if (Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name))
                Directory.Delete(Settings.Instance.InstancePath + "/" + i.Name, true);
            
            LoadInstances();
        }
        
        public InstanceManager()
        {
            InitializeComponent();

            version_text.Text = "v" + Program.Version;
            
            instance = this;
            
            instance_group.SendToBack();

            instance_group.VerticalScroll.Visible = true;
            // load settings
            if (Settings.Instance == null)
            {
                if (File.Exists("settings.msgpack"))
                {
                    byte[] data = System.IO.File.ReadAllBytes("settings.msgpack");

                    Settings.Instance = MessagePack.MessagePackSerializer.Deserialize<Settings>(data);
                }
                else
                {
                    Settings.Instance = new Settings();

                    if (!Directory.Exists("Instances"))
                        Directory.CreateDirectory("Instances");
                    
                    if (!Directory.Exists("Mods"))
                        Directory.CreateDirectory("Mods");
                    
                    Settings.Instance.InstancePath = "Instances";
                    Settings.Instance.ModPath = "Mods";
                    
                    Settings.Instance.Instances = new List<string>();

                    // save 
                    
                    byte[] data = MessagePack.MessagePackSerializer.Serialize(Settings.Instance);
                    
                    File.WriteAllBytes("settings.msgpack", data);
                }
            }
            
            LoadInstances();
            
        }
        
        public void CreateInstance(string name)
        {
            if (Settings.Instance.Instances.Contains(name))
            {
                MessageBox.Show("Instance already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
   
            Instance i = new Instance();
            i.Mods = new List<string>();
            i.Name = name;
            i.ServerAddress = "http://127.0.0.1:6969";
            Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name);

            i.Save();
            
            Settings.Instance.Instances.Add(i.Name);
            
            AddInstance(i);

            byte[] data = MessagePack.MessagePackSerializer.Serialize(Settings.Instance);
            
            File.WriteAllBytes("settings.msgpack", data);
        }

        public void AddInstance(Instance i)
        {
            if (!Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name + "/BepInEx"))
                Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name + "/BepInEx");
            if (!Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name + "/BepInEx/config"))
                Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name + "/BepInEx/config");
            
            if (!Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name + "/user"))
                Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name + "/user");
            if (!Directory.Exists(Settings.Instance.InstancePath + "/" + i.Name + "/user/mods"))
                Directory.CreateDirectory(Settings.Instance.InstancePath + "/" + i.Name + "/user/mods");
            
            InstanceControl ic = new InstanceControl(i);
            instance_group.Controls.Add(ic);
            

            // dock to left and right

            ic.Dock = DockStyle.Fill;
            
            ic.OnSelect += SelectInstance;
            ic.OnRemove += RemoveInstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateInstance("Instance" + Settings.Instance.Instances.Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var popup = new SettingsWindow();
            popup.ShowDialog();
            
            LoadInstances();
        }
        
    }
}