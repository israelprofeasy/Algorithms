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
        public int Search2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (IsBadVersion(mid))
                {
                    // The current version is bad, so move to the left half
                    right = mid;
                }
                else
                {
                    // The current version is good, so move to the right half
                    left = mid + 1;
                }
            }
            return left;


        }

        private bool IsBadVersion(int mid)
        {
            throw new NotImplementedException("This was not Implemented");

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

        public int SearchInsert2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] < target)
                    left = mid + 1;

                else
                    right = mid - 1;
            }
            return left;
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

        public void MoveZeroes(int[] nums)
        {
        //Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        //Note that you must do this in-place without making a copy of the array.


        //Input: nums = [0,1,0,3,12]
        //Output: [1,3,12,0,0]
            //
            ///


            if (nums.Length == 0 || !nums.Contains(0))
                return;

            var left = 0;
            var right = 0;
            var length = nums.Length;
            while (right < length)
            {
                if (nums[left] == 0 && nums[right] == 0)
                    right++;
                else
                {
                    nums[left] = nums[right];

                    if (right != left)
                    {
                        nums[right] = 0;
                        if ((right - left) > 1)
                        {
                            left++;
                            right++;
                        }
                        else
                        {
                            left = right;
                            right++;
                        }
                    }
                    else
                    {
                        left++;
                        right++;
                    }

                }

            }


        }
        public int[] TwoSum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;
            while (left < right)
            {
                if (numbers[left] + numbers[right] == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
                else if (numbers[left] + numbers[right] > target)
                    right--;
                else
                    left++;

            }
            return new int[] { };
        }

        public int[] TwoSum2(int[] numbers, int target)
        {

            /*
             * Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 < numbers.length.

Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

The tests are generated such that there is exactly one solution. You may not use the same element twice.

Your solution must use only constant extra space.
             * 
             * 
             */
            var left = 0;
            var right = 1;
            while (left < numbers.Length && right < numbers.Length)
            {
                if (numbers[left] + numbers[right] == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
                else if (numbers[left] + numbers[right] < target)
                {
                    right++;
                    left++;
                }

                else
                    left--;

            }
            return new int[] { };
        }

        public void ReverseString(char[] s)
        {
            //Write a function that reverses a string. The input string is given as an array of characters s.

            //You must do this by modifying the input array in-place with O(1) extra memory.
        //Input: s = ["h","e","l","l","o"]
        // Output: ["o","l","l","e","h"]
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
            {
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }
    }
}

