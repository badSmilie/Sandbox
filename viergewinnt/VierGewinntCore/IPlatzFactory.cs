namespace VierGewinntCore
{
    public interface IPlatzFactory
    {
        IPlatz Erstelle(int spaltenIndex, int zeilenIndex);
    }
}