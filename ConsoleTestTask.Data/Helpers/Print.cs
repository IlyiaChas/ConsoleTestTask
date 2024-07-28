using ConsoleTestTask.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestTask.Data.Helpers
{
    public class Print
    {
        public void PrintConfigurations(List<Configuration> configurations)
        {
            for (int i = 0; i < configurations.Count; i++)
            {
                Console.WriteLine($"Name - {configurations[i].Name}");
                Console.WriteLine($"Description - {configurations[i].Description}");
                Console.WriteLine();
            }
        }        
    }
}
