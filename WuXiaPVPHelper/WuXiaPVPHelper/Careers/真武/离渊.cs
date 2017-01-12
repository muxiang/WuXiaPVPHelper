using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.真武
{
    [Serializable]
    public class 离渊 : Skill
    {
        public 离渊()
        {
            Name = "离渊";
            Cooldown = 28;
        }
    }
}
