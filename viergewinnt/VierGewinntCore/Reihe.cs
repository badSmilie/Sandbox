using System.Collections.Generic;

namespace VierGewinntCore
{
    public class Reihe : Linie
    {
        // private readonly IReadOnlyList<IReadOnlyList<Platz>> plaetze;

        public Reihe(IReadOnlyList<IPlatz> pPlaetze) : base(pPlaetze)
        {
        }
    }
}