using System.Windows.Media.Media3D;

namespace Transformations;

public sealed class TruncatedPyramid : Shape
{
    public double PyramidHeight { get; set; }
    public double BaseTriangleSide { get; set; }
    public double SecondaryTriangleSide { get; set; }
    public override double[,] DefaultVerticesMatrix { get; set; }
    
    private Point3D Rotation = new Point3D(0, 0, 0);
    
    public int[,] ConnectionsMatrix { get; set; } = new[,]
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
            { -secondaryTriangleHeight / 3, -pyramidHeight, -0.5d * secondaryTriangleSide, 1 },
            { -secondaryTriangleHeight / 3, -pyramidHeight, 0.5d * secondaryTriangleSide, 1 },
            { 2 * secondaryTriangleHeight / 3, -pyramidHeight, 0, 1 }
        };
        
    }

    public override void Scale(double x, double y, double z)
    {
        TransformMatrix[0, 0] = x;
        TransformMatrix[1, 1] = y;
        TransformMatrix[2, 2] = z;
    }

    public override void Rotate(double angleX, double angleY, double angleZ)
    {
        Rotation.X = angleX;
        Rotation.Y = angleY;
        Rotation.Z = angleZ;
    }

    public override void Translate(double x, double y, double z)
    {
        TransformMatrix[3, 0] = x;
        TransformMatrix[3, 1] = y;
        TransformMatrix[3, 2] = z;
    }

    private double[,] ApplyRotate()
    {
        double radiansX = Rotation.X * Math.PI / 180;
        double radiansY = Rotation.Y * Math.PI / 180;
        double radiansZ = Rotation.Z * Math.PI / 180;

        double[,] rotationXMatrix =
        {
            { 1, 0, 0, 0 },
            { 0, Math.Cos(radiansX), Math.Sin(radiansX), 0 },
            { 0, -Math.Sin(radiansX), Math.Cos(radiansX), 0 },
            { 0, 0, 0, 1 }
        };

        double[,] rotationYMatrix =
        {
            { Math.Cos(radiansY), 0, -Math.Sin(radiansY), 0 },
            { 0, 1, 0, 0 },
            { Math.Sin(radiansY), 0, Math.Cos(radiansY), 0 },
            { 0, 0, 0, 1 }
        };

        double[,] rotationZMatrix =
        {
            { Math.Cos(radiansZ), Math.Sin(radiansZ), 0, 0 },
            { -Math.Sin(radiansZ), Math.Cos(radiansZ), 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };
        
        var rotationMatrix = new double[,]
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

        
        rotationMatrix = Matrix.MultiplyMatrices(rotationMatrix, rotationXMatrix);
        rotationMatrix = Matrix.MultiplyMatrices(rotationMatrix, rotationYMatrix);
        rotationMatrix = Matrix.MultiplyMatrices(rotationMatrix, rotationZMatrix);
        
        return rotationMatrix;
    }

    public void ReflectYoZ()
    {
        double[,] reflectMatrix =
        {
            { -1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

        TransformMatrix = Matrix.MultiplyMatrices(TransformMatrix, reflectMatrix);
    }

    public void ReflectXoZ()
    {
        double[,] reflectMatrix =
        {
            { 1, 0, 0, 0 },
            { 0, -1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

        TransformMatrix = Matrix.MultiplyMatrices(TransformMatrix, reflectMatrix);
    }

    public void ReflectXoY()
    {
        double[,] reflectMatrix =
        {
            { -1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

        TransformMatrix = Matrix.MultiplyMatrices(TransformMatrix, reflectMatrix);
    }
    
    public override double[,] GetTransformedVertices()
    {
        var tmp = Matrix.MultiplyMatrices(DefaultVerticesMatrix, TransformMatrix);
        return Matrix.MultiplyMatrices(tmp, ApplyRotate());
    }
}