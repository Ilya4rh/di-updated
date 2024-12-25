using System.Drawing;

namespace TagsCloudVisualization.Settings;

public class TagLayouterSettings
{
    public TagLayouterSettings(int minSize, int maxSize, string fontName)
    {
        MinSize = minSize;
        FontFamily = new FontFamily(fontName);
        MaxSize = maxSize;
    }

    public FontFamily FontFamily { get; }
    
    public int MinSize { get; }
    
    public int MaxSize { get; }
}