using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.天香
{
    [Serializable]
    public class 柳暗凌波 : Skill
    {
        //一段冷却计时秒表
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
                    //减冷却时间
                    Cooldown -= FirstStageCooldown;
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

        public 柳暗凌波()
        {
            Name = "柳暗凌波";
            Cooldown = 30;
            FirstStageCooldown = 10;
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
                g.DrawImage(Image.FromFile($"Icons\\{Name}1.png"), new RectangleF(new PointF(0, 0), rectSz));

                int cdRemains = CooldownRemains;
                double cdPercent = CooldownPercent;

                SizeF sz = g.MeasureString(cdRemains.ToString(), DrawFont);
                PointF drawPt = new PointF(Math.Abs(rectSz.Width / 2f - sz.Width / 2), Math.Abs(rectSz.Height / 2f - sz.Height / 2));
                g.FillPie(new SolidBrush(Color.FromArgb(127, Color.Black)),
                    new Rectangle(-rectSz.Width / 2, -rectSz.Height / 2, rectSz.Width * 2, rectSz.Height * 2),
                    -90 + 360 * (float)(1 - cdPercent),
                    360 * (float)cdPercent);

                g.DrawString(cdRemains.ToString(), DrawFont, Brushes.Gold, drawPt);
                g.DrawRectangle(new Pen(Color.White, 6f), new Rectangle(0, 0, rectSz.Width - 3, rectSz.Height - 3));

                return;
            }

            base.Draw(g, rectSz);
        }
    }
}
