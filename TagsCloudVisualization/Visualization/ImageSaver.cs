using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Visualization;

public class ImageSaver : IImageSaver
{
    private readonly ImageSaverSettings settings;

    public ImageSaver(ImageSaverSettings settings)
    {
        this.settings = settings;
    }

    public void Save(Bitmap bitmap)
    {
        var filePath = settings.FilePath;
        var fileName = settings.FileName;
        var imageFormat = GetImageFormat(settings.FileFormat);
        
        if (!Directory.Exists(settings.FilePath))
        {
            Directory.CreateDirectory(settings.FilePath);
        }

        bitmap.Save(Path.Combine(filePath, $"{fileName}.{settings.FileFormat}"), imageFormat);
    }

    private static ImageFormat GetImageFormat(string format)
    {
        try
        {
            var imageFormatConverter = new ImageFormatConverter();
            var imageFormat = imageFormatConverter.ConvertFromString(format);
            
            if (imageFormat != null)
                return (ImageFormat)imageFormat;
            
            throw new ArgumentException($"Can't convert format from this string {format}");
        }
        catch (NotSupportedException)
        {
            throw new NotSupportedException($"File with format {format} doesn't supported");
        }
    }
}