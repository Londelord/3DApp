﻿namespace Transformations;

public static class Projection
{
    public static double[,] ProjectToXoY(double[,] matrix)
    {
        double[,] projectionMatrix = {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 1 }
        };
        return ConvertTo2D(ApplyProjection(matrix, projectionMatrix), Plane.XoY);
    }
    
    public static double[,] ProjectToXoZ(double[,] matrix)
    {
        double[,] projectionMatrix = {
            { 1, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };
        return ConvertTo2D(ApplyProjection(matrix, projectionMatrix), Plane.XoZ);
    }
    
    public static double[,] ProjectToYoZ(double[,] matrix)
    {
        double[,] projectionMatrix = {
            { 0, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };
        return ConvertTo2D(ApplyProjection(matrix, projectionMatrix), Plane.YoZ);
    }
    
    private static double[,] ApplyProjection(double[,] points, double[,] projectionMatrix) => 
        Matrix.MultiplyMatrices(points, projectionMatrix);
    
    private static double[,] ConvertTo2D(double[,] points3D, Plane plane)
    {
        int n = points3D.GetLength(0);
        double[,] points2D = new double[n, 2];

        for (int i = 0; i < n; i++)
        {
            switch (plane)
            {
                case Plane.XoY:
                    points2D[i, 0] = points3D[i, 0];
                    points2D[i, 1] = points3D[i, 1];
                    break;

                case Plane.XoZ:
                    points2D[i, 0] = points3D[i, 0];
                    points2D[i, 1] = points3D[i, 2];
                    break;

                case Plane.YoZ:
                    points2D[i, 0] = points3D[i, 1];
                    points2D[i, 1] = points3D[i, 2];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(plane), plane, null);
            }
        }

        return points2D;
    }
}