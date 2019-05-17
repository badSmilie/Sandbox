namespace VierGewinntCore
{
    public interface ISpalte
    {
        void LasseSpielsteinFallen(Spielstein stein);
        bool IstSpalteVoll { get; }
        IPlatz NextEmptyCell { get; }
        int Index { get; }
    }
}