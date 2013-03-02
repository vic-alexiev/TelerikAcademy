using Shapes;
using System;

class ShapesDemo
{
    static void Main()
    {
        Shape[] shapes = new Shape[]
        {
            new Triangle(3, 4),
            new Rectangle(6, 7),
            new Circle(5),
        };

        double[] shapeAreas = new double[shapes.Length];

        int index = 0;
        foreach (Shape shape in shapes)
        {
            shapeAreas[index] = shape.CalculateArea();
            Console.WriteLine("[{0}]: area = {1:F4}", shape.GetType(), shapeAreas[index]);
            index++;
        }
    }
}
