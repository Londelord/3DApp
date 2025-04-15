namespace Transformations;

public abstract class Shape
{
    public abstract double[,] DefaultVerticesMatrix { get; set; }
    protected double[,] TransformMatrix { get; set; } =
    {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
    };

    public abstract void Scale(double x, double y, double z);
    public abstract void Rotate(double angleX, double angleY, double angleZ);
    public abstract void Translate(double x, double y, double z);
    public abstract double[,] GetTransformedVertices();
}