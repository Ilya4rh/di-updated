using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace TagsCloudVisualization.FileReaders;

public class DocxFileReader : IFileReader
{
    public bool CanRead(string path)
    {
        return path.Split('.')[^1].Equals("docx", StringComparison.InvariantCultureIgnoreCase);
    }

    public List<string> Read(string path)
    {
        using var wordDocument = WordprocessingDocument.Open(path, false);
        var body = wordDocument.MainDocumentPart?.Document.Body;
        var paragraphsOfText = body?.Descendants<Text>().Select(text => text.Text);
        var wordsInText = WordsHandlerHelper.GetWordsInText(paragraphsOfText!);

        return wordsInText;
    }
}