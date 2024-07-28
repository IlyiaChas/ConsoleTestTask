using ConsoleTestTask.Data.Model;

namespace ConsoleTestTask.Data.Interfaces
{
    public interface IParser
    {
        public List<Configuration> GetConfigurations(string path);
    }
}
