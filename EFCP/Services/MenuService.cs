using EFCP.Interfaces;
using Microsoft.Extensions.Options;
using qvabbytesD1;

namespace EFCP.Services
{
    public class MenuService : IMenuService
    {
        public void Menu()
        {
            //Console Visualizers.
            ConsoleMessagesWriter CMW = new ConsoleMessagesWriter();
            ConsoleOutputVisualizer visualizer = new ConsoleOutputVisualizer();
            //Menu
            try
            {
                visualizer.Qprint("Welcome to the EFCP system.", "Green");
                visualizer.Qwarning("Keep in mind that the project is UNFINISHED and is just for C#/.NET/EF Core Practicing.\n");
                var options = new List<string> { "1. Add User", "2. Get Users", "3. Update User", "4. Delete User", "5. Exit" };
                foreach (var i in options)
                {
                    visualizer.Qprint(i, "White");
                }
                visualizer.Qprint("\nSelect an option:", "White");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                CMW.WriteErrorMessage(e.Message);
            }
        }
    }
}
