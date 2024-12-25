using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

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

        using var wordDocument = WordprocessingDocument.Open(path, false);
        var body = wordDocument.MainDocumentPart?.Document.Body;
            
        foreach (var text in body?.Descendants<Text>()!)
        {
            var wordsInText = Regex.Matches(text.Text, @"\b\w+\b")
                .Select(match => match.Value);
            words.AddRange(wordsInText);
        }

        return words;
    }
}