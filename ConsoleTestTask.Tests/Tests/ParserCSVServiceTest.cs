using ConsoleTestTask.Data.Factories;
using ConsoleTestTask.Data.Helpers;
using ConsoleTestTask.Data.Model;

namespace ConsoleTestTask.Tests.Tests
{
    public class ParserCSVServiceTest
    {
        [Fact]
        public void GetConfiguration2()
        {
            ConfigurationNameField configurationNameField = new ConfigurationNameField()
            {
                Name = "name",
                Discription = "description"
            };

            ParserFactory parserFactory = new ParserFactory(configurationNameField);
            string type = "csv";
            var parse = parserFactory.GetParesr(type);
            var filePath = Path.Combine(Directory.GetCurrentDirectory()
                                            .Split("ConsoleTestTask")[0] + $"ConsoleTestTask/ConsoleTestTask.Tests/Data/file.{type}");

            var configurations = parse.GetConfigurations(filePath);
            Assert.Equal(configurations[0].Name, "Конфигурация 2");
            Assert.Equal(configurations[0].Description, "Описание Конфигурации 2");
        }
    }
}
