namespace GameFifteen
{
    using System;

    public class RotatingWalkInMatrix
    {
        private const int NumberOfDirections = 8;

        public static int[,] GenerateMatrix(int matrixSize)
        {
            if (matrixSize < 0 || matrixSize > 100)
            {
                throw new ArgumentOutOfRangeException("Matrix size must be between 0 and 100!");
            }

            int[,] matrix = new int[matrixSize, matrixSize];
            int numberToWrite = 1;

            Position currentPosition = new Position() { XCoord = 0, YCoord = 0 };
            Direction currentDirection = new Direction { DirectionType = DirectionType.ButtomRight };

            bool validFreePositionFound = false;
            currentPosition = GetFirstFreeCell(matrix, out validFreePositionFound);

            while (validFreePositionFound)
            {
                DrawRotatingPathInMatrix(matrix, currentPosition, ref currentDirection, ref numberToWrite);
                numberToWrite++;

                currentDirection = new Direction() { DirectionType = DirectionType.ButtomRight };

                validFreePositionFound = false;
                currentPosition = GetFirstFreeCell(matrix, out validFreePositionFound);
            }

            return matrix;
        }

        private static Direction GetNextDirection(Direction currentDirection)
        {
            int currentDirectionAsInt = (int)currentDirection.DirectionType;

            currentDirectionAsInt += 1;

            if (currentDirectionAsInt >= 9)
            {
                currentDirectionAsInt = 1;
            }

            DirectionType nextDirectionType = (DirectionType)currentDirectionAsInt;
            Direction nextDirection = new Direction() { DirectionType = nextDirectionType };

            return nextDirection;
        }

        private static bool CheckForContinuation(int[,] arr, Position currentPosition)
        {
            for (int directionTypeAsInt = 1; directionTypeAsInt <= NumberOfDirections; directionTypeAsInt++)
            {
                DirectionType directionType = (DirectionType)directionTypeAsInt;
                Direction directionToTry = new Direction() { DirectionType = directionType };

                bool isValidDirection = IsNextDirectionValid(arr, currentPosition, directionToTry);
                if (isValidDirection)
                {
                    return true;
                }
            }

            return false;
        }

        private static Position GetFirstFreeCell(int[,] arr, out bool successfulMatch)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        successfulMatch = true;
                        return new Position() { XCoord = i, YCoord = j };
                    }
                }
            }

            successfulMatch = false;
            return new Position() { XCoord = 0, YCoord = 0 };
        }

        private static bool IsNextDirectionValid(int[,] matrix, Position currentPosition, Direction currentDirection)
        {
            bool validRowPosition = currentPosition.XCoord + currentDirection.XSpeed < matrix.GetLength(0)
                                    && currentPosition.XCoord + currentDirection.XSpeed >= 0;
            bool validColPosition = currentPosition.YCoord + currentDirection.YSpeed < matrix.GetLength(1)
                && currentPosition.YCoord + currentDirection.YSpeed >= 0;

            if (validRowPosition && validColPosition)
            {
                bool validNextCell = matrix[currentPosition.XCoord + currentDirection.XSpeed,
                                        currentPosition.YCoord + currentDirection.YSpeed] == 0;

                return validNextCell;
            }

            return false;
        }

        private static Direction GetNextValidDirection(int[,] matrix, Position currentPosition,
                                                       Direction currentDirection, ref bool isDirectionFound)
        {
            bool isThereValidPosition = CheckForContinuation(matrix, currentPosition);
            if (!isThereValidPosition)
            {
                isDirectionFound = false;
                return new Direction() { DirectionType = DirectionType.ButtomRight };
            }

            Direction nextValidDirection = currentDirection;
            while (!IsNextDirectionValid(matrix, currentPosition, nextValidDirection))
            {
                nextValidDirection = GetNextDirection(nextValidDirection);
            }

            isDirectionFound = true;
            return nextValidDirection;
        }

        private static void DrawRotatingPathInMatrix(int[,] matrix, Position currentPosition, ref Direction currentDirection, ref int numberToWrite)
        {
            while (true)
            {
                matrix[currentPosition.XCoord, currentPosition.YCoord] = numberToWrite;

                bool isNextValidDirection = false;
                currentDirection = GetNextValidDirection(matrix, currentPosition, currentDirection, ref isNextValidDirection);

                if (!isNextValidDirection)
                {
                    break;
                }

                currentPosition.Update(currentDirection);
                numberToWrite++;
            }
        }
    }
}
