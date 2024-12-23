namespace TagsCloudVisualization.FileReaders;

public class TxtFileReader : IFileReader
{
    public bool CanRead(string pathToFile)
    {
        return pathToFile.Split('.')[^1] == "txt";
    }

    public string[] Read(string pathToFile)
    {
        return File.ReadAllText(pathToFile).Split(Environment.NewLine);
    }
}