using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinntCore;

namespace VierGewinnt.WpfClient.Tests
{
    [TestClass]
    public class SpielerViewModelTests
    {
        [TestMethod]
        public void IstDranPropertyChanged()
        {
            var testTarget = new SpielerViewModel(new Spieler("Foo", new List<Spielstein>(), new Farbe(0, 3, 0)));
            int callCount = 0;
            testTarget.PropertyChanged += (sender, args) => callCount++;
            testTarget.IstDran = !testTarget.IstDran;

            Assert.AreEqual(1, callCount); 
        }
    }
}
