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
    public class GameService : IGameService
    {
        //Console Visualizers.
        ConsoleMessagesWriter CMW = new ConsoleMessagesWriter();
        ConsoleOutputVisualizer visualizer = new ConsoleOutputVisualizer();
        MenuHelperMethods menuHelperMethods;
        public async Task GameMenuAsync()
        {
			try
			{
                Console.Clear();
                menuHelperMethods = new MenuHelperMethods(visualizer);
                Console.ResetColor();
                //Printing Menu
                visualizer.Qprint("GAME Menu.", "Green", "White");
                //Game Menu
                var optionsNums = menuHelperMethods.printMenuOptions(new List<string> { "1. Wordle", "2. Go Back" });
                //Getting Input
                visualizer.QprintOnLine("\nSelect an option: ", "White");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();
                //Checking Validation
                if (!menuHelperMethods.isValidInput(input,optionsNums))
                {
                    CMW.WriteErrorMessage("Invalid input. Please try again.");
                    await GameMenuAsync();
                }
                else
                {
                    //If Valid
                    switch (input)
                    {
                        case "1":
                            WordleService wordleService = new WordleService();
                            wordleService.PlayWordle();
                            await GameMenuAsync().ConfigureAwait(false);
                            break;
                        case "2":
                            break;
                        default:
                            CMW.WriteErrorMessage("Invalid input. Please try again.");
                            await GameMenuAsync();
                            break;
                    }
                }
            }
			catch (Exception e)
			{
                CMW.WriteErrorMessage($"An error occurred while displaying the game menu. Error Message: {e.Message}\nInner:{e.InnerException.Message} ");
                await GameMenuAsync();
            }
        }
    }
}