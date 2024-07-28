using ConsoleTestTask.Data.Interfaces;
using ConsoleTestTask.Data.Model;
using System.Xml;

namespace ConsoleTestTask.Data.Services
{
    public class ParserXMLService : IParser
    {
        private ConfigurationNameField _configurationNameField;
        public ParserXMLService(ConfigurationNameField configurationNameField)
        {
            _configurationNameField = configurationNameField;
        }
        public List<Configuration> GetConfigurations(string path)
        {
            //TODO: XmlNamespaceManager
            List<Configuration> configurations = new List<Configuration>();
            using (StreamReader sr = new StreamReader(path))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(sr);
                XmlNodeList listXML = xDoc.GetElementsByTagName(_configurationNameField.StartTag);
                foreach (XmlNode item in listXML)
                {
                    var config = GetConfiguration(item);
                    if (config == null)
                        continue;
                    configurations.Add(config);
                }
            }
            return configurations;
        }

        private Configuration GetConfiguration(XmlNode xmlNode)
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration.Name = GetFieldString(_configurationNameField.Name , xmlNode);
                configuration.Description = GetFieldString(_configurationNameField.Discription , xmlNode);
                return configuration;
            }
            catch 
            {
                return null;
            }
        }

        private string GetFieldString(string field, XmlNode xml)
        {
            return xml.SelectSingleNode(field).InnerText;
        }
    }
}
