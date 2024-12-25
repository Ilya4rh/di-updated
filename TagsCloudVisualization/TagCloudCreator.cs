using System.Drawing;
using TagsCloudVisualization.TagLayouters;
using TagsCloudVisualization.Visualization;

namespace TagsCloudVisualization;

public class TagCloudCreator
{
    private readonly ITagLayouter tagLayouter;
    private readonly IImageDrawer imageDrawer;

    public TagCloudCreator(ITagLayouter tagLayouter, IImageDrawer imageDrawer)
    {
        this.tagLayouter = tagLayouter;
        this.imageDrawer = imageDrawer;
    }

    public Bitmap CreateImage()
    {
        var tags = tagLayouter.GetTags();
        var bitmap = imageDrawer.Draw(tags);

        return bitmap;
    }
}