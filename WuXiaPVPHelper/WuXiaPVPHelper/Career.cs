using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper
{
    [Serializable]
    public class Career
    {
        public string Name { get; set; }
        
        public List<Skill> Skills { get; set; }
    }
}
