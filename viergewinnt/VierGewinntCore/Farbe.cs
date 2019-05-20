using System.IO;

namespace VierGewinntCore
{
    public class Farbe : IFarbe
    {
        private readonly byte rot;
        private readonly byte blau;
        private readonly byte gruen;
        private string _image;

        public Farbe(byte pRot, byte pBlau, byte pGruen)
        {
            rot = pRot;
            blau = pBlau;
            gruen = pGruen;
        }

        public Farbe(byte pRot, byte pBlau, byte pGruen, string image) : this(pRot, pBlau, pGruen)
        {
            _image = image;
        }
        public byte Rot => rot;

        public byte Blau => blau;

        public byte Gruen => gruen;
        public string Image { get => _image; }
    }
}