
using Spire.Doc;

namespace TagsCloudVisualization.FileReaders;

public class DocFileReader : IFileReader
{
    public bool CanRead(string pathToFile)
    {
        return pathToFile.Split('.')[^1] == "doc";
    }

    public string[] Read(string pathToFile)
    {
        var doc = new Document();
        
        doc.LoadFromFile(pathToFile);
        
        var text = doc.GetText();
        
        
        return text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }
}