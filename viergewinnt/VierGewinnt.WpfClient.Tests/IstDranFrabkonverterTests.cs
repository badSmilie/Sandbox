using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinntCore;
using System.Windows.Media;

namespace VierGewinnt.WpfClient.Tests
{
    [TestClass]
    public class IstDranFarbkonverterTests
    {
        private IstDranFarbkonverter testTarget; 

        [TestInitialize]
        public void TestInitialize()
        {
            testTarget = new IstDranFarbkonverter();
        }

        [TestMethod]
        public void KonverterGibtTransparent()
        { 
            
            SolidColorBrush brush = (SolidColorBrush)testTarget.Convert(false, null, null, null);

            Assert.AreEqual(Colors.Transparent, brush.Color);
        }

        [TestMethod]
        public void KonverterGibtFarbe()
        {

            SolidColorBrush brush = (SolidColorBrush)testTarget.Convert(true, null, null, null);

            Assert.AreEqual(Colors.Silver, brush.Color);
        }
    }
}
