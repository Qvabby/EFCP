using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Problems
{
    public class ProblemMeta
    {
        public Delegate ProblemDelegate { get; set; }
        public string[] ParameterPrompts { get; set; }
        public Func<string[], object[]> ParseInputs { get; set; }
    }
}
