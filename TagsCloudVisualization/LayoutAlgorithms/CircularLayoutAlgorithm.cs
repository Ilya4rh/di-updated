using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.LayoutAlgorithms;

public class CircularLayoutAlgorithm : ILayoutAlgorithm
{
    private readonly Point center;
    private readonly double stepIncreasingAngle;
    private readonly int stepIncreasingRadius;
    private double currentAngleOfCircle;
    private double currentRadiusOfCircle;
    private const double OneDegree = Math.PI / 180;
    private const double FullCircleRotation = 2 * Math.PI;

    public CircularLayoutAlgorithm(Point center, CircularLayoutAlgorithmSettings settings)
    {
        if (settings.StepIncreasingRadius <= 0)
            throw new ArgumentException("The parameter 'stepIncreasingRadius' is less than or equal to zero");
        if (settings.StepIncreasingAngle == 0)
            throw new ArgumentException("The parameter 'stepIncreasingAngle' is zero");

        this.center = center;
        stepIncreasingAngle = settings.StepIncreasingAngle;
        stepIncreasingRadius = settings.StepIncreasingRadius;
    }

    public Point CalculateNextPoint()
    {
        var x = center.X + (int)(currentRadiusOfCircle * Math.Cos(currentAngleOfCircle));
        var y = center.Y + (int)(currentRadiusOfCircle * Math.Sin(currentAngleOfCircle));

        currentAngleOfCircle += stepIncreasingAngle; 

        // проверяем не прошли ли целый круг или равен ли текущий радиус нулю
        if (currentAngleOfCircle > FullCircleRotation || currentRadiusOfCircle == 0)
        {
            currentAngleOfCircle = 0;
            currentRadiusOfCircle += stepIncreasingRadius;
        }

        return new Point(x, y);
    }
}