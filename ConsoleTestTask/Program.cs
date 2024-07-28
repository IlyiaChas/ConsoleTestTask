using ConsoleTestTask.Data.Factories;
using ConsoleTestTask.Data.Helpers;
using ConsoleTestTask.Data.Model;


ConfigurationNameField configurationNameField = new ConfigurationNameField()
{
    StartTag = "config",
    Name = "name",
    Discription = "description"
};

ParserFactory parserFactory = new ParserFactory(configurationNameField);
Console.WriteLine("Type File (.xml or .csv)");
string type = Console.ReadLine().ToLower();
var parse = parserFactory.GetParesr(type);
var filePath = Path.Combine(Directory.GetCurrentDirectory()
                                .Split("ConsoleTestTask")[0] + $"ConsoleTestTask/ConsoleTestTask/Data/file.{type}");
var configurations = parse.GetConfigurations(filePath);
new Print().PrintConfigurations(configurations);

Console.ReadKey();