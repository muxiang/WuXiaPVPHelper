using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.真武
{
    [Serializable]
    public class 动愈守中 : Skill
    {
        public 动愈守中()
        {
            Name = "动愈守中";
            Cooldown = 45;
        }
    }
}
