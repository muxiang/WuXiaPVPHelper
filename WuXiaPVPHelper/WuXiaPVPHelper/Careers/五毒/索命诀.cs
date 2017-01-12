using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.五毒
{
    [Serializable]
    public class 索命诀 : Skill
    {
        public 索命诀()
        {
            Name = "索命诀";
            Cooldown = 25;
        }
    }
}
