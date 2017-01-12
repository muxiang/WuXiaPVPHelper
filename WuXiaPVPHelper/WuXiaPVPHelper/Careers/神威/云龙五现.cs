using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.神威
{
    [Serializable]
    public class 云龙五现 : Skill
    {
        private const int OriginCooldown = 22;

        public 云龙五现()
        {
            Name = "云龙五现";
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
