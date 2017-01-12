using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.五毒
{
    [Serializable]
    public class 凤凰绝杀 : Skill
    {
        public 凤凰绝杀()
        {
            Name = "凤凰绝杀";
            Cooldown = 18;
        }
    }
}
