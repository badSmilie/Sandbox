using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinntCore;

namespace VierGewinnt.Core.Tests
{
    [TestClass]
    public class Spaltentest
    {
        [TestMethod]
        public void SpielsteinWirdKorrektInLeereSpalteEingefuegt()
        {
            var plaetze = new List<IPlatz>();
            for (int i = 0; i < 6; i++)
            {
                plaetze.Add(new Platz(0,0));
            }
            var testTarget = new Spalte(1, plaetze);
            var spielstein = new Spielstein(new Farbe(0, 0, 0), "Foo");
            testTarget.LasseSpielsteinFallen(spielstein);
            for (int i = 0; i < plaetze.Count; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual(spielstein, plaetze[i].Spielstein);
                    continue;
                }
                Assert.IsNull(plaetze[i].Spielstein);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SpalteVoll()
        {
            var spielstein = new Spielstein(new Farbe(0, 0, 0), "Foo");
            var plaetze = new List<IPlatz>();
            for (int i = 0; i < 6; i++)
            {
                plaetze.Add(new Platz(0,0) { Spielstein = spielstein });
            }
            var testTarget = new Spalte(1, plaetze);

            testTarget.LasseSpielsteinFallen(spielstein);
        }

        [TestMethod]
        public void SpalteVollFalseZurueck()
        {
            var plaetze = new List<IPlatz>();
            var spielstein = new Spielstein(new Farbe(0, 0, 0), "Foo");
            for (int i = 0; i < 6; i++)
            {
                plaetze.Add(new Platz(0,0));
            }
            plaetze[0].Spielstein = spielstein;
            plaetze[1].Spielstein = spielstein;
            var testTarget = new Spalte(1, plaetze);
            Assert.IsFalse(testTarget.IstSpalteVoll);
        }

        [TestMethod]
        public void SpalteVollTrueZurueck()
        {
            var plaetze = new List<IPlatz>();
            var spielstein = new Spielstein(new Farbe(0, 0, 0), "Foo");
            for (int i = 0; i < 6; i++)
            {
                plaetze.Add(new Platz(0,0) { Spielstein = spielstein });
            }
            plaetze[0].Spielstein = spielstein;
            plaetze[1].Spielstein = spielstein;
            var testTarget = new Spalte(1, plaetze);
            Assert.IsTrue(testTarget.IstSpalteVoll);
        }
    }
}
