using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Version("3", "512a")]
    public class Matrix<T>
    {
        private T[,] matrix;
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Matrix(int aRows, int aCols)
        {
            this.Rows = aRows;
            this.Cols = aCols;
            this.matrix = new T[Rows, Cols];
        }
        // task 9 - implement Indexer
        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }

        }
        // task 10 - 
        // Generic type T MUST HAVE operators +, - overriden!
        public static Matrix<T> operator +(Matrix<T> mat1, Matrix<T> mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Cols != mat2.Cols)
            {
                throw new ArgumentOutOfRangeException("Inner matrix dimensions must agree!");
            }
            Matrix<T> result = new Matrix<T>(mat1.Rows, mat1.Cols);
            for (int rows = 0; rows < mat1.Rows; rows++)
            {
                for (int cols = 0; cols < mat1.Cols; cols++)
                {
                    result[rows, cols] = (dynamic)mat1[rows, cols] + (dynamic)mat2[rows, cols];
                }
            }
            return result;
        }
        public static Matrix<T> operator -(Matrix<T> mat1, Matrix<T> mat2)
        {
            if (mat1.Rows != mat2.Rows || mat1.Cols != mat2.Cols)
            {
                throw new ArgumentOutOfRangeException("Inner matrix dimensions must agree!");
            }
            Matrix<T> result = new Matrix<T>(mat1.Rows, mat1.Cols);
            for (int rows = 0; rows < mat1.Rows; rows++)
            {
                for (int cols = 0; cols < mat1.Cols; cols++)
                {
                    result[rows, cols] = (dynamic)mat1[rows, cols] - (dynamic)mat2[rows, cols];
                }
            }
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> mat1, Matrix<T> mat2)
        {
            if (mat1.Cols != mat2.Rows)
            {
                throw new ArgumentOutOfRangeException("Inner matrix dimensions must agree!");
            }
            Matrix<T> result = new Matrix<T>(mat1.Rows, mat2.Cols);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Rows; j++)
                {
                    dynamic newElement = default(T);
                    for (int k = 0; k < mat2.Rows; k++)
                    {
                        newElement += ((dynamic)mat1[i, k] * (dynamic)mat2[k, j]);
                    }
                    result[i, j] = newElement;
                }
            }
            return result;
        }
        public static bool operator true(Matrix<T> mat)
        {
            for (int i = 0; i < mat.Rows ; i++)
            {
                for (int j = 0; j < mat.Cols; j++)
                {
                    if ((dynamic)mat[i,j] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator false(Matrix<T> mat)
        {
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Cols; j++)
                {
                    if ((dynamic)mat[i, j] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder textRepresentation = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    textRepresentation.Append(String.Format("{0,5}", this.matrix[row, col]));
                }
                textRepresentation.Append("\r\n");
            }
            return textRepresentation.ToString();
        }
    }
}
