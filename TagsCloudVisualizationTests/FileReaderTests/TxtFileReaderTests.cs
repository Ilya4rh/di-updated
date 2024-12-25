using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.FileReaders;

namespace TagsCloudVisualizationTests.FileReaderTests;

[TestFixture]
public class TxtFileReaderTests
{
    [Test]
    public void ReadText_TxtFile_ReturnWordsInFile()
    {
        var reader = new TxtFileReader();

        var words = reader.Read("FileReaderTests/FilesForTests/fileTxt.txt");

        words.Should().BeEquivalentTo(["Привет", "мир", "Школа", "Промышленной", "Разработки"]);
    }

    [Test]
    public void ReadText_DocFile_ReturnWordsInFile()
    {
        var reader = new DocFileReader();

        var words = reader.Read("FileReaderTests/FilesForTests/fileDoc.doc");
        
        words.Should().BeEquivalentTo(["Привет", "Интересная", "задача", "Любопытно"]);
    }

    [Test]
    public void ReadText_DocxFile_ReturnWordsInFile()
    {
        var reader = new DocxFileReader();

        var words = reader.Read("FileReaderTests/FilesForTests/fileDocx.docx");
        
        words.Should().BeEquivalentTo(["Третий", "файл", "Тоже", "работает"]);
    }
}