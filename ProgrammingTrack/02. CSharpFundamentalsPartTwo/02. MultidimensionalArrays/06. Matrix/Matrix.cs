// * Write a class Matrix, to holds a matrix of integers. Overload the 
// operators for adding, subtracting and multiplying of matrices,
// indexer for accessing the matrix content and ToString().

using System;
using System.Text;


class Matrix
{
    static void Main()
    {

        Console.WriteLine("matrix 1:");
        MatrixOfInts mat1 = MatrixOfInts.ReadMatrix(3, 3);
        Console.WriteLine("matrix 2:");
        MatrixOfInts mat2 = MatrixOfInts.ReadMatrix(3, 3);
        Console.WriteLine("mat1+mat2:");
        Console.WriteLine((mat1+mat2).ToString());
        Console.WriteLine("mat1-mat2:");
        Console.WriteLine((mat1 - mat2).ToString());
        Console.WriteLine("mat1*mat2:");
        Console.WriteLine((mat1 * mat2).ToString());
        //MatrixOfInts.Display(mat3);
    }
}
class MatrixOfInts
{
    int row;
    int col;
    int[,] matrix;

    public MatrixOfInts(int row, int col)
    {
        this.row = row;
        this.col = col;
        this.matrix = new int[row, col];
    }
    public MatrixOfInts(int[,] matrix)
    {
        this.row = matrix.GetLength(0);
        this.col = matrix.GetLength(1);
        this.matrix = matrix;
    }
    static private MatrixOfInts AddMatrix(MatrixOfInts mat1, MatrixOfInts mat2)
    {
        if (mat1.row != mat2.row || mat1.col != mat2.col)
        {
            throw new ArgumentOutOfRangeException("Matrices must have same dimentions!");
        }
        MatrixOfInts destinationMatrix = new MatrixOfInts(mat1.row, mat1.col);
        for (int row = 0; row < mat1.row; row++)
        {
            for (int col = 0; col < mat1.col; col++)
            {
                destinationMatrix[row, col] = mat1[row, col] + mat2[row, col];
            }
        }
        return destinationMatrix;
    }

    static private MatrixOfInts SubMatrix(MatrixOfInts mat1, MatrixOfInts mat2)
    {
        if (mat1.row != mat2.row || mat1.col!= mat2.col)
        {
            throw new ArgumentOutOfRangeException("Matrices must have same dimentions!");
        }
        MatrixOfInts destinationMatrix = new MatrixOfInts(mat1.row, mat1.col);
        for (int row = 0; row < mat1.row; row++)
        {
            for (int col = 0; col < mat1.col; col++)
            {
                destinationMatrix[row, col] = mat1[row, col] - mat2[row, col];
            }
        }
        return destinationMatrix;
    }
    static private MatrixOfInts MulMatrix(MatrixOfInts mat1, MatrixOfInts mat2)
    {
        if (mat1.row != mat2.col)
        {
            throw new ArgumentOutOfRangeException("Invalid Matrix Dementios. Rows of th first matrix must be equal to the cols of the second matrix!");
        }
        MatrixOfInts destinationMatrix = new MatrixOfInts(mat1.row, mat2.col);

        for (int row = 0; row < destinationMatrix.row; row++)
        {
            int internalCol = 0;
            for (int col = 0; col < destinationMatrix.col; col++)
            {
                int sum = 0;

                for (int i = 0; i < mat1.col; i++)
                {
                    sum += mat1[row, i] * mat2[i, internalCol];

                }
                destinationMatrix[row, col] = sum;
                internalCol++;
            }
        }
        return destinationMatrix;
    }

    public static void Display(MatrixOfInts mat1)
    {
        MatrixOfInts destinationMatrix = new MatrixOfInts(mat1.row, mat1.col);
        for (int row = 0; row < mat1.row; row++)
        {
            for (int col = 0; col < mat1.col; col++)
            {
                Console.Write("{0,4}", mat1[row, col]);
            }
            Console.WriteLine();
        }
    }

    public static MatrixOfInts ReadMatrix(int row, int col)
    {
        int[,] matrix = new int[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("Matrix[{0},{1}] = ", i, j);
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return new MatrixOfInts(matrix);
    }
    static public MatrixOfInts operator + (MatrixOfInts mat1, MatrixOfInts mat2)
    {
        return MatrixOfInts.AddMatrix(mat1, mat2);
    }
    static public MatrixOfInts operator - (MatrixOfInts mat1, MatrixOfInts mat2)
    {
        return MatrixOfInts.SubMatrix(mat1, mat2);
    }
    static public MatrixOfInts operator *(MatrixOfInts mat1, MatrixOfInts mat2)
    {
        return MatrixOfInts.MulMatrix(mat1, mat2);
    }
    public override string ToString()
    {
        StringBuilder stringRepresentation = new StringBuilder();
        for (int row = 0; row < this.row; row++)
        {
            for (int col = 0; col < this.col; col++)
            {
                stringRepresentation.Append( string.Format("{0,4}", this[row, col]));
            }
            stringRepresentation.Append("\r\n");
        }
        return stringRepresentation.ToString();
    }

    public int this[int row, int col]
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

}