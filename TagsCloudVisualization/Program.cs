using Autofac;
using CommandLine;
using TagsCloudVisualization;
using TagsCloudVisualization.Di;
using TagsCloudVisualization.Visualization;

var commandLineOptions = Parser.Default.ParseArguments<CommandLineOptions>(args).Value;
var container = DiContainer.Configure(commandLineOptions);
var cloudCreator = container.Resolve<TagCloudCreator>();

var image = cloudCreator.CreateImage();

var imageSaver = container.Resolve<IImageSaver>();

imageSaver.Save(image);