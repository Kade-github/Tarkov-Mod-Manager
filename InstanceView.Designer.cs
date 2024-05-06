using System.ComponentModel;

namespace TarkovModManager
{
    partial class InstanceView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.mod_list = new System.Windows.Forms.ListBox();
            this.mod_search_box = new System.Windows.Forms.TextBox();
            this.instance_mod_list = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addr_textbx = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.autoPopulate = new System.Windows.Forms.Button();
            this.mods_um_searchbox = new System.Windows.Forms.TextBox();
            this.mods_user_mods = new System.Windows.Forms.ListBox();
            this.server_user_mods = new System.Windows.Forms.ListBox();
            this.server_um_searchbox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 76);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 326);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MinimumSize = new System.Drawing.Size(298, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(788, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instance Name";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.button1.Location = new System.Drawing.Point(12, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Select a new Instance";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mod_list
            // 
            this.mod_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.mod_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.mod_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mod_list.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.mod_list.FormattingEnabled = true;
            this.mod_list.ItemHeight = 24;
            this.mod_list.Location = new System.Drawing.Point(393, 37);
            this.mod_list.Name = "mod_list";
            this.mod_list.Size = new System.Drawing.Size(375, 240);
            this.mod_list.TabIndex = 4;
            this.mod_list.SelectedIndexChanged += new System.EventHandler(this.mod_list_SelectedIndexChanged);
            // 
            // mod_search_box
            // 
            this.mod_search_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mod_search_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.mod_search_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mod_search_box.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod_search_box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.mod_search_box.Location = new System.Drawing.Point(393, 6);
            this.mod_search_box.Name = "mod_search_box";
            this.mod_search_box.Size = new System.Drawing.Size(375, 25);
            this.mod_search_box.TabIndex = 5;
            this.mod_search_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mod_search_box_KeyDown);
            // 
            // instance_mod_list
            // 
            this.instance_mod_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.instance_mod_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.instance_mod_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instance_mod_list.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instance_mod_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.instance_mod_list.FormattingEnabled = true;
            this.instance_mod_list.ItemHeight = 24;
            this.instance_mod_list.Location = new System.Drawing.Point(6, 37);
            this.instance_mod_list.Name = "instance_mod_list";
            this.instance_mod_list.Size = new System.Drawing.Size(351, 240);
            this.instance_mod_list.TabIndex = 6;
            this.instance_mod_list.SelectedIndexChanged += new System.EventHandler(this.instance_mod_list_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 25);
            this.textBox1.TabIndex = 7;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.label2.Location = new System.Drawing.Point(382, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "< >";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.button4.Location = new System.Drawing.Point(664, 410);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 28);
            this.button4.TabIndex = 11;
            this.button4.Text = "Start Client";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.button2.Location = new System.Drawing.Point(534, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 28);
            this.button2.TabIndex = 12;
            this.button2.Text = "Start Server";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addr_textbx
            // 
            this.addr_textbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addr_textbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.addr_textbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addr_textbx.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addr_textbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(80)))), ((int)(((byte)(91)))));
            this.addr_textbx.Location = new System.Drawing.Point(280, 413);
            this.addr_textbx.Name = "addr_textbx";
            this.addr_textbx.Size = new System.Drawing.Size(248, 25);
            this.addr_textbx.TabIndex = 13;
            this.addr_textbx.Text = "http://127.0.0.1:6969";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 323);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(18)))), ((int)(((byte)(14)))));
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.instance_mod_list);
            this.tabPage1.Controls.Add(this.mod_search_box);
            this.tabPage1.Controls.Add(this.mod_list);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Client";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(18)))), ((int)(((byte)(14)))));
            this.tabPage2.Controls.Add(this.autoPopulate);
            this.tabPage2.Controls.Add(this.mods_um_searchbox);
            this.tabPage2.Controls.Add(this.mods_user_mods);
            this.tabPage2.Controls.Add(this.server_user_mods);
            this.tabPage2.Controls.Add(this.server_um_searchbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Server";
            // 
            // autoPopulate
            // 
            this.autoPopulate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.autoPopulate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.autoPopulate.FlatAppearance.BorderSize = 0;
            this.autoPopulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoPopulate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.autoPopulate.Location = new System.Drawing.Point(6, 259);
            this.autoPopulate.Name = "autoPopulate";
            this.autoPopulate.Size = new System.Drawing.Size(351, 28);
            this.autoPopulate.TabIndex = 15;
            this.autoPopulate.Text = "Auto populate from client";
            this.autoPopulate.UseVisualStyleBackColor = false;
            this.autoPopulate.Click += new System.EventHandler(this.autoPopulate_Click);
            // 
            // mods_um_searchbox
            // 
            this.mods_um_searchbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mods_um_searchbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.mods_um_searchbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mods_um_searchbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mods_um_searchbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.mods_um_searchbox.Location = new System.Drawing.Point(393, 6);
            this.mods_um_searchbox.Name = "mods_um_searchbox";
            this.mods_um_searchbox.Size = new System.Drawing.Size(375, 25);
            this.mods_um_searchbox.TabIndex = 11;
            // 
            // mods_user_mods
            // 
            this.mods_user_mods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.mods_user_mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.mods_user_mods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mods_user_mods.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mods_user_mods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.mods_user_mods.FormattingEnabled = true;
            this.mods_user_mods.ItemHeight = 24;
            this.mods_user_mods.Location = new System.Drawing.Point(393, 37);
            this.mods_user_mods.Name = "mods_user_mods";
            this.mods_user_mods.Size = new System.Drawing.Size(375, 240);
            this.mods_user_mods.TabIndex = 10;
            this.mods_user_mods.SelectedIndexChanged += new System.EventHandler(this.mods_user_mods_SelectedIndexChanged);
            // 
            // server_user_mods
            // 
            this.server_user_mods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.server_user_mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.server_user_mods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.server_user_mods.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_user_mods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.server_user_mods.FormattingEnabled = true;
            this.server_user_mods.ItemHeight = 24;
            this.server_user_mods.Location = new System.Drawing.Point(6, 37);
            this.server_user_mods.Name = "server_user_mods";
            this.server_user_mods.Size = new System.Drawing.Size(351, 216);
            this.server_user_mods.TabIndex = 9;
            this.server_user_mods.SelectedIndexChanged += new System.EventHandler(this.server_user_mods_SelectedIndexChanged);
            // 
            // server_um_searchbox
            // 
            this.server_um_searchbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.server_um_searchbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(26)))));
            this.server_um_searchbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.server_um_searchbox.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_um_searchbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(176)))), ((int)(((byte)(171)))));
            this.server_um_searchbox.Location = new System.Drawing.Point(6, 6);
            this.server_um_searchbox.Name = "server_um_searchbox";
            this.server_um_searchbox.Size = new System.Drawing.Size(351, 25);
            this.server_um_searchbox.TabIndex = 8;
            // 
            // InstanceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(18)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.addr_textbx);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "InstanceView";
            this.Text = "Tarkov Mod Manager | <Name>";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button autoPopulate;

        private System.Windows.Forms.TextBox server_um_searchbox;
        private System.Windows.Forms.ListBox server_user_mods;
        private System.Windows.Forms.TextBox mods_um_searchbox;
        private System.Windows.Forms.ListBox mods_user_mods;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        private System.Windows.Forms.TextBox addr_textbx;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox mod_search_box;

        private System.Windows.Forms.ListBox mod_list;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.ListBox instance_mod_list;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}