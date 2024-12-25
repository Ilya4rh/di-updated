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
            new NamedParameter("backgroundColor", options.BackgroundColor)
        });
        
        builder.RegisterType<CircularLayoutAlgorithmSettings>().WithParameters(new[]
        {
            new NamedParameter("stepIncreasingAngle", options.StepIncreasingAngle),
            new NamedParameter("stepIncreasingRadius", options.StepIncreasingRadius)
        });
        
        builder.RegisterType<ColorGeneratorSettings>().WithParameters(new[]
        {
            new NamedParameter("color", options.Color)
        });

        builder.RegisterType<ImageSaverSettings>().WithParameters(new[]
        {
            new NamedParameter("pathToSaveDirectory", options.PathToSaveDirectory),
            new NamedParameter("fileName", options.FileName),
            new NamedParameter("fileFormat", options.FileFormat)
        });
        
        builder.RegisterType<ImageSettings>().WithParameters(new[]
        {
            new NamedParameter("imageWidth", options.ImageWidth),
            new NamedParameter("imageHeight", options.ImageHeight)
        });
        
        builder.RegisterType<TagLayouterSettings>().WithParameters(new[]
        {
            new NamedParameter("font", options.Font),
            new NamedParameter("minFontSize", options.MinFontSize),
            new NamedParameter("maxFontSize", options.MaxFontSize)
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
        builder.RegisterType<TagLayouter>().As<ITagLayouter>();
        builder.RegisterType<TextHandler>().As<ITextHandler>();
        builder.RegisterType<ImageDrawer>().As<IImageDrawer>();
        builder.RegisterType<ImageSaver>().As<IImageSaver>();
        builder.RegisterType<TagCloudCreator>();
        
        return builder.Build();
    }
}