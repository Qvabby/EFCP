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
        public async Task GameMenuAsync()
        {
			try
			{
                Console.ResetColor();
                //Game Menu
                var options = new List<string> {"1. Wordle", "2. Go Back" };
                var optionsNums = options.Select(x => x.Split('.')[0]).ToList();
                //Printing Menu

                visualizer.BreakLine(2);
                visualizer.Qprint("\tGAME MENU.\t", "Green", "White");
                visualizer.BreakLine();

                foreach (var i in options)
                {
                    visualizer.Qprint(i, "Red");
                }
                //Getting Input
                visualizer.QprintOnLine("\nSelect an option: ", "Red");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();
                //Checking Validation
                bool isValid = false;
                if (input != null)
                    isValid = optionsNums.Contains(input.ToString());
                if (!isValid)
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
            }
        }
    }
}