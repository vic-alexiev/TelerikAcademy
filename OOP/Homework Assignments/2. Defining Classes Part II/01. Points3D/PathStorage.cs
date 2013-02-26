using System;
using System.IO;

namespace Points3D
{
    public static class PathStorage
    {
        public static Path LoadPath(string fileFullName)
        {
            if (String.IsNullOrWhiteSpace(fileFullName))
            {
                throw new ArgumentException("File name cannot be null or empty.");
            }

            if (!File.Exists(fileFullName))
            {
                throw new ArgumentException("The specified file doesn't exist in the local file system.");
            }

            Path points = new Path();

            using (StreamReader fileReader = new StreamReader(fileFullName))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] coordinates = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double x, y, z;
                    if (coordinates.Length == 3 &&
                        Double.TryParse(coordinates[0], out x) &&
                        Double.TryParse(coordinates[1], out y) &&
                        Double.TryParse(coordinates[2], out z))
                    {
                        Point3D point = new Point3D(x, y, z);
                        points.Add(point);
                    }
                }
            }

            return points;
        }

        public static void SavePath(Path points, string fileFullName)
        {
            if (String.IsNullOrWhiteSpace(fileFullName))
            {
                throw new ArgumentException("File name cannot be null or empty.");
            }

            using (StreamWriter fileWriter = new StreamWriter(fileFullName, false))
            {
                foreach (Point3D point in points)
                {
                    string line = String.Format("{0:F2} {1:F2} {2:F2}", point.X, point.Y, point.Z);
                    fileWriter.WriteLine(line);
                }
            }
        }
    }
}
