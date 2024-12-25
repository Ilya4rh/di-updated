namespace TagsCloudVisualization.FileReaders;

public interface IFileReader
{
    bool CanRead(string pathToFile);

    List<string> Read(string pathToFile);
}