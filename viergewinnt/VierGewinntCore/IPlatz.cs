namespace VierGewinntCore
{
    public interface IPlatz
    {
        Spielstein Spielstein { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}