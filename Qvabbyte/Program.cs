using Python.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qvabbyte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PythonEngine.PythonHome = @"C:\Program Files (x86)\Python39-32";
            //PythonEngine.PythonDll = @"C:\Program Files\Python312\python312.dll";
            PythonEngine.Initialize();

            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Qvabbyte.py");
            string scriptDir = Path.GetDirectoryName(scriptPath);

            using (Py.GIL())
            {
                //adding script directory to sys.path
                dynamic sys = Py.Import("sys");
                sys.path.append(scriptDir);

                //Running script as module
                PythonEngine.RunSimpleString($"exec(open(r'''{scriptPath}''').read())");

            }

            PythonEngine.Shutdown();
        }
    }
}
