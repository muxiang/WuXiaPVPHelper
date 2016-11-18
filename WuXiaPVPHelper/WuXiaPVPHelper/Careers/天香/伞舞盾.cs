using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.天香
{
    [Serializable]
    public class 伞舞盾:Skill
    {
        public 伞舞盾()
        {
            Name = "伞舞盾";
            Cooldown = 40;
        }
    }
}
