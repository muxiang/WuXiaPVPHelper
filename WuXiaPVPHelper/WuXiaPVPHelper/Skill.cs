using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WuXiaPVPHelper
{
    /// <summary>
    /// 技能基类
    /// </summary>
    [Serializable]
    public abstract class Skill
    {
        //计时秒表
        protected Stopwatch _sw;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public int Cooldown { get; protected set; }

        /// <summary>
        /// 冷却时间剩余
        /// </summary>
        public virtual int CooldownRemains
        {
            get { return _sw == null ? 0 : CoerceValue(Cooldown - (int)_sw.ElapsedMilliseconds / 1000, 0, 1000); }
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnable
        {
            get { return CooldownRemains <= 0; }
        }

        /// <summary>
        /// 确保值不越界
        /// </summary>
        /// <param name="raw">原值</param>
        /// <param name="lo">最低</param>
        /// <param name="hi">最高</param>
        /// <returns></returns>
        protected static int CoerceValue(int raw, int lo, int hi)
        {
            if (raw <= lo) return lo;
            if (raw >= hi) return hi;
            return raw;
        }

        /// <summary>
        /// 释放技能
        /// </summary>
        public virtual void Cast()
        {
            _sw = Stopwatch.StartNew();
        }

        /// <summary>
        /// 冷却完成时调用重置
        /// </summary>
        public virtual void Reset()
        {
            _sw.Stop();
            _sw = null;
        }

        public static Skill CreateByName(string name)
        {
            ConstructorInfo ctorInfo = Assembly.GetExecutingAssembly().GetExportedTypes().FirstOrDefault(t => t.Name == name).GetConstructor(new Type[] { });
            return ctorInfo?.Invoke(null) as Skill;
        }
    }
}
