namespace TagsCloudVisualization.Settings;

public class CircularLayoutAlgorithmSettings
{
    public const double OneDegree = Math.PI / 180;
    
    public CircularLayoutAlgorithmSettings(double stepIncreasingAngle = OneDegree, int stepIncreasingRadius = 1)
    {
        StepIncreasingAngle = stepIncreasingAngle;
        StepIncreasingRadius = stepIncreasingRadius;
    }

    public double StepIncreasingAngle { get; }
    
    public int StepIncreasingRadius { get; }
}