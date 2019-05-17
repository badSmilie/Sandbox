using System.Collections.Generic;
using VierGewinntCore;

namespace VierGewinnt.Core.Tests
{
    public class LinienDummy : Linie
    {
        public LinienDummy(IReadOnlyList<IPlatz> pPlaetze) : base(pPlaetze)
        {

        }
    }
}
