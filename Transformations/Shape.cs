namespace Transformations;

public abstract class Shape
{
    protected abstract double[,] DefaultVerticesMatrix { get; set; }
    protected double[,] TransformMatrix { get; set; } =
    {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
    };

    protected abstract void Scale(double x, double y, double z);
    protected abstract void Rotate(double angleX, double angleY, double angleZ);
    protected abstract void Translate(double x, double y, double z);
    public abstract double[,] GetTransformedVertices();
}