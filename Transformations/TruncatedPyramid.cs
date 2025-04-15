namespace Transformations;

public class TruncatedPyramid
{
    public double PyramidHeight { get; set; }
    public double BaseTriangleSide { get; set; }
    public double SecondaryTriangleSide { get; set; }

    private double[,] VertexMatrix { get; set; }
    
    public TruncatedPyramid(double pyramidHeight, double baseTriangleSide, double secondaryTriangleSide)
    {
        PyramidHeight = pyramidHeight;
        BaseTriangleSide = baseTriangleSide;
        SecondaryTriangleSide = secondaryTriangleSide;
        
        var baseTriangleHeight = Math.Sqrt(Math.Pow(BaseTriangleSide, 2) - Math.Pow(BaseTriangleSide / 2, 2));
        var secondaryTriangleHeight = Math.Sqrt(Math.Pow(SecondaryTriangleSide, 2) - Math.Pow(SecondaryTriangleSide / 2, 2));

        VertexMatrix = new [,]
        {
            { -baseTriangleHeight / 3, 0, -0.5d * baseTriangleSide, 1 },
            { -baseTriangleHeight / 3, 0, 0.5d * baseTriangleSide, 1 },
            { 2 * baseTriangleHeight / 3, 0, 0, 1 },
            { -secondaryTriangleHeight / 3, pyramidHeight, -0.5d * secondaryTriangleSide, 1 },
            { -secondaryTriangleHeight / 3, pyramidHeight, 0.5d * secondaryTriangleSide, 1 },
            { 2 * secondaryTriangleHeight / 3, pyramidHeight, 0, 1 }
        };
    }
}