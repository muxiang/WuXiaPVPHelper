using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.真武
{
    [Serializable]
    public class 微明生灭 : Skill
    {
        public 微明生灭()
        {
            Name = "微明生灭";
            Cooldown = 20;
        }
    }
}
