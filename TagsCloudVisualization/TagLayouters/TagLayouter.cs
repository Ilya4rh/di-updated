using System.Drawing;
using TagsCloudVisualization.CircularCloudLayouters;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Tags;
using TagsCloudVisualization.TextHandlers;

namespace TagsCloudVisualization.TagLayouters;

public class TagLayouter : ITagLayouter
{
    private readonly ICircularCloudLayouter circularCloudLayouter;
    private readonly ITextHandler textHandler;
    private readonly TagLayouterSettings tagLayouterSettings;
    private readonly Graphics graphics;

    public TagLayouter(
        ICircularCloudLayouter circularCloudLayouter, 
        ITextHandler textHandler,
        TagLayouterSettings tagLayouterSettings)
    {
        this.textHandler = textHandler;
        this.tagLayouterSettings = tagLayouterSettings;
        this.circularCloudLayouter = circularCloudLayouter;
        graphics = Graphics.FromHwnd(IntPtr.Zero);
    }

    public IEnumerable<Tag> GetTags()
    {
        var wordsCount = textHandler.GetWordsCount();
        var sortedWords = wordsCount
            .OrderByDescending(p => p.Value)
            .ToList();
        var maxWordCount = sortedWords.First().Value;
        var minWordCount = sortedWords.Last().Value;
        
        foreach (var wordWithCount in sortedWords)
        {
            var fontSize = GetFontSize(minWordCount, maxWordCount, wordWithCount.Value);
            yield return new Tag(wordWithCount.Key, 
                fontSize,
                circularCloudLayouter.PutNextRectangle(GetWordSize(wordWithCount.Key, fontSize)),
                tagLayouterSettings.FontFamily);
        }
    }
    
    private int GetFontSize(int minWordCount, int maxWordCount, int wordCount)
    {
        if (maxWordCount > minWordCount)
        {
            return tagLayouterSettings.MinSize + (tagLayouterSettings.MaxSize - tagLayouterSettings.MinSize)
                   * (wordCount - minWordCount) / (maxWordCount - minWordCount);
        }
        
        return tagLayouterSettings.MaxSize;
    }
    
    private Size GetWordSize(string content, int fontSize)
    {
        var sizeF = graphics.MeasureString(content, new Font(tagLayouterSettings.FontFamily, fontSize));
        
        return new Size((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));
    }
}