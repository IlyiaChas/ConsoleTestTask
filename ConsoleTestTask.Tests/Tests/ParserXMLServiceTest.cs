using ConsoleTestTask.Data.Factories;
using ConsoleTestTask.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestTask.Tests.Tests
{
    public class ParserXMLServiceTest
    {
        [Fact]
        public void GetConfiguration2()
        {
            ConfigurationNameField configurationNameField = new ConfigurationNameField()
            {
                StartTag = "config",
                Name = "name",
                Discription = "description"
            };

            ParserFactory parserFactory = new ParserFactory(configurationNameField);
            string type = "xml";
            var parse = parserFactory.GetParesr(type);
            var filePath = Path.Combine(Directory.GetCurrentDirectory()
                                            .Split("ConsoleTestTask")[0] + $"ConsoleTestTask/ConsoleTestTask.Tests/Data/file.{type}");

            var configurations = parse.GetConfigurations(filePath);
            Assert.Equal(configurations[0].Name, "Конфигурация 1");
            Assert.Equal(configurations[0].Description, "Описание Конфигурации 1");
        }
    }
}
