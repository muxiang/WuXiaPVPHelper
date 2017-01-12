using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuXiaPVPHelper.Careers.神威
{
    [Serializable]
    public class 猛虎破 : Skill
    {
        private const int OriginCooldown = 22;

        public 猛虎破()
        {
            Name = "猛虎破";
            Cooldown = OriginCooldown;
        }

        public new void Cast(bool duringBeiShui)
        {
            if (duringBeiShui)
                Cooldown = OriginCooldown / 2;
            else
                Cooldown = OriginCooldown;

            base.Cast();
        }
    }
}
