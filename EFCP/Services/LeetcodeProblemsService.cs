using EFCP.HelperMethods;
using EFCP.Interfaces;
using LeetCode_Problems;
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
        Status status = new Status();

        /// <summary>
        /// Displays the interactive menu for managing LeetCode problems, allowing the user to view solved problems,
        /// problems in progress, profile information, or return to the previous menu.
        /// </summary>
        /// <remarks>The method prompts the user for input and validates the selection. If an invalid
        /// option is entered or an error occurs, the menu is redisplayed until a valid selection is made. The method is
        /// intended to be called from a console application and relies on user interaction.</remarks>
        /// <returns>A task that represents the asynchronous operation of displaying and handling the LeetCode problems menu.</returns>
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
                var optionsNums = menuHelperMethods.printMenuOptions(new List<string> { "1. Solved", "2. Solving", "3. Profile", "4. Go Back" });
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
                    switch (input)
                    {
                        case "1":
                            await ShowSolvedProblemsAsync();
                            break;

                        case "2":
                            await ShowSolvingProblemsAsync();
                            break;

                        case "3":

                            break;

                        case "4":

                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                CMW.WriteErrorMessage($"An error occurred while displaying the game menu. Error Message: {e.Message}\nInner:{e.InnerException.Message} ");
                await LeetCodeProblemsMenuAsync();
            }
        }

        /// <summary>
        /// Displays an interactive menu for the specified problem, allowing the user to view its status or demonstrate
        /// its solution if available.
        /// </summary>
        /// <remarks>If the problem is not solved, only a 'Go Back' option is presented. If the problem is
        /// solved, the user can choose to demonstrate the solution or go back. Invalid user input will prompt the menu
        /// again. This method is intended for use within a console-based application and relies on user input from the
        /// console.</remarks>
        /// <param name="selectedProblem">The name of the problem to display and interact with. Must correspond to a valid problem in the current
        /// status.</param>
        /// <returns>A task that represents the asynchronous operation of displaying and handling the problem menu.</returns>
        private async Task DemoProblemAsync(string selectedProblem)
        {
            var SolvedProblems = await GetProblemsList(0);

            visualizer.Qprint($"You selected: {selectedProblem}", "Yellow");
            var (isSolved, meta) = status.ProblemsAndStatus[selectedProblem];
            if (!isSolved)
            {
                visualizer.Qprint("This problem is not solved yet.", "Red");
                var optionsNumsDem = menuHelperMethods.printMenuOptions(new List<string> { "1. Go Back" });

                visualizer.QprintOnLine("\nSelect an option: ", "White");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();

                if (!menuHelperMethods.isValidInput(input, optionsNumsDem))
                {
                    CMW.WriteErrorMessage("Invalid input. Please try again.");
                    await DemoProblemAsync(selectedProblem);
                }
                if (input == "1")
                {
                    if (SolvedProblems.Contains(selectedProblem))
                    {
                        await ShowSolvedProblemsAsync();
                    }
                    await ShowSolvingProblemsAsync();
                }
            }
            else
            {
                var optionsNumsDem = menuHelperMethods.printMenuOptions(new List<string> { "1. Demonstrate", "2. Go Back" });

                visualizer.QprintOnLine("\nSelect an option: ", "White");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();

                if (!menuHelperMethods.isValidInput(input, optionsNumsDem))
                {
                    CMW.WriteErrorMessage("Invalid input. Please try again.");
                    await DemoProblemAsync(selectedProblem);
                }
                switch (input)
                {
                    case "1":
                        //implement the logic to demonstrate the problem.
                        visualizer.Qprint($"Demonstrating {selectedProblem}...", "Green");
                        //call a method that runs the solution for this problem.

                        var userInputs = new string[meta.ParameterPrompts.Length];
                        for (int i = 0; i < meta.ParameterPrompts.Length; i++)
                        {
                            visualizer.QprintOnLine(meta.ParameterPrompts[i], "White");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            userInputs[i] = Console.ReadLine();
                            visualizer.BreakLine();
                            Console.ResetColor();
                        }

                        //Parsing inputs
                        try
                        {
                            visualizer.Qprint("Parsing inputs...", "Yellow");
                            var parameters = meta.ParseInputs(userInputs);
                            visualizer.Qprint("Invoking delegate...", "Yellow");
                            var result = meta.ProblemDelegate.DynamicInvoke(parameters);
                            visualizer.Qprint("Delegate invoked.", "Yellow");

                            //Display result.
                            if (result is IEnumerable<string> stringList)
                            {
                                visualizer.Qprint("Result:", "Green");
                                foreach (var line in stringList)
                                    visualizer.Qprint(line, "Yellow");
                            }
                            else if (result is IEnumerable<IEnumerable<string>> listOfLists)
                            {
                                visualizer.Qprint("Result:", "Green");
                                foreach (var list in listOfLists)
                                    visualizer.Qprint(string.Join(", ", list), "Yellow");
                            }
                            else
                            {
                                visualizer.Qprint($"Result: {result.ToString()}", "Yellow");
                            }
                            visualizer.Qprint("Press any key to go back to the menu.", "White");
                            Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            CMW.WriteErrorMessage($"An error occurred while displaying the game menu. Error Message: {e.Message}\nInner:{e.InnerException.Message} ");

                            await DemoProblemAsync(selectedProblem);
                        }

                        //await RunDemoAsync(selectedProblem);
                        break;
                    case "2":
                        if (SolvedProblems.Contains(selectedProblem))
                        {
                            await ShowSolvedProblemsAsync();
                        }
                        await ShowSolvingProblemsAsync();
                        break;
                    default:
                        CMW.WriteErrorMessage("Invalid input. Please try again.");
                        await DemoProblemAsync(selectedProblem);
                        break;
                }
            }
        }

        /// <summary>
        /// Displays a menu of solved LeetCode problems and allows the user to select and view details for a specific
        /// problem asynchronously.
        /// </summary>
        /// <remarks>The method presents only problems marked as solved. If the user selects a problem,
        /// its details are shown; if the user chooses to go back, the main problems menu is displayed. Input validation
        /// is performed, and the menu is re-displayed on invalid input or error.</remarks>
        /// <returns>A task that represents the asynchronous operation of displaying and handling the solved problems menu.</returns>
        private async Task ShowSolvedProblemsAsync()
        {
            try
            {
                //Printing Menu
                visualizer.Qprint("Leetcode Problems.", "Green", "White");
                //Leetcode Problems Menu
                var problemKeys = await GetProblemsList(0);
                var options = problemKeys.Select((key, index) => $"{index + 1}. {key}").ToList();
                options.Add($"{options.Count + 1}. Go Back");
                var optionsNums = menuHelperMethods.printMenuOptions(options);

                visualizer.QprintOnLine("\nSelect an option: ", "White");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();
                //Checking Validation
                if (!menuHelperMethods.isValidInput(input, optionsNums))
                {
                    CMW.WriteErrorMessage("Invalid input. Please try again.");
                    await ShowSolvedProblemsAsync();
                }

                int selectedIndex = int.Parse(input) - 1;

                if (selectedIndex == problemKeys.Count)
                {
                    await LeetCodeProblemsMenuAsync();
                }

                string selectedProblem = problemKeys[selectedIndex];

                await DemoProblemAsync(selectedProblem);
            }
            catch (Exception e)
            {
                CMW.WriteErrorMessage($"An error occurred while displaying the game menu. Error Message: {e.Message}\nInner:{e.InnerException.Message} ");
                await ShowSolvedProblemsAsync();
            }
        }

        private async Task ShowSolvingProblemsAsync()
        {
            try
            {
                //Printing Menu
                visualizer.Qprint("Leetcode Problems.", "Green", "White");
                //Leetcode Problems Menu
                var problemKeys = await GetProblemsList(-1);
                var options = problemKeys.Select((key, index) => $"{index + 1}. {key}").ToList();
                options.Add($"{options.Count + 1}. Go Back");
                var optionsNums = menuHelperMethods.printMenuOptions(options);

                visualizer.QprintOnLine("\nSelect an option: ", "White");
                Console.ForegroundColor = ConsoleColor.Blue;
                var input = Console.ReadLine();
                visualizer.BreakLine();
                Console.ResetColor();

                if (!menuHelperMethods.isValidInput(input, optionsNums))
                {
                    CMW.WriteErrorMessage("Invalid input. Please try again.");
                    await ShowSolvedProblemsAsync();
                }

                int selectedIndex = int.Parse(input) - 1;

                if (selectedIndex == problemKeys.Count)
                {
                    await LeetCodeProblemsMenuAsync();
                }

                string selectedProblem = problemKeys[selectedIndex];

                await DemoProblemAsync(selectedProblem);
            }
            catch (Exception e)
            {
                CMW.WriteErrorMessage($"An error occurred while displaying the game menu. Error Message: {e.Message}\nInner:{e.InnerException.Message} ");
                await ShowSolvedProblemsAsync();
            }
            
        }
        /// <summary>
        /// Retrieves a list of problem identifiers filtered by their solved status.
        /// </summary>
        /// <param name="SolvedOrSolving">A value indicating which problems to include. If greater than or equal to 0, only solved problems are
        /// returned; otherwise, only unsolved problems are returned.</param>
        /// <returns>A list of strings containing the identifiers of the problems that match the specified solved status. The
        /// list is empty if no problems match the criteria.</returns>
        private async Task<List<string>> GetProblemsList(short SolvedOrSolving)
        {
            if (SolvedOrSolving >= 0) 
            {
                return status.ProblemsAndStatus.Keys.Where(key => status.ProblemsAndStatus[key].Item1 == true).ToList();
            }
                return status.ProblemsAndStatus.Keys.Where(key => status.ProblemsAndStatus[key].Item1 == false).ToList();
        }
    }
}
