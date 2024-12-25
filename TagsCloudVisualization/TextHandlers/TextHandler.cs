using TagsCloudVisualization.FileReaders;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.TextHandlers;

public class TextHandler : ITextHandler
{
    private readonly IFileReader[] readers;
    private readonly TextHandlerSettings settings;

    public TextHandler(IFileReader[] readers, TextHandlerSettings settings)
    {
        this.readers = readers;
        this.settings = settings;
    }

    public Dictionary<string, int> GetWordsCount()
    {
        var reader = GetReader(settings.PathToText);
        var words = reader.Read(settings.PathToText);
        var boringWordsReader = GetReader(settings.PathToBoringWords);
        var boringWords = boringWordsReader.Read(settings.PathToBoringWords).ToHashSet();
        var wordsCount = new Dictionary<string, int>();

        foreach (var lowerWord in words.Select(word => word.ToLower()))
        {
            if (wordsCount.TryGetValue(lowerWord, out var value))
            {
                wordsCount[lowerWord] = ++value;
                continue;
            }
            if (!boringWords.Contains(lowerWord))
            {
                wordsCount[lowerWord] = 1;
            }
        }

        return wordsCount
            .OrderByDescending(p => p.Value)
            .ToDictionary();
    }
    
    private IFileReader GetReader(string path)
    {
        var reader = readers.FirstOrDefault(r => r.CanRead(path));
        
        return reader ?? throw new ArgumentException($"Can't read file with path {path}");
    }
}