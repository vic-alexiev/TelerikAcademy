using System;

namespace AcademyGeometry
{
    public class FigureControllerEx : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        double radius = Double.Parse(splitFigString[2]);
                        currentFigure = new Circle(center, radius);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D top = Vector3D.Parse(splitFigString[1]);
                        Vector3D bottom = Vector3D.Parse(splitFigString[2]);
                        double radius = Double.Parse(splitFigString[3]);
                        currentFigure = new Cylinder(top, bottom, radius);
                        break;
                    }
            }

            base.ExecuteFigureCreationCommand(splitFigString);
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        IAreaMeasurable areaMeasurableFigure = currentFigure as IAreaMeasurable;
                        if (areaMeasurableFigure != null)
                        {
                            Console.WriteLine(areaMeasurableFigure.GetArea().ToString("F2"));
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "volume":
                    {
                        IVolumeMeasurable volumeMeasurableFigure = currentFigure as IVolumeMeasurable;
                        if (volumeMeasurableFigure != null)
                        {
                            Console.WriteLine(volumeMeasurableFigure.GetVolume().ToString("F2"));
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "normal":
                    {
                        IFlat flatFigure = currentFigure as IFlat;
                        if (flatFigure != null)
                        {
                            Console.WriteLine(flatFigure.GetNormal());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
            }

            base.ExecuteFigureInstanceCommand(splitCommand);
        }
    }
}
