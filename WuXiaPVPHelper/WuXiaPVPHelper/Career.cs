using System;
using System.Collections.Generic;

namespace WuXiaPVPHelper
{
    [Serializable]
    public class Career
    {
        public string Name { get; set; }
        
        public SortedList<int,Skill> Skills { get; set; }
    }
}
