using EFCP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qvabbytesD1;

namespace EFCP.Services
{
    public class ConsoleMessagesWriter : IConsoleMessagesWriter
    {
        ConsoleOutputVisualizer visualizer = new ConsoleOutputVisualizer();
        public void WriteErrorMessage(string message)
        {
            visualizer.Qdanger(message);
        }

        public void WriteSuccessMessage(string message)
        {
            visualizer.Qsuccess(message);
        }
    }
}
