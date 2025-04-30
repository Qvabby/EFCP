using EFCP.Services;
using qvabbytesD1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.HelperMethods
{
    public class MenuHelperMethods
    {
        ConsoleOutputVisualizer _visualizer;
        public MenuHelperMethods(ConsoleOutputVisualizer visualizer) { _visualizer = visualizer; }

        /// <summary>
        /// Prints the menu options to the console and returns the option numbers.
        /// </summary>
        /// <param name="options">List that should contain menu options looking something like this: "1. Start", "2. Go Back"</param>
        /// <returns>returns symbols before . (for example if you have 1. Start it will return list with 1, if you have 1. Start 2. Go back it will return list of 1 and 2)</returns>
        public IEnumerable<string> printMenuOptions(ICollection<string> options)
        {
            try
            {
                if (options == null || options.Count == 0)
                {
                    _visualizer.Qprint("No options available.", "Red");
                    return Enumerable.Empty<string>();
                }
                var optionsNums = options.Select(x => x.Split('.')[0]).ToList();
                foreach (var i in options)
                {
                    _visualizer.Qprint(i, "White");
                }
                return optionsNums;
            }
            catch (Exception e)
            {
                ConsoleMessagesWriter cmw = new ConsoleMessagesWriter();
                cmw.WriteErrorMessage(e.Message);
                return Enumerable.Empty<string>();
            }
        }
        public bool isValidInput(string input, IEnumerable<string> options)
        {
            try
            {
                if (string.IsNullOrEmpty(input) || options == null || !options.Contains(input))
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                ConsoleMessagesWriter cmw = new ConsoleMessagesWriter();
                cmw.WriteErrorMessage(e.Message);
                return false;
            }

        }
    }
}
