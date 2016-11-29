using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using AlphaWindowBase.Window.WindowBase;

namespace WuXiaPVPHelper
{
    public partial class FrmPlaying : AlphaWindow
    {
        private bool _mouseDown;
        private int _xPadding;
        private int _yPadding;
        private readonly FrmMain _frmMain;
        private readonly Skill[] _skills;
        private Font _font = new Font("宋体", 60, FontStyle.Bold, GraphicsUnit.Pixel);

        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);

        public FrmPlaying(Skill[] skills, FrmMain frmMain)
        {
            InitializeComponent();
            Penetrable = true;
            _frmMain = frmMain;
            _skills = skills;

            for (int i = 0; i < _skills.Length; i++)
            {
                if (i == 0)
                {
                    pic1.Image = _frmMain.ImageList1.Images[_skills[0].Name];
                    pic1.Tag = _skills[0];
                    continue;
                }

                PictureBox p = new PictureBox
                {
                    Location = new System.Drawing.Point(pic1.Left + (20 + pic1.Width) * i, pic1.Top),
                    Name = $"pic{i + 1}",
                    Size = pic1.Size,
                    SizeMode = pic1.SizeMode,
                    TabIndex = pic1.TabIndex,
                    TabStop = pic1.TabStop,
                    Image = _frmMain.ImageList1.Images[_skills[i].Name],
                    Tag = _skills[i]
                };

                this.Controls.Add(p);
            }

            tmrGetKeyState.Tick += (s1, e1) =>
            {
                for (int i = 0; i < _skills.Length; i++)
                {
                    short s = GetKeyState(VirtualKeyStates.VK_F1 + i);
                    if (s < 0)
                    {
                        if (_skills[i].IsEnable)
                            _skills[i].Cast();
                    }
                }
            };

            tmrGetKeyState.Start();

            tmrDraw.Tick += (s1, e1) =>
            {
                for (int i = 0; i < _skills.Length; i++)
                {
                    var i1 = i;
                    var pic = Controls.OfType<PictureBox>().FirstOrDefault(p => ((Skill)p.Tag).Name == _skills[i1].Name);

                    if (_skills[i].IsEnable)
                    {
                        pic?.Refresh();
                        continue;
                    }

                    int cdRemains = _skills[i].CooldownRemains;
                    double cdPercent = _skills[i].CooldownPercent;

                    using (Graphics g = pic.CreateGraphics())
                    {
                        pic.Refresh();

                        SizeF sz = g.MeasureString(cdRemains.ToString(), _font);
                        PointF drawPt = new PointF(Math.Abs(pic.Width / 2f - sz.Width / 2), Math.Abs(pic.Height / 2f - sz.Height / 2));
                        g.FillPie(new SolidBrush(Color.FromArgb(127, Color.Black)), new Rectangle(-pic.Width / 2, -pic.Height / 2, pic.Width * 2, pic.Height * 2), -90 + 360 * (float)(1-cdPercent), 360 * (float)cdPercent);
                        g.DrawString(cdRemains.ToString(), _font, Brushes.Gold, drawPt);
                    }
                }
            };

            tmrDraw.Start();
        }

        private void pic1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _xPadding = e.X + pic1.Location.X;
            _yPadding = e.Y + pic1.Location.Y;
        }

        private void pic1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void pic1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseDown) return;

            Point sPoint = PointToScreen(new Point(e.X + pic1.Location.X, e.Y + pic1.Location.Y));

            Location = new Point(sPoint.X - _xPadding, sPoint.Y - _yPadding);
        }

        private void FrmPlaying_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmMain.Show();
        }
    }
}
