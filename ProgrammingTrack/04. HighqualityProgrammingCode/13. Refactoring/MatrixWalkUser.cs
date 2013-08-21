namespace GameFifteen
{
    using System;
    using System.Linq;

    public class MatrixWalkUser
    {
        public static void Main(string[] args)
        {
            int[,] matrix = RotatingWalkInMatrix.GenerateMatrix(3);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
