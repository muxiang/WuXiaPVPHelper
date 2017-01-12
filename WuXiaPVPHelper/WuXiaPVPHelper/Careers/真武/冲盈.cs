using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.真武
{
    [Serializable]
    public class 冲盈 : Skill
    {
        public 冲盈()
        {
            Name = "冲盈";
            Cooldown = 20;
        }
    }
}
