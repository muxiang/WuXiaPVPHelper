using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper
{
    /// <summary>
    /// 技能基类
    /// </summary>
    [Serializable]
    public abstract class Skill
    {
        //计时秒表
        protected Stopwatch Sw;

        private string _name;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            protected set
            {
                _name = value;
                Icon = Image.FromFile($"Icons\\{value}.png");
            }
        }

        /// <summary>
        /// 技能图标
        /// </summary>
        protected Image Icon { get; set; }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public int Cooldown { get; protected set; }

        /// <summary>
        /// 冷却时间剩余
        /// </summary>
        public virtual int CooldownRemains
        {
            get { return Sw == null ? 0 : CoerceValue(Cooldown - (int)Sw.ElapsedMilliseconds / 1000, 0, 1000); }
        }

        /// <summary>
        /// 冷却时间百分比(double)
        /// </summary>
        public virtual double CooldownPercent
        {
            get { return (double)CooldownRemains / Cooldown; }
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        public virtual bool IsEnable
        {
            get { return CooldownRemains <= 0; }
        }

        /// <summary>
        /// 释放技能
        /// </summary>
        public virtual void Cast()
        {
            Sw = Stopwatch.StartNew();
        }

        /// <summary>
        /// 冷却完成时调用重置
        /// </summary>
        public virtual void Reset()
        {
            Sw.Stop();
            Sw = null;
        }

        public virtual void Draw(Graphics g, Size rectSz)
        {
            g.DrawImage(Icon, new RectangleF(new PointF(0, 0), rectSz));
            if (IsEnable) return;

            int cdRemains = CooldownRemains;
            double cdPercent = CooldownPercent;

            SizeF sz = g.MeasureString(cdRemains.ToString(), DrawFont);
            PointF drawPt = new PointF(Math.Abs(rectSz.Width / 2f - sz.Width / 2), Math.Abs(rectSz.Height / 2f - sz.Height / 2));
            g.FillPie(new SolidBrush(Color.FromArgb(127, Color.Black)),
                new Rectangle(-rectSz.Width / 2, -rectSz.Height / 2, rectSz.Width * 2, rectSz.Height * 2),
                -90 + 360 * (float)(1 - cdPercent),
                360 * (float)cdPercent);

            g.DrawString(cdRemains.ToString(), DrawFont, Brushes.Gold, drawPt);
        }

        public virtual void Update()
        {

        }

        protected static readonly Font DrawFont = new Font("宋体", 60, FontStyle.Bold, GraphicsUnit.Pixel);

        /// <summary>
        /// 确保值不越界
        /// </summary>
        /// <param name="raw">原值</param>
        /// <param name="lo">最低</param>
        /// <param name="hi">最高</param>
        /// <returns></returns>
        protected static int CoerceValue(int raw, int lo, int hi)
        {
            if (raw <= lo) return lo;
            if (raw >= hi) return hi;
            return raw;
        }

        public static Skill CreateByName(string name)
        {
            ConstructorInfo ctorInfo = Assembly.GetExecutingAssembly().GetExportedTypes().FirstOrDefault(t => t.Name == name).GetConstructor(new Type[] { });
            return ctorInfo?.Invoke(null) as Skill;
        }
    }
}
