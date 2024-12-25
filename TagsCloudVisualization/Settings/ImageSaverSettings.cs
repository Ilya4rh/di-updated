namespace TagsCloudVisualization.Settings;

public class ImageSaverSettings
{
    public ImageSaverSettings(string filePath, string fileName, string fileFormat)
    {
        FilePath = filePath;
        FileName = fileName;
        FileFormat = fileFormat;
    }

    public string FilePath { get; }
    
    public string FileName { get; }
    
    public string FileFormat { get; }
}