using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.太白
{
    [Serializable]
    public class 天峰五云剑 : Skill
    {
        public 天峰五云剑()
        {
            Name = "天峰五云剑";
            Cooldown = 20;
        }
    }
}
