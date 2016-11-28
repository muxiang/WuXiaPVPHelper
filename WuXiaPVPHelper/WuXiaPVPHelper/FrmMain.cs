using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WuXiaPVPHelper.Careers.天香;
using WuXiaPVPHelper.Careers.太白;
using WuXiaPVPHelper.Careers.神威;

namespace WuXiaPVPHelper
{
    public partial class FrmMain : Form
    {
        private List<Career> _careers;
        private ImageList _imageList;

        public FrmMain()
        {
            InitializeComponent();
        }

        public ImageList ImageList1
        {
            get { return _imageList; }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _careers = new List<Career>
            {
                new Career
                {
                    Name ="天香",
                    Skills = new List<Skill>
                    {
                        new 柳暗凌波(),
                        new 伞舞盾(),
                        new 玉帘拂衣(),
                        new 琴心三叠()
                    }
                },
                new Career
                {
                    Name ="神威",
                    Skills = new List<Skill>
                    {
                        new 背水一击(),
                        new 无敌无我(),
                        new 云龙五现(),
                        new 猛虎破()
                    }
                },
                new Career
                {
                    Name ="太白",
                    Skills = new List<Skill>
                    {
                        new 天峰五云剑(),
                        new 无痕剑意(),
                        new 烟霞满天(),
                        new 燕回朝阳()
                    }
                },
            };

            cmbCareers.Items.AddRange(_careers.Select(c => c.Name).ToArray());
            listView1.View = View.LargeIcon;
            _imageList = new ImageList();
            _imageList.ImageSize = new Size(40, 40);

            string[] iconNames = Directory.GetFiles("Icons");
            foreach (string i in iconNames)
                _imageList.Images.Add(i.Substring(i.IndexOf("Icons\\", StringComparison.Ordinal) + "Icons\\".Length, i.Length - ".png".Length - "Icons\\".Length), Image.FromFile(i));

            listView1.LargeImageList = _imageList;
        }

        private void cmbCareers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string[] skillNames = _careers.FirstOrDefault(c => c.Name == cmbCareers.SelectedItem.ToString())?.Skills.Select(s => s.Name).ToArray();

            Debug.Assert(skillNames != null, "skillNames != null");
            for (int i = 0; i < skillNames.Length; i++)
            {
                string sn = skillNames[i];
                listView1.Items.Add($"{sn}\nF{i + 1}", sn);
            }

            listView1.Show();
        }

        private void listView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (e.KeyValue < 112 || e.KeyValue >= 112 + listView1.Items.Count) return;

            ListViewItem itemTarget = listView1.Items.OfType<ListViewItem>().FirstOrDefault(i => i.Text.Contains(e.KeyCode.ToString()));
            if (itemTarget == null) return;
            ListViewItem itemSelect = listView1.SelectedItems[0];

            SwapItems(itemTarget, itemSelect);

            itemTarget.Selected = true;
        }

        private void SwapItems(ListViewItem a, ListViewItem b)
        {
            ListViewItem temp = new ListViewItem();
            temp.Text = a.Text;
            temp.ImageKey = a.ImageKey;
            a.Text = b.Text;
            a.ImageKey = b.ImageKey;
            b.Text = temp.Text;
            b.ImageKey = temp.ImageKey;

            string aName, aKey, bName, bKey;
            GetSkillNameAndKey(a.Text, out aName, out aKey);
            GetSkillNameAndKey(b.Text, out bName, out bKey);

            a.Text = aName + '\n' + bKey;
            b.Text = bName + '\n' + aKey;
        }

        private void GetSkillNameAndKey(string skillFullName, out string name, out string key)
        {
            string[] result = skillFullName.Split('\n');
            name = result[0];
            key = result[1];
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbCareers.SelectedIndex < 0)
            {
                MessageBox.Show(@"请先选择对战职业!", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(@"即将关闭配置窗口，按F12呼出!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            string[] skillNames =
            listView1.Items.OfType<ListViewItem>().Select(i =>
            {
                string name, key;
                GetSkillNameAndKey(i.Text, out name, out key);
                return name;
            }).ToArray();

            Skill[] skills = new Skill[skillNames.Length];
            for (int i = 0; i < skills.Length; i++)
                skills[i] = Skill.CreateByName(skillNames[i]);

            FrmPlaying frmPlaying = new FrmPlaying(skills, this);
            frmPlaying.Show();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
