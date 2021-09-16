using System;
using System.Collections.Generic;
using System.Linq;

namespace TheNumberofInverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("默认的标准次序为1 2 3 4 ... n");
            Console.WriteLine("请输入你的排列,以计算其逆序数:");
            var numStrings = Console.ReadLine()?.Split(" ");
            List<int> numInts = numStrings.Select(int.Parse).ToList();

            Console.WriteLine("FromStart其逆序数为:" + InverseOrder.FromStart(numInts));
            Console.WriteLine("FromEnd其逆序数为:" + InverseOrder.FromEnd(numInts)); 
        }
    }

    static public class InverseOrder
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