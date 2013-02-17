using System;

class SpiralMatrix
{
    static void Main()
    {
        // the program writes the outer frame of a spiral matrix of given size, 
        // then the inner and so while there is an inner frame
        // works in the following way:
        // 1. calc. how many inner frames there are
        // 2. while there are inner frame - get their size and add them to the spiral matrix
        int N = int.Parse(Console.ReadLine()); // size of the spiral matrix
        int[,] spiralMatrix = new int[N, N];
        int direction = 0;              // 0 - down, 1 - right, 2 - up, 3 - left
        int rowInitial = 0;             // initial row for every frame in the spiral matrix 
        int colInitial = 0;             // initial col for every frame in the spiral matrix
        int row = rowInitial;           // current row 
        int col = colInitial;           // current col
        int counter = N - 2;              // counts how many frames there are in the spiral matrix (e.g. is N = 5, they there are 3 frames composing the spiral matrix)
        int psudoN = N;                 // Size of the current frame of the matrix
        int cornerChanger = 0;          // used for calulation the coords of the cornes in the frames of every sub-matrix
        int numberToWrite = 1;          // the value of the current element in the spiral matrix

        for (int i = 1; i < N; i++)
        {
            for (int inLine = 1; inLine <= psudoN * psudoN - Math.Pow(counter, 2); inLine++) // while (inLine <= the end element in the current frame)
            {
                spiralMatrix[row, col] = numberToWrite++;                   // increment the value of the current element in the spiral matrix

                if (inLine % (psudoN + cornerChanger) == 0)   // see if the direction need to be changed using the cornder values on the frames
                {
                    direction++;
                    cornerChanger += psudoN - 1;            // calculate the next corner value
                }
                switch (direction)          // based on direction change the current col or row in the current frame
                {
                    case 0:
                        row++;
                        break;
                    case 1:
                        col++;
                        break;
                    case 2:
                        row--;
                        break;
                    case 3:
                        col--;
                        break;
                    default:
                        break;
                }
            }
            // when the current frame is created, prepare for the next frame
            direction = 0;  // each frame start with right diretion e.g. 0
            psudoN -= 2;      // each frame is with 2 less rows and cols from the previous (e.g. the matrix is 5 by 5, the inner one would be 3 by 3)
            counter = psudoN - 2; // get how much more inner matrices there are to be created
            row = ++rowInitial;   // starting coords of the inner matrix
            col = ++colInitial;
            cornerChanger = 0;    // used to calc which number 
        }

        if (N % 2 != 0)  // if the the spiral matrix has uneven rows and col, set the value of the center element
        {
            spiralMatrix[N / 2, N / 2] = N * N;
        }
        for (int i = 0; i < N; i++) // display the created matrix 
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write("{0,5}", spiralMatrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}