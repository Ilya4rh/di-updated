using System.Drawing;
using TagsCloudVisualization.ColorGenerator;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Visualization;

public class ImageDrawer : IImageDrawer
{
    private readonly ImageSettings imageSettings;
    private readonly BackgroundSettings backgroundSettings;
    private readonly IColorGenerator colorGenerator;

    public ImageDrawer(
        ImageSettings imageSettings, 
        BackgroundSettings backgroundSettings, 
        IColorGenerator colorGenerator)
    {
        this.imageSettings = imageSettings;
        this.backgroundSettings = backgroundSettings;
        this.colorGenerator = colorGenerator;
    }

    public Bitmap Draw(IEnumerable<Tag> tags)
    {
        var bitmap = new Bitmap(imageSettings.Width, imageSettings.Height);
        var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(backgroundSettings.BackgroundColor);
        
        foreach (var tag in tags)
        {
            graphics.DrawString(tag.Content, 
                new Font(tag.Font, tag.Size), 
                new SolidBrush(colorGenerator.GetColor()),
                tag.Rectangle);
        }
        return bitmap;
    }
}