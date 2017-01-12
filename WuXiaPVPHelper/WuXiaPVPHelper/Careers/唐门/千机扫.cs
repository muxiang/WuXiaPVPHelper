using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.唐门
{
    [Serializable]
    public class 千机扫 : Skill
    {
        public 千机扫()
        {
            Name = "千机扫";
            Cooldown = 15;
        }
    }
}
