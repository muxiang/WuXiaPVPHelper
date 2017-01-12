using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.唐门
{
    [Serializable]
    public class 自替身 : Skill
    {
        public 自替身()
        {
            Name = "自替身";
            Cooldown = 35;
        }
    }
}
