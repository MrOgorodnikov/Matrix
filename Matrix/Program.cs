using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            var matrix = new MyMatrix(arr1);
            Console.WriteLine("double[,]");
            Console.Write(matrix);
            Console.WriteLine("From line");
            Console.WriteLine(matrix.ToString());
            Console.WriteLine("From other Matrix");
            Console.WriteLine(matrix);
            Console.WriteLine("From lines");
            var s1 = "1 1 1";
            var s2 = "0 0 0";
            var m1 = new MyMatrix(s1, s2);
            Console.Write(m1);
            Console.WriteLine("From double[][]");
            var arr2 = new double[][]
            {
                new double[] {3, 3, 3},
                new double[] {4, 4, 4},
            };
            var m2 = new MyMatrix(arr2);
            Console.WriteLine(m2);
            
            matrix.TransponeMe();
            Console.WriteLine("Transponed");
            Console.WriteLine(matrix);
            Console.ReadKey();
        }
    }
}
