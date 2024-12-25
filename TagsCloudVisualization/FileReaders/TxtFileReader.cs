using System.Text.RegularExpressions;

namespace TagsCloudVisualization.FileReaders;

public class TxtFileReader : IFileReader
{
    public bool CanRead(string pathToFile)
    {
        return pathToFile.Split('.')[^1] == "txt";
    }

    public List<string> Read(string pathToFile)
    {
        var words = new List<string>();
        var paragraphs = File.ReadAllText(pathToFile)
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (var paragraph in paragraphs)
        {
            var wordsInParagraph = Regex.Matches(paragraph, @"\b\w+\b")
                .Select(word => word.Value);
            
            words.AddRange(wordsInParagraph);
        }
        
        return words;
    }
}