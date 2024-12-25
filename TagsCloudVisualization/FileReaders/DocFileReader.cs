using Spire.Doc;

namespace TagsCloudVisualization.FileReaders;

public class DocFileReader : IFileReader
{
    public bool CanRead(string pathToFile)
    {
        return pathToFile.Split('.')[^1].Equals("doc", StringComparison.CurrentCultureIgnoreCase);
    }

    public List<string> Read(string pathToFile)
    {
        var doc = new Document();
        
        doc.LoadFromFile(pathToFile);
        
        var text = doc.GetText();
        var paragraphs = text
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1);
        var wordsInText = WordsHandlerHelper.GetWordsInText(paragraphs);
        
        return wordsInText;
    }
}