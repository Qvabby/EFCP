using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Problems
{
    public class HardProblems
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            // if q is on first then third and fourth is available
            // if q is on second then only fourth is available
            // if q is on third then first is available
            // if q is on fourth first and second is available

            if (n == 1)
            {
                return new List<IList<string>> { new List<string> { "Q" } };
            }


            //if (n == 2)
            //{
            //    return new List<IList<string>> { };
            //}
            //if (n == 3)
            //{
            //    return new List<IList<string>> { };
            //}



            //Outputs.
            // "Q..." index 0 = index 2,3 
            // ".Q.." index 1 = index 3
            // "..Q." index 2 = index 0
            // "...Q" index 3 = index 0,1
            bool isPossible = true;
            StringBuilder sb = new StringBuilder();
            sb.Append("....");
            List<IList<string>> boards = new List<IList<string>>();
            for (int i = 0; i < 2; i++)
            {
                IList<string> boardWith1 = new List<string>();
                if (i>0)
                {
                    boardWith1.Clear();
                }
                
                for (int t = 0; t < n; t++)
                {
                    if (i == 0)
                    {
                        if (t == 0)
                        {
                            sb.Replace('.', 'Q', 1, 1);
                            boardWith1.Add(sb.ToString());
                            sb.Clear();
                            sb.Append("....");
                            continue;
                        }
                        if (boardWith1.Count >= 1)
                        {
                            string rowbefore = boardWith1[t - 1];
                            int indexOfQ = rowbefore.IndexOf('Q');
                            if (indexOfQ == 1) sb.Replace('.', 'Q', 3, 1);
                            if (indexOfQ == 3) sb.Replace('.', 'Q', 0, 1);
                            if (indexOfQ == 0) sb.Replace('.', 'Q', 2, 1);
                            
                        }

                        boardWith1.Add(sb.ToString());
                        sb.Clear();
                        sb.Append("....");

                        if (t == n - 1)
                        {
                            boards.Add(boardWith1);
                        }
                        continue;
                    }
                    
                    if (i == 1)
                    {
                        if (t == 0)
                        {
                            sb.Replace('.', 'Q', 2, 1);
                            boardWith1.Add(sb.ToString());
                            sb.Clear();
                            sb.Append("....");
                            continue;
                        }
                        if (boardWith1.Count >= 1)
                        {
                            string rowbefore = boardWith1[t - 1];
                            int indexOfQ = rowbefore.IndexOf('Q');
                            if (indexOfQ == 2) sb.Replace('.', 'Q', 0, 1);
                            if (indexOfQ == 3) sb.Replace('.', 'Q', 1, 1);
                            if (indexOfQ == 0) sb.Replace('.', 'Q', 3, 1);

                        }
                        boardWith1.Add(sb.ToString());
                        sb.Clear();
                        sb.Append("....");

                        if (t == n - 1)
                        {
                            boards.Add(boardWith1);
                        }
                        continue;
                    }


                }
            }
            //foreach (var board in boards)
            //{
            //    foreach (var row in board)
            //    {
            //        Console.WriteLine(row);
            //    }
            //}
            return boards;
        }
    }
}
