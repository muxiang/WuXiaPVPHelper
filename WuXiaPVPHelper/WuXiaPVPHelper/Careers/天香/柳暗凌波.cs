using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper.Careers.天香
{
    [Serializable]
    public class 柳暗凌波 : Skill
    {
        //一段冷却计时秒表
        private Stopwatch _sw2;

        /// <summary>
        /// 一段冷却时间
        /// </summary>
        public int FirstStageCooldown { get; set; }

        /// <summary>
        /// 是否为一段计时
        /// </summary>
        public bool IsFirstStage
        {
            get
            {
                if (_sw == null)
                {
                    if (_sw2 != null)
                        return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 根据属性IsFirstStage判断是否为一段计时
        /// </summary>
        public override int CooldownRemains
        {
            get
            {
                if (_sw == null)
                {
                    if (_sw2 == null)
                        return 0;

                    if ((int)_sw2.ElapsedMilliseconds / 1000 < FirstStageCooldown)
                        return (int)_sw2.ElapsedMilliseconds / 1000;

                    //自然结束一段计时,未释放二段
                    _sw2.Stop();
                    _sw2 = null;
                    //减冷却时间
                    Cooldown -= FirstStageCooldown;
                    base.Cast();
                }
                Debug.Assert(_sw != null, "_sw != null");
                int remain = Cooldown - (int)_sw.ElapsedMilliseconds / 1000;
                if (remain <= 0)
                {
                    Cooldown += FirstStageCooldown;
                    Reset();
                }
                return remain;
            }
        }
        public 柳暗凌波()
        {
            Name = "柳暗凌波";
            Cooldown = 30;
        }

        public override void Cast()
        {
            if (IsFirstStage)//一段计时中
            {
                //释放二段,按原冷却时间计时
                base.Cast();
                return;
            }
            //首次释放,开始一段计时
            _sw2 = Stopwatch.StartNew();
        }

        public override void Reset()
        {
            _sw2.Stop();
            _sw2 = null;
            base.Reset();
        }
    }
}
