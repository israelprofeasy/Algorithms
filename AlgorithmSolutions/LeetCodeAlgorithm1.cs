using System;
using System.Diagnostics.Metrics;

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

        public int[] SortedSquares(int[] nums)
        {
            /*Input: nums = [-4,-1,0,3,10]
            Output: [0,1,9,16,100]
                Explanation: After squaring, the array becomes[16, 1, 0, 9, 100].
                After sorting, it becomes[0, 1, 9, 16, 100].
                    */

            if (nums.Length % 2 != 0)
            {
                for (int i = 0; i < nums.Length / 2; i++)
                {
                    swap(nums, i, nums.Length - i - 1);
                }
                nums[(nums.Length) / 2] = (int)Math.Pow(nums[(nums.Length) / 2], 2);
            }
            else
            {
                for (int i = 0; i < nums.Length / 2; i++)
                {
                    swap(nums, i, nums.Length - i - 1);
                }
            }

            Array.Sort(nums);
            return nums;
        }
        private static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = (int)Math.Pow(array[j], 2);
            array[j] = (int)Math.Pow(temp, 2);

        }

        public void Rotate(int[] nums, int k)
        {

                //Input: nums = [1,2,3,4,5,6,7], k = 3
               // Output: [5,6,7,1,2,3,4]
            //Explanation:
             //           rotate 1 steps to the right: [7,1,2,3,4,5,6]
            //rotate 2 steps to the right: [6,7,1,2,3,4,5]
            //rotate 3 steps to the right: [5,6,7,1,2,3,4]

            while (k > 0)
            {
                var temp = nums[^1];
                Array.Copy(nums, 0, nums, 1, nums.Length - 1);
                nums[0] = temp;
                k--;
            }
        }
    }
}

