using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > target) continue;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] > target) continue;
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[]{i,j};
                    }
                }
            }
            return null;
        }
    }
}
