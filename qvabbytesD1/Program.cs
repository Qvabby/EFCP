using Python.Runtime;

namespace qvabbytesD1;

internal class Program
{
    static void Main(string[] args)
    {
        PythonEngine.Initialize();
        using (Py.GIL())
        {
            dynamic script = Py.Import("sample");
            script.main();
        }
        PythonEngine.Shutdown();
    }
}
