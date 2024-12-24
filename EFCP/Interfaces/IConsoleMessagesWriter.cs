using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.Interfaces
{
    public interface IConsoleMessagesWriter
    {
        public void WriteSuccessMessage(string message);
        public void WriteErrorMessage(string message);
    }
}
