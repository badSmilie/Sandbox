namespace VierGewinntCore
{
    public class Farbe
    {


        private readonly byte rot;
        private readonly byte blau;
        private readonly byte gruen;

        public Farbe(byte pRot, byte pBlau, byte pGruen)
        {
            rot = pRot;
            blau = pBlau;
            gruen = pGruen;
        }

        public byte Rot => rot;

        public byte Blau => blau;

        public byte Gruen => gruen;
    }
}