using System;
using Permutation;
using TheNumberofInverseOrder;

namespace MatrixSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入宁的矩阵：");
            int[,] matrix = GetMatrix();
            int matrixLength = (int)Math.Sqrt(matrix.Length);
            int[] standardPermutation = new int[matrixLength];
            for (int i = 0; i < matrixLength; i++)
            {
                standardPermutation[i] = i+1;
            }
            Permutation.Permutation.getPerm(standardPermutation);
            var permutationList = Permutation.Permutation.PermList;

            int solution = 0;
            for(int i = 0;i<permutationList.Count;i++)
            {
                int elementsProduct = 1;
                for (int j = 0; j < matrixLength; j++)
                {
                    elementsProduct *= matrix[j, permutationList[i][j]-1];
                }

                int inverseOrder = InverseOrder.FromStart(permutationList[i]);
                if (inverseOrder%2==0)
                {
                    solution += elementsProduct;
                }
                else
                {
                    solution -= elementsProduct;
                }
            }

            Console.Write("该矩阵解为：");
            Console.WriteLine(solution);
            Console.ReadLine();
        }

        static int[,] GetMatrix()
        {
            string firstRow = Console.ReadLine();
            int matrixLength = firstRow.Split(" ").Length;
            int[,] matrix = new int[matrixLength,matrixLength];
            string[] firstRowElement = firstRow.Split(" ");
            for (int i = 0; i < matrixLength; i++)
            {
                matrix[0, i] = int.Parse(firstRowElement[i]);
            }

            for (int i = 1; i < matrixLength; i++)
            {
                string matrixRow = Console.ReadLine();
                string[] matrixElement = matrixRow.Split(" ");
                for (int j = 0; j < matrixLength; j++)
                {
                    matrix[i, j] = int.Parse(matrixElement[j]);
                }
            }

            return matrix;
        }
    }
}