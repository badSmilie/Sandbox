using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinntCore;
using System.Windows.Media;

namespace VierGewinnt.WpfClient.Tests
{
    [TestClass]
    public class FarbkonverterTests
    {
        private Farbkonverter testTarget;

        [TestInitialize]
        public void TestInitialize()
        {
            testTarget = new Farbkonverter();
        }

        [TestMethod]
        public void FarbkonverterGibtFarbe()
        {
            var farbe = new Farbe(255, 128, 0);
            var targetFarbe = Color.FromRgb(farbe.Rot, farbe.Gruen, farbe.Rot);
            var resultFarbe = (SolidColorBrush)testTarget.Convert(farbe, null, null, null);

            Assert.AreEqual(targetFarbe, resultFarbe.Color);
        }
    }
}
