using TagsCloudVisualization.FileReaders;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.TextHandlers;

public class TextHandler : ITextHandler
{
    private readonly IEnumerable<string> words;
    private readonly HashSet<string> boringWords;
    private readonly IFileReader[] readers;

    public TextHandler(IFileReader[] readers, TextHandlerSettings settings)
    {
        this.readers = readers;
        var reader = GetReader(settings.PathToText);

        words = reader.Read(settings.PathToText);
        
        var boringWordsReader = GetReader(settings.PathToBoringWords);

        boringWords = boringWordsReader.Read(settings.PathToBoringWords).ToHashSet();
    }

    public Dictionary<string, int> GetWordsCount()
    {
        var wordsCount = new Dictionary<string, int>();

        foreach (var word in words)
        {
            var lowerWord = word.ToLower();
            
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

        return wordsCount;
    }
    
    private IFileReader GetReader(string path)
    {
        var reader = readers.FirstOrDefault(r => r.CanRead(path));
        
        return reader ?? throw new ArgumentException($"Can't read file with path {path}");
    }
}