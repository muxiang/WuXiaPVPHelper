using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.太白
{
    [Serializable]
    public class 烟霞满天 : Skill
    {
        public 烟霞满天()
        {
            Name = "烟霞满天";
            Cooldown = 90;
        }
    }
}
