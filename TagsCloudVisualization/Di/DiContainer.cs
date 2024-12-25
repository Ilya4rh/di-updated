using Autofac;
using TagsCloudVisualization.CircularCloudLayouters;
using TagsCloudVisualization.ColorGenerator;
using TagsCloudVisualization.FileReaders;
using TagsCloudVisualization.LayoutAlgorithms;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.TagLayouters;
using TagsCloudVisualization.TextHandlers;
using TagsCloudVisualization.Visualization;

namespace TagsCloudVisualization.Di;

public class DiContainer
{
    public static IContainer Configure(CommandLineOptions options)
    {
        var builder = new ContainerBuilder();
        
        builder.RegisterType<BackgroundSettings>().WithParameters(new[]
        {
            new NamedParameter("colorName", options.BackgroundColor)
        });
        
        builder.RegisterType<CircularLayoutAlgorithmSettings>().WithParameters(new[]
        {
            new NamedParameter("stepIncreasingAngle", options.StepIncreasingAngle),
            new NamedParameter("stepIncreasingRadius", options.StepIncreasingRadius)
        });
        
        builder.RegisterType<ColorGeneratorSettings>().WithParameters(new[]
        {
            new NamedParameter("colorName", options.Color)
        });

        builder.RegisterType<ImageSaverSettings>().WithParameters(new[]
        {
            new NamedParameter("filePath", options.PathToSaveDirectory),
            new NamedParameter("fileName", options.FileName),
            new NamedParameter("fileFormat", options.FileFormat)
        });
        
        builder.RegisterType<ImageSettings>().WithParameters(new[]
        {
            new NamedParameter("width", options.ImageWidth),
            new NamedParameter("height", options.ImageHeight)
        });
        
        builder.RegisterType<TagLayouterSettings>().WithParameters(new[]
        {
            new NamedParameter("fontName", options.Font),
            new NamedParameter("minSize", options.MinFontSize),
            new NamedParameter("maxSize", options.MaxFontSize)
        });
        
        builder.RegisterType<TextHandlerSettings>().WithParameters(new[]
        {
            new NamedParameter("pathToBoringWords", options.PathToBoringWords),
            new NamedParameter("pathToText", options.PathToText),
        });

        builder.RegisterType<CircularLayoutAlgorithm>().As<ILayoutAlgorithm>();
        builder.RegisterType<CircularCloudLayouter>().As<ICircularCloudLayouter>();
        builder.RegisterType<ColorGenerator.ColorGenerator>().As<IColorGenerator>();
        builder.RegisterType<TxtFileReader>().As<IFileReader>();
        builder.RegisterType<DocFileReader>().As<IFileReader>();
        builder.RegisterType<DocxFileReader>().As<IFileReader>();
        builder.RegisterType<ImageDrawer>().As<IImageDrawer>();
        builder.RegisterType<ImageSaver>().As<IImageSaver>();
        builder.RegisterType<TextHandler>().As<ITextHandler>();
        builder.RegisterType<TagLayouter>().As<ITagLayouter>();
        builder.RegisterType<TagCloudCreator>();
        
        return builder.Build();
    }
}