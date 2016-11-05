using Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Matrix
{
    public class MyMatrix
    {
        private double[,] matrix;
        public MyMatrix(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public MyMatrix(MyMatrix matrix)
        {
            CreateMatrixFromString(matrix.ToString());
        }
        public MyMatrix(string matrixInLine)
        {
            CreateMatrixFromString(matrixInLine);
        }

        public MyMatrix(params string[] rows)
        {
            for (int i = 0; i < rows.Count() - 1; i++)
                if (rows[i].Length != rows[i + 1].Length)
                    throw new Exception("Can not create Matrix");

            matrix = new double[rows[0].Split(' ').Length, rows.Count()];
            for (int i = 0; i < rows.Count(); i++)
            {
                var numbers = rows[i].Split(' ');
                for (int j = 0; j < numbers.Length; j++)
                    if (!double.TryParse(numbers[j], out matrix[j, i]))
                        throw new ArgumentException();
            }            
        }

        public MyMatrix(double[][] array)
        {
            for (int i = 0; i < array.Count() - 1; i++)
                if (array[i].Length != array[i + 1].Length)
                    throw new ArgumentException("Can not create Matrix");
            matrix = new double[array[0].Length, array.Count()];
            for (int i = 0; i < array.Count(); i++)
                for (int j = 0; j < array[i].Length; j++)
                    matrix[j, i] = array[i][j];
            
        }
        private void CreateMatrixFromString(string matrixInLine)
        {
            var rows = matrixInLine.Trim().Split('\n');
            for (int i = 0; i < rows.Count(); i++)
                rows[i] = rows[i].Trim();
            for(int i = 0; i < rows.Count() - 1; i++)                        
                if (rows[i].Length != rows[i + 1].Length)
                    throw new Exception("Can not create Matrix");  

            matrix = new double[rows[0].Split(' ').Count(), rows.Count()];  
            for (int i = 0; i < rows.Count(); i++)
            {
                var numbers = rows[i].Split(' ');
                for (int j = 0; j < numbers.Length; j++)
                    if (!double.TryParse(numbers[j], out matrix[j, i]))
                        throw new ArgumentException();
            }
            
        }

        public int Height{ get { return matrix.GetLength(0); } }
        public int Width { get { return matrix.GetLength(1); } }
        public int getHeight()
        {
            return matrix.GetLength(0);
        }
        public int getWidth()
        {
            return matrix.GetLength(1);
        }
        
        public double getElement(int x, int y)
        {            
            return (matrix[x, y]);
        }
        public void setElement(int x, int y, double value)
        {
            matrix[x, y] = value;
        }

        public override string ToString()
        {
            string matrixInRaw = "";
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    matrixInRaw += $"{matrix[j, i]} ";
                matrixInRaw += "\n";
            }
            return matrixInRaw;
        }
        private double[,] GetTransponedArray(MyMatrix matrix)
        {
            var transponedMatrix = new double[matrix.Width, matrix.Height];
            for (int i = 0; i < matrix.Height; i++)
                for (int j = 0; j < matrix.Width; j++)
                    transponedMatrix[i, j] = matrix.getElement(j, i);
            return transponedMatrix;
        }
        public MyMatrix GetTransponedCopy(MyMatrix matrix)
        {
            return new MyMatrix(GetTransponedArray(matrix));
        }

    }
}

public static class MyMatrixExtentions
{
    public static MyMatrix TransponeMe(this MyMatrix matrix)
    {
        matrix = matrix.GetTransponedCopy(matrix);
        return matrix;     
    }
}

