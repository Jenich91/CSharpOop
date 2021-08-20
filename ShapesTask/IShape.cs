namespace AcademIT.Vyatkin
{
    public interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();

        string ToString();
    }
}