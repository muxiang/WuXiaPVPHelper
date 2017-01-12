using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.神威
{
    [Serializable]
    public class 无敌无我 : Skill
    {
        private const int OriginCooldown = 35;

        public 无敌无我()
        {
            Name = "无敌无我";
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
