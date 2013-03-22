using AcademyGeometry;
using System;

class AcademyGeometryDemo
{
    private static FigureController GetFigureController()
    {
        return new FigureControllerEx();
    }

    static void Main()
    {
        var figController = GetFigureController();

        int figCreationsCount = int.Parse(Console.ReadLine());
        int endCommandsCount = 0;

        while (endCommandsCount < figCreationsCount)
        {
            figController.ExecuteCommand(Console.ReadLine());
            if (figController.EndCommandExecuted)
            {
                endCommandsCount++;
            }
        }
    }
}
