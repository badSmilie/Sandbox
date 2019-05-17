using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinntCore;

namespace VierGewinnt.Core.Tests
{
    [TestClass]
    public class SpielTest
    {
        [TestMethod]
        public void EntferneEinElementAusDenSpielsteinen()
        {
            var spielsteine = new List<Spielstein>
            {
                new Spielstein(new Farbe(128,0,0), "Foo"),
                new Spielstein(new Farbe(128,0,0), "Foo")
            };

            int initialCount = spielsteine.Count;
            var testTarget = new Spieler("Foo", spielsteine, new Farbe (128, 0, 0));
            var spalte = new SpalteMock();

            testTarget.SpieleZug(spalte);

            Assert.AreEqual(initialCount - 1, testTarget.Spielsteine.Count);
        }

        [TestMethod]
        public void SpieleZugLaesstEinenSpielsteinFallen()
        {
            var spielsteine = new List<Spielstein>
            {
                new Spielstein(new Farbe(128,0,0), "Foo"),
                new Spielstein(new Farbe(128,0,0), "Foo")
            };

            var testTarget = new Spieler("Foo", spielsteine, new Farbe (128, 0, 0));
            var spalte = new SpalteMock();

            testTarget.SpieleZug(spalte);

            Assert.IsTrue(spalte.SpielsteinFallenAufgerufenEinmal);
        }
    }

    public class SpalteMock : ISpalte
    {
        private int count;

        public bool SpielsteinFallenAufgerufenEinmal
        {
            get
            {
                return count == 1;
            }
        }

        public bool IstSpalteVoll => throw new NotImplementedException();

        public Platz NextEmptyCell => throw new NotImplementedException();

        public int Index => throw new NotImplementedException();

        IPlatz ISpalte.NextEmptyCell => throw new NotImplementedException();

        public void LasseSpielsteinFallen(Spielstein spielstein)
        {
            count++;
        }
    }
}
