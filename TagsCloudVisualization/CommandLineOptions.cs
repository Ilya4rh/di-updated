using CommandLine;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization;

public class CommandLineOptions
{
    [Option("pathToBoringWords", Default = "BoringWords.txt", HelpText = "Path to exclude boring words")]
    public string PathToBoringWords { get; set; }

    [Option('t', "pathToText", Default = "Text.txt", HelpText = "Path to text for the words cloud")]
    public string PathToText { get; set; }

    [Option('s', "pathToSaveDirectory", Default = "Images", HelpText = "Path to directory to save image")]
    public string PathToSaveDirectory { get; set; }

    [Option('n', "fileName", Default = "image", HelpText = "Name of the file to save")]
    public string FileName { get; set; }

    [Option("fileFormat", Default = "png", HelpText = "Extension file to save. Example: png")]
    public string FileFormat { get; set; }

    [Option("stepIncreasingAngle", Default = CircularLayoutAlgorithmSettings.OneDegree, HelpText = "Delta angle for the spiral.")]
    public double StepIncreasingAngle { get; set; }

    [Option("stepIncreasingRadius", Default = 1, HelpText = "Delta radius for the spiral.")]
    public double StepIncreasingRadius { get; set; }

    [Option("imageWidth", Default = 1920, HelpText = "Image width")]
    public int ImageWidth { get; set; }

    [Option("imageHeight", Default = 1080, HelpText = "Image height")]
    public int ImageHeight { get; set; }

    [Option('b', "backgroundColor", Default = "white", HelpText = "Image background color.")]
    public string BackgroundColor { get; set; }

    [Option("color", Default = "random", HelpText = "Color of the words. Default is random")]
    public string Color { get; set; }

    [Option("font", Default = "Times New Roman", HelpText = "Font of the words")]
    public string Font { get; set; }

    [Option("minFontSize", Default = 10, HelpText = "Minimum word font size")]
    public int MinFontSize { get; set; }

    [Option("maxFontSize", Default = 50, HelpText = "Maximum word font size")]
    public int MaxFontSize { get; set; }
}