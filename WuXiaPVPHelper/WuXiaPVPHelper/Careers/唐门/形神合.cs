using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.唐门
{
    [Serializable]
    public class 形神合 : Skill
    {
        public 形神合()
        {
            Name = "形神合";
            Cooldown = 40;
        }
    }
}
