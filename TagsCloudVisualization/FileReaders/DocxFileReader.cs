using System.Text.RegularExpressions;
using Xceed.Words.NET;

namespace TagsCloudVisualization.FileReaders;

public class DocxFileReader : IFileReader
{
    public bool CanRead(string path)
    {
        return path.Split('.')[^1] == "docx";
    }

    public List<string> Read(string path)
    {
        var words = new List<string>();
        var doc = DocX.Load(path);
        
        foreach (var paragraph in doc.Paragraphs)
        {
            var wordsInParagraph = Regex.Matches(paragraph.Text, @"\b\w+\b")
                .Select(word => word.Value);
            
            words.AddRange(wordsInParagraph);
        }
        
        return words;
    }
}