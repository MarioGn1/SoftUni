using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OnlineShop.Models.Products.Computers;

namespace OnlineShopTests
{
    [TestFixture]
    public class Class1
    {
        private DesktopComputer computer;

        [Test]
        public void ConstructorTest()
        {
            computer = new DesktopComputer(02, "dell", "P02", 100M);

            Assert.That(computer.Components.Count, Is.EqualTo(0));
            Assert.That(computer.Peripherals.Count, Is.EqualTo(0));
        }

        [Test]
        public void OverallPerformanceTest()
        {
            Assert.That(computer.OverallPerformance, Is.EqualTo(15));

        }
    }
}
