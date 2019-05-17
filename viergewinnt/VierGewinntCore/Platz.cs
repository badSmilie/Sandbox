using System;
using static VierGewinntCore.Spiel;

namespace VierGewinntCore
{
    public class Platz : IPlatz
    {
        public Spielstein Spielstein { get; set; }
        public int X { get; set; }
        public int Y {get; set; }

        public event Action<IPlatz> CellClicked;

        public Platz(int x, int y)
        {
            if (x < 0)
                throw new ArgumentException("x cannot be less than zero.");
            if (y < 0)
                throw new ArgumentException("y cannot be less than zero.");

            X = x;
            Y = y;
        }
    }
}