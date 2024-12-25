namespace TagsCloudVisualization.FileReaders;

public class TxtFileReader : IFileReader
{
    public bool CanRead(string pathToFile)
    {
        return pathToFile.Split('.')[^1].Equals("txt", StringComparison.InvariantCultureIgnoreCase);
    }

    public List<string> Read(string pathToFile)
    {
        var paragraphs = File.ReadAllText(pathToFile)
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var wordsInText = WordsHandlerHelper.GetWordsInText(paragraphs);
        
        return wordsInText;
    }
}