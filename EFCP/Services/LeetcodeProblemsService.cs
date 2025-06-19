using EFCP.HelperMethods;
using EFCP.Interfaces;
using qvabbytesD1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.Services
{
    public class LeetcodeProblemsService : ILeetcodeProblemsService
    {
        ConsoleMessagesWriter CMW = new ConsoleMessagesWriter();
        ConsoleOutputVisualizer visualizer = new ConsoleOutputVisualizer();
        MenuHelperMethods menuHelperMethods;
        public async Task LeetCodeProblemsMenuAsync()
        {
			try
			{
                Console.Clear();
                menuHelperMethods = new MenuHelperMethods(visualizer);
                Console.ResetColor();
                //Printing Menu
                visualizer.Qprint("Leetcode Problems.", "Green", "White");
                //Leetcode Problems Menu
                var optionsNums = menuHelperMethods.printMenuOptions(new List<string> { "1. Solved", "2. Solving", "3. Profile", "4. Go Back"});
                //Getting Input
                visualizer.QprintOnLine("\nSelect an option: ", "White");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();
                //Checking Validation
                if (!menuHelperMethods.isValidInput(input, optionsNums))
                {
                    CMW.WriteErrorMessage("Invalid input. Please try again.");
                    await LeetCodeProblemsMenuAsync();
                }
                else
                {

                }
            }
            catch (Exception e)
			{
                CMW.WriteErrorMessage($"An error occurred while displaying the game menu. Error Message: {e.Message}\nInner:{e.InnerException.Message} ");
                await LeetCodeProblemsMenuAsync();
            }
        }
    }
}
