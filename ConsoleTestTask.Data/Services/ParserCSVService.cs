using ConsoleTestTask.Data.Interfaces;
using ConsoleTestTask.Data.Model;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleTestTask.Data.Services
{
    public class ParserCSVService : IParser
    {
        private ConfigurationNameField _configurationNameField;
        public ParserCSVService(ConfigurationNameField configurationNameField)
        {
            _configurationNameField = configurationNameField;
        }

        public List<Configuration> GetConfigurations(string path)
        {
            List<Configuration> configurations = new List<Configuration>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                string[] values = parser.ReadFields();
                ConvertConfigurationNameField(values);
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    var config = GetConfiguration(fields);
                    if (config == null)
                        continue;
                    configurations.Add(config);
                }
            }
            return configurations;
        }

        private void ConvertConfigurationNameField(string[] values)
        {
            for (int i = 0; i < values.Count(); i++)
            {
                if (values[i] == _configurationNameField.Name)
                {
                    _configurationNameField.Name = i.ToString();
                    continue;
                }        
                if (values[i] == _configurationNameField.Discription)
                {
                    _configurationNameField.Discription = i.ToString();
                    continue;
                }
            }
        }

        private Configuration GetConfiguration(string[] fields)
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration.Name = fields[Convert.ToInt32( _configurationNameField.Name)];
                configuration.Description = fields[Convert.ToInt32(_configurationNameField.Discription)];
                return configuration;
            }
            catch
            {
                return null;
            }
        }
    }
}
