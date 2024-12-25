namespace TagsCloudVisualization.Settings;

public class CircularLayoutAlgorithmSettings
{
    public const double OneDegree = Math.PI / 180;
    
    public CircularLayoutAlgorithmSettings(double stepIncreasingAngle, double stepIncreasingRadius)
    {
        StepIncreasingAngle = stepIncreasingAngle;
        StepIncreasingRadius = stepIncreasingRadius;
    }

    public double StepIncreasingAngle { get; }
    
    public double StepIncreasingRadius { get; }
}