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
        Dictionary<string, (bool,Delegate)> ProblemsAndStatus = new Dictionary<string, (bool, Delegate)>
        {
            { "N-Queens", (false, (Func<int, IList<IList<string>>>)((n) => new HardProblems().SolveNQueens(n))) },

            { "FullJustify", (true, (Func<string[], int, IList<string>>)((words, maxWidth) => new HardString().FullJustify(words,maxWidth))) },

            { "findMedianSortedArrays", (true, (Func<int[],int[],double>)((nums1,nums2) => new HardArray().findMedianSortedArrays(nums1,nums2))) },
        };
    }
}
