using System;
using System.IO;
using System.Windows.Forms;

namespace TarkovModManager.Users
{
    public delegate void Selected(Instance i);
    public delegate void Remove(Instance i);
    public partial class InstanceControl : UserControl
    {
        public event Selected OnSelect;
        public event Remove OnRemove;
        private Instance i;
        
        public InstanceControl(Instance _i)
        {
            i = _i;
            InitializeComponent();
            
            textBox1.Text = i.Name;
            
            mod_count.Text = "Mods: " + i.Mods.Count;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(" ") || textBox1.Text.Contains("/"))
                textBox1.Text = textBox1.Text.Replace(" ", "").Replace("/", "").Replace("\\", "");

            if (textBox1.Text == "" || textBox1.Text.Length == 0)
                return;
            
            string target = Settings.Instance.InstancePath + "/" + i.Name;
            string dest = Settings.Instance.InstancePath + "/" + textBox1.Text;
            if (!Directory.Exists(Settings.Instance.InstancePath + "/" + textBox1.Text) && target != dest)
            {
                Directory.Move(target,
                    dest);
            }
            
            i.Name = textBox1.Text;
            
            i.Save();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnSelect != null) 
                OnSelect(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OnRemove != null) 
                OnRemove(i);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // if enter key is pressed
            
            if (e.KeyCode == Keys.Enter)
            {
                Parent.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}