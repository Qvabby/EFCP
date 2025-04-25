using EFCP.Interfaces;
using Microsoft.Extensions.Options;
using qvabbytesD1;

namespace EFCP.Services
{
    public class MenuService : IMenuService
    {
        //Console Visualizers.
        ConsoleMessagesWriter CMW = new ConsoleMessagesWriter();
        ConsoleOutputVisualizer visualizer = new ConsoleOutputVisualizer();

        IUserService _userManagementService;
        IGameService _gameService;
        ILeetcodeProblemsService _leetCodeProblemsService;
        public MenuService(IUserService userManagementService, IGameService gameService, ILeetcodeProblemsService leetCodeProblemsService)
        {
            _userManagementService = userManagementService;
            _gameService = gameService;
            _leetCodeProblemsService = leetCodeProblemsService;
        }

        public async Task MenuAsync()
        {
            //Menu
            try
            {
                Console.ResetColor();
                //Menu
                visualizer.BreakLine(2);
                visualizer.Qprint("\tEFCP MENU.\t", "Green", "White");
                visualizer.BreakLine(1);
                var options = new List<string> { "1. User Management", "2. Games", "3. LeetCode Problems", "4. Exit" };
                var optionsNums = options.Select(x => x.Split('.')[0]).ToList();
                foreach (var i in options)
                {
                    visualizer.Qprint(i, "White");
                }
                visualizer.QprintOnLine("\nSelect an option: ", "White");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();
                bool isValid = false;
                if (input != null)
                    isValid = optionsNums.Contains(input.ToString());
                if (!isValid)
                {
                    CMW.WriteErrorMessage("Invalid input. Please try again.");
                    await MenuAsync();
                }
                else
                {
                    switch (input)
                    {
                        case "1":
                            await _userManagementService.UserManagementMenuAsync();
                            Console.ResetColor();
                            await MenuAsync();
                            break;
                        case "2":
                            await _gameService.GameMenuAsync();
                            Console.ResetColor();
                            await MenuAsync();
                            break;
                        case "3":
                            await _leetCodeProblemsService.LeetCodeProblemsMenuAsync();
                            Console.ResetColor();
                            await MenuAsync();
                            break;
                        case "4":
                            CMW.WriteSuccessMessage("Exiting EFCP. Goodbye :)");
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                CMW.WriteErrorMessage(e.Message);
                await MenuAsync();
            }
        }
    }
}
