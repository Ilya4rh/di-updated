using Autofac;
using CommandLine;
using TagsCloudVisualization;
using TagsCloudVisualization.Di;
using TagsCloudVisualization.Visualization;

Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(commandLineOptions =>
    {
        var container = DiContainer.Configure(commandLineOptions);
        var cloudCreator = container.Resolve<TagCloudCreator>();
        var image = cloudCreator.CreateImage();
        var imageSaver = container.Resolve<IImageSaver>();
        
        imageSaver.Save(image);
    })
    .WithNotParsed(errors =>
    {
        foreach (var error in errors)
        {
            Console.WriteLine(error.ToString());
        }
        Environment.Exit(1);
    });