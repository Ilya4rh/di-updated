namespace TagsCloudVisualization.Settings;

public class TextHandlerSettings
{
    public TextHandlerSettings(string pathToBoringWords, string pathToText)
    {
        PathToBoringWords = pathToBoringWords;
        PathToText = pathToText;
    }

    public string PathToBoringWords { get; }
    
    public string PathToText { get; }
}