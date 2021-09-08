using System;
using System.Collections.Generic;

namespace TheNumberofInverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("默认的标准次序为1 2 3 4 ... n");
            Console.WriteLine("请输入你的排列,以计算其逆序数:");
            var numStrings = Console.ReadLine().Split(" ");
            List<int> numInts = new List<int>();
            foreach (var numString in numStrings)
            {
                numInts.Add(int.Parse(numString));
            }

            Console.WriteLine("其逆序数为:" + Calc.FromStart(numInts));
        }
    }

    static class Calc
    {
        public static int FromStart(List<int> nums)
        {
            int[] inverseOrderNums = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i+1; j < nums.Count; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        inverseOrderNums[i]++;
                    }
                }
            }

            var totalInverseOrderNums = 0;
            foreach (var inverseOrderNum in inverseOrderNums)
            {
                totalInverseOrderNums += inverseOrderNum;
            }

            return totalInverseOrderNums;
        }
        
        public static int FromEnd(List<int> nums)
        {
            int[] inverseOrderNums = new int[nums.Count];
            for (int i = nums.Count-1; i > -1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        inverseOrderNums[i]++;
                    }
                }
            }
            
            var totalInverseOrderNums = 0;
            foreach (var inverseOrderNum in inverseOrderNums)
            {
                totalInverseOrderNums += inverseOrderNum;
            }

            return totalInverseOrderNums;
        }
    }
}