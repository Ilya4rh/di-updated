using System.Drawing;

namespace TagsCloudVisualization.Settings;

public class BackgroundSettings
{
    public BackgroundSettings(string colorName)
    {
        BackgroundColor = Color.FromName(colorName);
    }

    public Color BackgroundColor { get; }
}