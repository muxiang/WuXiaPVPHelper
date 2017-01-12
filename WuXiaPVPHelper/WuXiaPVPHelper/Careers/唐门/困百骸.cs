using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.唐门
{
    [Serializable]
    public class 困百骸 : Skill
    {
        public 困百骸()
        {
            Name = "困百骸";
            Cooldown = 18;
        }
    }
}
