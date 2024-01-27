using PointLab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                            writer.WriteLine($"Point3D X:{point3D.X} Y:{point3D.Y} Z:{point3D.Z}");
                            break;
                        case "Point":
                            writer.WriteLine($"Point X:{point.X} Y:{point.Y}");
                            break;
                    } 
                }
            }
        }
        public object Deserialize(Stream stream)
        {
            List<Point> points_out = new List<Point>();
            String text = "";
            using (var reader = new StreamReader(stream)) { text = reader.ReadToEnd(); }
            text = text.Replace("\n", "");
            String[] points = text.Split('\r');
            foreach (var point in points)
            {
                String[] row = point.Split(' ');
                if (row[0] == "Point")
                {
                    Point pont = new Point(int.Parse(row[1].Split(':')[1]), int.Parse(row[2].Split(':')[1]));
                    points_out.Add(pont);
                }
                if (row[0] == "Point3D") 
                { 
                    Point3D pont3 = new Point3D(int.Parse(row[1].Split(':')[1]), int.Parse(row[2].Split(':')[1]), int.Parse(row[3].Split(':')[1]));
                    points_out.Add(pont3);
                }
            }
            return points_out.ToArray();
        }
    }
}
