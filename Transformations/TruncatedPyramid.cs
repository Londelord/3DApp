namespace Transformations;

public sealed class TruncatedPyramid : Shape
{
    public double PyramidHeight { get; set; }
    public double BaseTriangleSide { get; set; }
    public double SecondaryTriangleSide { get; set; }
    protected override double[,] DefaultVerticesMatrix { get; set; }
    public int[,] ConnectionsMatrix { get; set; }
    
    public TruncatedPyramid(double pyramidHeight, double baseTriangleSide, double secondaryTriangleSide)
    {
        PyramidHeight = pyramidHeight;
        BaseTriangleSide = baseTriangleSide;
        SecondaryTriangleSide = secondaryTriangleSide;
        
        var baseTriangleHeight = Math.Sqrt(Math.Pow(BaseTriangleSide, 2) - Math.Pow(BaseTriangleSide / 2, 2));
        var secondaryTriangleHeight = Math.Sqrt(Math.Pow(SecondaryTriangleSide, 2) - Math.Pow(SecondaryTriangleSide / 2, 2));

        DefaultVerticesMatrix = new [,]
        {
            { -baseTriangleHeight / 3, 0, -0.5d * baseTriangleSide, 1 },
            { -baseTriangleHeight / 3, 0, 0.5d * baseTriangleSide, 1 },
            { 2 * baseTriangleHeight / 3, 0, 0, 1 },
            { -secondaryTriangleHeight / 3, pyramidHeight, -0.5d * secondaryTriangleSide, 1 },
            { -secondaryTriangleHeight / 3, pyramidHeight, 0.5d * secondaryTriangleSide, 1 },
            { 2 * secondaryTriangleHeight / 3, pyramidHeight, 0, 1 }
        };

        ConnectionsMatrix = new[,]
        {
            { 0, 1 },
            { 1, 2 },
            { 0, 2 },
            
            { 3, 4 },
            { 4, 5 },
            { 3, 5 },
            
            { 0, 3 },
            { 1, 4 },
            { 2, 5 }
        };
    }

    protected override void Scale(double x, double y, double z)
    {
        throw new NotImplementedException();
    }

    protected override void Rotate(double angleX, double angleY, double angleZ)
    {
        throw new NotImplementedException();
    }

    protected override void Translate(double x, double y, double z)
    {
        throw new NotImplementedException();
    }

    public override double[,] GetTransformedVertices() => 
        Matrix.MultiplyMatrices(DefaultVerticesMatrix, TransformMatrix);
}