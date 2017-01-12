using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.五毒
{
    [Serializable]
    public class 寄生诀 : Skill
    {
        public 寄生诀()
        {
            Name = "寄生诀";
            Cooldown = 60;
        }
    }
}
