using PointLab;
using System;
using System.Collections.Generic;
using System.IO;

namespace FormsApp
{
    internal class CustomSerialize
    {
        public void Serialize(Stream stream, object data)
        {
            var points = (Point[])data;
            using (var writer = new StreamWriter(stream))
            {
                foreach (var point in points)
                {
                    switch (point.GetType().Name)
                    {
                        case "Point3D":
                            Point3D point3D = (Point3D)point;
                            writer.WriteLine($"-Point3D (X: {point3D.X} Y: {point3D.Y} Z: {point3D.Z})");
                            break;
                        case "Point":
                            writer.WriteLine($"-Point2D (X: {point.X} Y: {point.Y})");
                            break;
                    } 
                }
            }
        } 
    }
}
