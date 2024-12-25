
using System.Text.RegularExpressions;
using Spire.Doc;

namespace TagsCloudVisualization.FileReaders;

public class DocFileReader : IFileReader
{
    public bool CanRead(string pathToFile)
    {
        return pathToFile.Split('.')[^1] == "doc";
    }

    public List<string> Read(string pathToFile)
    {
        var words = new List<string>();
        var doc = new Document();
        
        doc.LoadFromFile(pathToFile);
        
        var text = doc.GetText();
        var paragraphs = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var paragraph in paragraphs)
        {
            var wordsInParagraph = Regex.Matches(paragraph, @"\b\w+\b")
                .Select(word => word.Value);
            
            words.AddRange(wordsInParagraph);
        }
        
        
        return words;
    }
}