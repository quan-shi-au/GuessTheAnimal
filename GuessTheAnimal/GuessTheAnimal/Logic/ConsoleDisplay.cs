using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessTheAnimal.Interface;

namespace GuessTheAnimal.Logic
{
    public class ConsoleDisplay : IConsoleDisplay
    {
        public string GetInputLine()
        {
            return Console.ReadLine();

        }

        public void OutputLine(string content)
        {
            Console.WriteLine(content);
        }

        public void OutputEmptyLine()
        {
            // leave some space
            Console.WriteLine(string.Empty);

        }
    }
}
