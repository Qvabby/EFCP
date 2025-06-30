using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Problems.Arrays
{
    public class HardArray
    {
        public double findMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //            Example 1:

            //Input: nums1 = [1, 3], nums2 = [2]
            //Output: 2.00000
            //Explanation: merged array = [1, 2, 3] and median is 2.
            //Example 2:

            //Input: nums1 = [1, 2], nums2 = [3, 4]
            //Output: 2.50000
            //Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.
            Console.WriteLine("Inside findMedianSortedArrays");
            int[] merged = new int[nums1.Length + nums2.Length];
            bool firstMore = nums1.Length > nums2.Length;
            for (int i = 0; i < merged.Length; i++)
            {
                if (nums1.Length == 0)
                {
                    merged[i] = nums2[i];
                    continue;
                }else if (nums2.Length == 0)
                {
                    merged[i] = nums1[i];
                    continue;
                }
                if (firstMore)
                {
                    
                    if (i < nums1.Length)
                    {
                        merged[i] = nums1[i];
                    }
                    else
                    {
                        merged[i] = nums2[i - nums1.Length];
                    }
                }
                else
                {
                    if (i < nums2.Length)
                    {
                        merged[i] = nums2[i];
                    }
                    else
                    {
                        merged[i] = nums1[i - nums2.Length];
                    }
                }
            }
            Array.Sort(merged);
            if (merged.Length % 2 == 0)
            {
                return (merged[merged.Length / 2] + merged[merged.Length / 2 - 1]) / 2.0;
            }
            else
            {
                return merged[merged.Length / 2];
            }

        }

    }
}
