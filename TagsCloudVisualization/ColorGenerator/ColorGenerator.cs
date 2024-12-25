using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.ColorGenerator;

public class ColorGenerator : IColorGenerator
{
    private readonly ColorGeneratorSettings colorGeneratorSettings;
    private readonly Random random;
    
    public ColorGenerator(ColorGeneratorSettings colorGeneratorSettings)
    {
        this.colorGeneratorSettings = colorGeneratorSettings;
        random = new Random();
    }
    
    public Color GetColor()
    {
        if (colorGeneratorSettings.ColorName == "random")
        {
            return Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
        }
        
        return Color.FromName(colorGeneratorSettings.ColorName);
    }
}