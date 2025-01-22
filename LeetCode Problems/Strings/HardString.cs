using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Problems.Strings
{
    public class HardString
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                //first word automatically added.
                if (i == 0 && i != words.Length - 1) { result.Add(words[i]); continue; }

                if (i == 0 && i == words.Length - 1)
                {
                    result.Add(words[i]);
                    int spaceCount = maxWidth - result[result.Count - 1].Length;
                    string space = " ";
                    for (int x = 0; x < spaceCount; x++)
                    {
                        result[result.Count - 1] = result[result.Count - 1].Insert(result[result.Count - 1].Length, space);
                    }
                    break;
                }
                //checking if the previous word length + space + current word length <= maxWidth
                if (result[result.Count - 1].Length + 1 + words[i].Length <= maxWidth && result[result.Count - 1] != "")
                {
                    result[result.Count - 1] += " " + words[i];
                }
                else if (result[result.Count - 1] == "" && result[result.Count - 1].Length + 1 + words[i].Length <= maxWidth)
                {
                    result[result.Count - 1] += words[i];
                }
                else if (result[result.Count - 1] == "" && words[i].Length == maxWidth)
                {
                    result[result.Count - 1] += words[i];
                    continue;
                }

                else if (result[result.Count - 1].Length + 1 + words[i].Length >= maxWidth && i != words.Length)
                {
                    i--;
                    int spaceCount = maxWidth - result[result.Count - 1].Length;
                    string space = " ";
                    int spacesAmount = 0;

                    for (int x = 0; x < result[result.Count - 1].Length; x++)
                    {
                        if (result[result.Count - 1][x] == ' ')
                        {
                            spacesAmount++;
                        }
                    }
                    if (spacesAmount != 0 && spaceCount % spacesAmount != 0)
                    {
                        //more space on left.
                        for (int l = 0; l < result[result.Count - 1].Length; l++)
                        {
                            if (spaceCount == 0) { break; }
                            if (result[result.Count - 1][l] == ' ')
                            {
                                result[result.Count - 1] = result[result.Count - 1].Insert(l, space);
                                spaceCount--;
                                l++;
                            }
                            if (l == result[result.Count - 1].Length - 1 && spaceCount != 0)
                            {
                                l = 0;
                            }
                        }
                    }
                    else if (spacesAmount == 0)
                    {
                        for (int x = 0; x < spaceCount; x++)
                        {
                            result[result.Count - 1] = result[result.Count - 1].Insert(result[result.Count - 1].Length, space);
                        }
                    }
                    else
                    {
                        int skipped = 0;
                        int FirstSpaceIndex = 0;
                        //space evenly.
                        for (int l = 0; l < result[result.Count - 1].Length; l++)
                        {
                            if (spaceCount == 0) { break; }
                            if (result[result.Count - 1][l] == ' ')
                            {
                                result[result.Count - 1] = result[result.Count - 1].Insert(l, space);
                                spaceCount--;
                                if (FirstSpaceIndex == 0) { FirstSpaceIndex = l; }
                                l++;

                                if (skipped > 0) { l += skipped; }

                            }
                            if (l == result[result.Count - 1].Length - 1 && spaceCount != 0)
                            {
                                l = FirstSpaceIndex;
                                skipped++;
                            }
                        }
                    }
                    result.Add("");
                }
                //if it is last line spaces must be on right (if needed).
                if (i == words.Length - 1)
                {
                    //juistify words on left and add spaces on right.
                    int spaceCount = maxWidth - result[result.Count - 1].Length;
                    string space = " ";
                    for (int x = 0; x < spaceCount; x++)
                    {
                        result[result.Count - 1] = result[result.Count - 1].Insert(result[result.Count - 1].Length, space);
                    }
                    break;
                }
                else if (result[result.Count - 1] == "" && words[i+1].Length == 1)
                {
                    i++;
                    result[result.Count - 1] = words[i];
                    if (i+1 == words.Length)
                    {
                        int spaceCount = maxWidth - result[result.Count - 1].Length;
                        string space = " ";
                        for (int x = 0; x < spaceCount; x++)
                        {
                            result[result.Count - 1] = result[result.Count - 1].Insert(result[result.Count - 1].Length, space);
                        }
                        break;
                    }


                }
            }

            return result;
        }

    }
}
