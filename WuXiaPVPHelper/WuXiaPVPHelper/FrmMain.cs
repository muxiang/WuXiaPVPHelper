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
                        new 云龙五现()
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
                _imageList.Images.Add(i.Substring(i.IndexOf("Icons\\") + "Icons\\".Length, i.Length - ".png".Length - "Icons\\".Length), Image.FromFile(i));

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
    }
}
