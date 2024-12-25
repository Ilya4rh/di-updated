using Xceed.Words.NET;

namespace TagsCloudVisualization.FileReaders;

public class DocxFileReader : IFileReader
{
    public bool CanRead(string path)
    {
        return path.Split('.')[^1] == "docx";
    }

    public string[] Read(string path)
    {
        var doc = DocX.Load(path);
        
        return doc.Paragraphs.Select(p => p.Text).ToArray();
    }
}