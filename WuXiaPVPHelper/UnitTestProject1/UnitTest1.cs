using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Bitmap bmp = (Bitmap)Image.FromFile("D:\\spr-2.png");

            Bitmap bmpOutput = new Bitmap(38, 38);

            using (Graphics g = Graphics.FromImage(bmpOutput))
            {
                g.DrawImage(bmp, 0, 0, new Rectangle(258, 27, 38, 38), GraphicsUnit.Pixel);
            }
            bmpOutput.Save("D:\\太白.png");
        }
    }
}
