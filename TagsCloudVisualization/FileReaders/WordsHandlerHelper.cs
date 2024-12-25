using System.Text.RegularExpressions;

namespace TagsCloudVisualization.FileReaders;

public class WordsHandlerHelper
{
    public static List<string> GetWordsInText(IEnumerable<string> paragraphsOfText)
    {
        var words = new List<string>();
        
        foreach (var paragraph in paragraphsOfText)
        {
            var wordsInParagraph = Regex.Matches(paragraph, @"\b[a-zA-Zа-яА-Я]+\b")
                .Select(word => word.Value);
            
            words.AddRange(wordsInParagraph);
        }

        return words;
    }
}