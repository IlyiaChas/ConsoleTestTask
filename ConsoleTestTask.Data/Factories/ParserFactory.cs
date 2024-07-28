using ConsoleTestTask.Data.Interfaces;
using ConsoleTestTask.Data.Model;
using ConsoleTestTask.Data.Services;

namespace ConsoleTestTask.Data.Factories
{
    public class ParserFactory
    {
        private ConfigurationNameField _configurationNameField;
        public ParserFactory(ConfigurationNameField configurationNameField)
        {
            _configurationNameField = configurationNameField;
        }

        public IParser GetParesr(string fileType)
        {
            switch (fileType)
            {
                case "csv":
                    return new ParserCSVService(_configurationNameField);
                case "xml":
                    return new ParserXMLService(_configurationNameField);
                default:
                    throw new Exception($"ParserFactory не может создать: {fileType} parser");
            }
        }
    }
}
