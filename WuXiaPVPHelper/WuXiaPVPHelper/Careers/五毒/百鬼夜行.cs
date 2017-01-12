using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.五毒
{
    [Serializable]
    public class 百鬼夜行 : Skill
    {
        public 百鬼夜行()
        {
            Name = "百鬼夜行";
            Cooldown = 60;
        }
    }
}
