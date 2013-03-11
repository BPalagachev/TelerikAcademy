using System;
using _01.Geometrics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestRectangle
    {
        [TestMethod]
        public void RectagnleSufrace()
        {
            int width = 5;
            int height = 10;
            Shape rectangle = new Rectangle(width, height);
            double expected = 50d;

            Assert.AreEqual(expected, rectangle.CalculateSurface());
        }
    }
}
