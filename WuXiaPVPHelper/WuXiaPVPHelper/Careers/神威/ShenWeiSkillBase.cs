using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WuXiaPVPHelper.Careers.神威
{
    [Serializable]
    public abstract class ShenWeiSkillBase : Skill
    {
        protected int OriginCooldown;

        private bool _secondCast = false;

        public ShenWeiSkillBase()
        {
            Cooldown = OriginCooldown;
        }

        public override bool IsEnable
        {
            get { return base.IsEnable || _secondCast; }
        }

        public override void Reset()
        {
            _secondCast = true;
            Cooldown = OriginCooldown;
            base.Reset();
        }

        public override void Cast()
        {
            if (!_secondCast)
            {
                base.Cast();
                _secondCast = true;
                return;
            }
            Cooldown = (int)(OriginCooldown * 40f / 100f);
            _secondCast = false;
        }

        public override void Draw(Graphics g, Size rectSz)
        {
            if (_secondCast)
            {
                g.DrawImage(Icon, new RectangleF(new PointF(0, 0), rectSz));

                if (base.IsEnable) return;

                int cdRemains = CooldownRemains;
                double cdPercent = CooldownPercent;

                SizeF sz = g.MeasureString(cdRemains.ToString(), DrawFont);
                PointF drawPt = new PointF(Math.Abs(rectSz.Width / 2f - sz.Width / 2),
                    Math.Abs(rectSz.Height / 2f - sz.Height / 2));
                g.FillPie(new SolidBrush(Color.FromArgb(127, Color.Black)),
                    new Rectangle( /*-rectSz.Width / 2, -rectSz.Height / 2, rectSz.Width * 2, rectSz.Height * 2*/
                        0, 0, rectSz.Width, rectSz.Height),
                    -90 + 360 * (float)(1 - cdPercent),
                    360 * (float)cdPercent);

                g.DrawString(cdRemains.ToString(), DrawFont, Brushes.Gold, drawPt);

                //渐变白边
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(-rectSz.Width / 2, -rectSz.Height / 2, rectSz.Width * 2, rectSz.Height * 2);
                path.AddEllipse(3, 3, rectSz.Width - 3 * 2, rectSz.Height - 3 * 2);

                PathGradientBrush brush = new PathGradientBrush(path);
                brush.CenterColor = Color.FromArgb(10, 255, 255, 255);
                brush.SurroundColors = new Color[] { Color.FromArgb(220, 255, 255, 255) };

                g.FillPath(brush, path);

                g.DrawRectangle(new Pen(Color.Black, 2f), new Rectangle(0, 0, rectSz.Width - 2, rectSz.Height - 2));
            }
            else
            {
                g.DrawImage(Icon, new RectangleF(new PointF(0, 0), rectSz));
                if (base.IsEnable) return;

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

            if (CooldownRemains <= 0) Reset();
        }
    }
}
