using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinntCore;

namespace VierGewinnt.Core.Tests
{
    [TestClass]
    public class Linientest
    {
        [TestMethod]
        public void UeberpruefeObVierInEinerReiheKorrekt()
        {
            var plaetze = new List<IPlatz>
            {
                new Platz(0,0){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(0,1){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(0,2){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(0,3){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo") }
            };
            var testTarget = new LinienDummy(plaetze);
            var spielerName = testTarget.UeberpruefeObVierInEinerReihe();
            Assert.AreEqual("Foo", spielerName);
        }

        [TestMethod]
        public void VierInEinerReiheUnterbrochenKorrekt()
        {
            var plaetze = new List<IPlatz>
            {
                new Platz(0,1){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(0,2){ Spielstein = new Spielstein(new Farbe(3,0,0), "Bar")},
                new Platz(0,3){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(1,1){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(1,2){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(1,3){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo") }
            };
            var testTarget = new LinienDummy(plaetze);
            var spielerName = testTarget.UeberpruefeObVierInEinerReihe();
            Assert.AreEqual("Foo", spielerName);
        }

        [TestMethod]
        public void KeinGewinnerGefunden()
        {
            var plaetze = new List<IPlatz>
            {
                new Platz(0,1){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(0,2){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo")},
                new Platz(0,3){ Spielstein = new Spielstein(new Farbe(3,0,0), "Bar")},
                new Platz(0,4){ Spielstein = new Spielstein(new Farbe(128,0,0), "Foo") }
            };
            var testTarget = new LinienDummy(plaetze);
            var spielerName = testTarget.UeberpruefeObVierInEinerReihe();
            Assert.IsNull(spielerName);
        }
    }
}
