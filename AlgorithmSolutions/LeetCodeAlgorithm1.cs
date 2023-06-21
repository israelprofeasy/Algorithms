using System;
namespace AlgorithmSolutions
{
	public class LeetCodeAlgorithm1
	{
        public int Search(int[] nums, int target)
        {
            /*Input: nums = [-1,0,3,5,9,12], target = 9
                Output: 4
                Explanation: 9 exists in nums and its index is 4
            */
            return Array.IndexOf(nums, target);
        }


        public int SearchInsert(int[] nums, int target)
        {
            //Input: nums = [1,3,5,6], target = 5
            //Output: 2
            var result = Array.IndexOf(nums, target);

            if (result == -1)
            {
                if (nums.Length == 1)
                    return nums[0] < target ? 1 : 0;
                if (nums[0] > target)
                    return 0;
                for (var i = 0; i < nums.Length - 1; i++)
                {

                    if (nums[^1] < target)
                    {
                        return nums.Length;
                    }
                    if (nums[i] < target && target < nums[i + 1])
                    {
                        return i + 1;
                    }

                    if (target < nums[^(1 + i)] && nums[^(2 + i)] < target)
                    {
                        return nums.Length - (1 + i);
                    }
                }
            }
            return result;
        }
    }
}

