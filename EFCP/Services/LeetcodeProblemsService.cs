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

        private async Task DemoProblemAsync(string selectedProblem)
        {
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
                    await ShowSolvedProblemsAsync();
                }
            }
            else
            {
                var optionsNumsDem = menuHelperMethods.printMenuOptions(new List<string> { "1. Demonstrate, 2. Go Back" });

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
                        await ShowSolvedProblemsAsync();
                        break;
                    default:
                        CMW.WriteErrorMessage("Invalid input. Please try again.");
                        await DemoProblemAsync(selectedProblem);
                        break;
                }
            }
        }

        private async Task ShowSolvedProblemsAsync()
        {
            try
            {
                //Printing Menu
                visualizer.Qprint("Leetcode Problems.", "Green", "White");
                //Leetcode Problems Menu
                var problemKeys = status.ProblemsAndStatus.Keys.ToList();
                var options = status.ProblemsAndStatus.Keys.Select((key, index) => $"{index + 1}. {key}").ToList();
                options.Add("4. Go Back");
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
    }
}
