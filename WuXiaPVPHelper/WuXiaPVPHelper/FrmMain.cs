using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WuXiaPVPHelper.Careers.丐帮;
using WuXiaPVPHelper.Careers.五毒;
using WuXiaPVPHelper.Careers.唐门;
using WuXiaPVPHelper.Careers.天香;
using WuXiaPVPHelper.Careers.太白;
using WuXiaPVPHelper.Careers.真武;
using WuXiaPVPHelper.Careers.神刀;
using WuXiaPVPHelper.Careers.神威;

namespace WuXiaPVPHelper
{
    public partial class FrmMain : Form
    {
        private List<Career> _careers;
        private ImageList _imageList;

        private string _selectedCareerName = String.Empty;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            #region 初始化职业技能

            if (File.Exists("config.bin"))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream destream = new FileStream("config.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        _careers = (List<Career>)bf.Deserialize(destream);
                        goto InitCompleted;
                    }
                }
                catch (Exception)
                {
                }
            }


            _careers = new List<Career>
                {
                    new Career
                    {
                        Name = "天香",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 柳暗凌波()},
                            {1, new 伞舞盾()},
                            {2, new 玉帘拂衣()},
                            {3, new 琴心三叠()}
                        }
                    },
                    new Career
                    {
                        Name = "神威",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 背水一击()},
                            {1, new 无敌无我()},
                            {2, new 云龙五现()},
                            {3, new 猛虎破()}
                        }
                    },
                    new Career
                    {
                        Name = "太白",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 天峰五云剑()},
                            {1, new 无痕剑意()},
                            {2, new 烟霞满天()},
                            {3, new 燕回朝阳()}
                        }
                    },
                    new Career
                    {
                        Name = "丐帮",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 醉饮江河()},
                            {1, new 龙吟三破()},
                            {2, new 倒提壶()},
                            {3, new 离弦腿()},
                            {4, new 离弦腿解控()}
                        }
                    },
                    new Career
                    {
                        Name = "五毒",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 百鬼夜行()},
                            {1, new 寄生诀()},
                            {2, new 蝙蝠掠夜()},
                            {3, new 凤凰绝杀()},
                            {4, new 索命诀()}
                        }
                    },
                    new Career
                    {
                        Name = "真武",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 离渊()},
                            {1, new 动愈守中()},
                            {2, new 微明生灭()},
                            {3, new 冲盈()}
                        }
                    },
                    new Career
                    {
                        Name = "唐门",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 困百骸()},
                            {1, new 自替身()},
                            {2, new 形神合()},
                            {3, new 千机扫()}
                        }
                    },
                    new Career
                    {
                        Name = "神刀",
                        Skills = new SortedList<int, Skill>
                        {
                            {0, new 回锋斩()},
                            {1, new 饮沧海()},
                            {2, new 啄星辰()},
                            {3, new 斩血海()}
                        }
                    },
                };


            #endregion

            InitCompleted:

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

            string[] skillNames = _careers.FirstOrDefault(c => c.Name == cmbCareers.SelectedItem.ToString())?.Skills.Values.Select(s => s.Name).ToArray();

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

            SortedList<int, Skill> skills = _careers.FirstOrDefault(c => c.Name == cmbCareers.SelectedItem.ToString())?.Skills;

            KeyValuePair<int, Skill> sa = skills.FirstOrDefault(s => s.Value.Name == aName);
            KeyValuePair<int, Skill> sb = skills.FirstOrDefault(s => s.Value.Name == bName);

            skills.Remove(sa.Key);
            skills.Remove(sb.Key);

            skills.Add(sb.Key, sa.Value);
            skills.Add(sa.Key, sb.Value);
        }

        private void GetSkillNameAndKey(string skillFullName, out string name, out string key)
        {
            string[] result = skillFullName.Split('\n');
            name = result[0];
            key = result[1];
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_selectedCareerName == string.Empty)
            {
                MessageBox.Show(@"请先选择对战职业！", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //保存技能顺序
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("config.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                bf.Serialize(fs, _careers);
            }

            MessageBox.Show($"即将关闭配置窗口，按F12呼出！\n拖动第一个图标可以调整窗口位置", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
