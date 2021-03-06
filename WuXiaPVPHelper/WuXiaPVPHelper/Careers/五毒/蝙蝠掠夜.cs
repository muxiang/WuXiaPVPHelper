﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WuXiaPVPHelper.Careers.五毒
{
    [Serializable]
    public class 蝙蝠掠夜 : Skill
    {
        //一段冷却计时秒表
        [NonSerialized]
        private Stopwatch _sw2;

        /// <summary>
        /// 一段冷却时间
        /// </summary>
        public int FirstStageCooldown { get; set; }

        /// <summary>
        /// 是否为一段计时
        /// </summary>
        public bool IsFirstStage
        {
            get
            {
                if (Sw != null) return false;
                return _sw2 != null;
            }
        }

        /// <summary>
        /// 根据属性IsFirstStage判断是否为一段计时
        /// </summary>
        public override int CooldownRemains
        {
            get
            {
                if (Sw == null)
                {
                    if (_sw2 == null)
                        return 0;

                    if ((int)_sw2.ElapsedMilliseconds / 1000 < FirstStageCooldown)
                        return FirstStageCooldown - (int)_sw2.ElapsedMilliseconds / 1000;

                    //自然结束一段计时,未释放二段
                    _sw2.Stop();
                    _sw2 = null;

                    base.Cast();
                }

                Debug.Assert(Sw != null, "Sw != null");
                int remain = Cooldown - (int)Sw.ElapsedMilliseconds / 1000;

                if (remain <= 0)
                {
                    Cooldown += FirstStageCooldown;
                    Reset();
                }
                return remain;
            }
        }

        public override double CooldownPercent
        {
            get { return (double)CooldownRemains / (IsFirstStage ? FirstStageCooldown : Cooldown); }
        }

        public override bool IsEnable
        {
            get
            {
                return IsFirstStage || base.IsEnable;
            }
        }

        public 蝙蝠掠夜()
        {
            Name = "蝙蝠掠夜";
            Cooldown = 23;
            FirstStageCooldown = 15;
        }

        public override void Cast()
        {
            if (IsFirstStage)//一段计时中
            {
                //释放二段,按原冷却时间计时
                base.Cast();
                return;
            }
            //首次释放,开始一段计时
            _sw2 = Stopwatch.StartNew();
        }

        public override void Reset()
        {
            _sw2?.Stop();
            _sw2 = null;
            base.Reset();
        }

        public override void Draw(Graphics g, Size rectSz)
        {
            if (IsFirstStage)
            {
                g.DrawImage(Image.FromFile($"Icons\\{Name}.png"), new RectangleF(new PointF(0, 0), rectSz));

                int cdRemains = CooldownRemains;
                double cdPercent = CooldownPercent;

                SizeF sz = g.MeasureString(cdRemains.ToString(), DrawFont);
                PointF drawPt = new PointF(Math.Abs(rectSz.Width / 2f - sz.Width / 2), Math.Abs(rectSz.Height / 2f - sz.Height / 2));
                g.FillPie(new SolidBrush(Color.FromArgb(127, Color.Black)),
                    new Rectangle(/*-rectSz.Width / 2, -rectSz.Height / 2, rectSz.Width * 2, rectSz.Height * 2*/0, 0, rectSz.Width, rectSz.Height),
                    -90 + 360 * (float)(1 - cdPercent),
                    360 * (float)cdPercent);


                g.DrawString(cdRemains.ToString(), DrawFont, Brushes.Gold, drawPt);

                //渐变白边
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(-rectSz.Width / 2, -rectSz.Height / 2, rectSz.Width * 2, rectSz.Height * 2);
                path.AddEllipse(3, 3, rectSz.Width - 3 * 2, rectSz.Height - 3 * 2);

                PathGradientBrush brush = new PathGradientBrush(path);
                brush.CenterColor = Color.FromArgb(10, 255, 255, 255);
                brush.SurroundColors = new Color[] { Color.FromArgb(230, 255, 255, 255) };

                g.FillPath(brush, path);

                g.DrawRectangle(new Pen(Color.Black, 2f), new Rectangle(0, 0, rectSz.Width - 2, rectSz.Height - 2));

                return;
            }

            base.Draw(g, rectSz);
        }
    }
}
