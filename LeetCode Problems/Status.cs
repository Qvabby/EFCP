using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode_Problems;
using LeetCode_Problems.Arrays;
using LeetCode_Problems.Strings;
namespace LeetCode_Problems
{
    public class Status
    {
        HardProblems HardProblems = new HardProblems();
        public Dictionary<string, (bool, ProblemMeta)> ProblemsAndStatus = new()
        {
            {"N-Queens",
                (false, new ProblemMeta
                {
                    ProblemDelegate = (Func<int, IList<IList<string>>>)((n) => new HardProblems().SolveNQueens(n)),
                    ParameterPrompts = new[] { "Enter n (board size): " },
                    ParseInputs = inputs => new object[] { int.Parse(inputs[0]) }
                })
            },

            {"FullJustify",
                (true, new ProblemMeta
                {
                    ProblemDelegate = (Func<string[], int, IList<string>>)((words, maxWidth) => new HardString().FullJustify(words, maxWidth)),
                    ParameterPrompts = new[] { "Enter words (comma-separated): ", "Enter max width: " },
                    ParseInputs = inputs => new object[] {
                        inputs[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).ToArray(),
                        int.Parse(inputs[1])
                    }
                })
            },

            {"findMedianSortedArrays",
                (true, new ProblemMeta
                {
                    ProblemDelegate = (Func<int[], int[], double>)((nums1, nums2) => new HardArray().findMedianSortedArrays(nums1, nums2)),
                    ParameterPrompts = new[] { "Enter nums1 (comma separated): ", "Enter nums2 (comma separated): " },
                    ParseInputs = inputs => new object[]
                    {
                        inputs[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s.Trim())).ToArray(),
                        inputs[1].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s.Trim())).ToArray()
                    }
                })
            }
        };
    }
}
