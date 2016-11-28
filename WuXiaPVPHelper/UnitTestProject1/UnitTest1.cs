using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Keys k;
            if(Keys.TryParse(((Keys)113).ToString(), out k))
                Console.WriteLine(k);
        }
    }
}
