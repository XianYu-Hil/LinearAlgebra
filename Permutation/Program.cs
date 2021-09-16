using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Permutation.getPerm(new[] { 1,3,5});
            foreach (var permList in Permutation.PermList)
            {
                foreach (var i in permList)
                {
                    Console.Write(i+" ");
                }
                Console.WriteLine();
            }
        }
    }

    public static class Permutation
    {
        static void swap(ref int a ,ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

        public static List<List<int>> PermList = new();
        //全排列递归算法
        public static void getPerm(int[] list, int k=0)
        {
            // int PermNum = Factorial(list.Length);

            //list 数组存放排列的数，K表示层 代表第几个数，m表示数组的长度
            
            if(k==list.Length-1)
            {
                //K==m 表示到达最后一个数，不能再交换，最终的排列的数需要输出；
                List<int> permList = list.ToList();
                PermList.Add(permList);
            } 
            else{
                for(int i=k;i<list.Length;i++)
                {
                    swap(ref list[i],ref list[k]);
                    getPerm(list,k+1);
                    swap(ref list[i] , ref list[k]);
                }
            }
        }
    }
}
