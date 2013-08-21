using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace MatrixWalk.Tests
{
    [TestClass]
    public class RotatingWalkInMatrixTests
    {
        [TestMethod, Timeout(150)]
        public void GenerateMatrix_SquareMatrix3()
        {
            int[,] testmatrix = RotatingWalkInMatrix.GenerateMatrix(3);

            string[] expected = { "1", "7", "8", "6", "2", "9", "5", "4", "3" };

            for (int i = 0; i < testmatrix.GetLength(0); i++)
            {
                for (int j = 0; j < testmatrix.GetLength(1); j++)
                {
                    string expectedNumAsStr = expected[testmatrix.GetLength(0) * i + j];
                    Assert.AreEqual(expectedNumAsStr, testmatrix[i, j].ToString());
                }
            }
        }

        [TestMethod, Timeout(150)]
        public void GenerateMatrix_OddInput()
        {
            int[,] testmatrix = RotatingWalkInMatrix.GenerateMatrix(9);

            string[] expected = { "1", "25", "26", "27", "28", "29", "30", "31", "32", "24", "2", "45", "46", "47",
                                 "48", "49", "50", "33", "23", "61", "3", "44", "57", "58", "59", "51", "34",
                                 "22", "75", "62", "4", "43", "56", "60", "52", "35", "21", "74", "76", "63", "5",
                                 "42", "55", "53", "36", "20", "73", "81", "77", "64", "6", "41", "54", "37",
                                 "19", "72", "80", "79", "78", "65", "7", "40", "38", "18", "71", "70", "69", "68",
                                 "67", "66", "8", "39", "17", "16", "15", "14", "13", "12", "11", "10", "9" };
            for (int i = 0; i < testmatrix.GetLength(0); i++)
            {
                for (int j = 0; j < testmatrix.GetLength(1); j++)
                {
                    string expectedNumAsStr = expected[testmatrix.GetLength(0) * i + j];
                    Assert.AreEqual(expectedNumAsStr, testmatrix[i, j].ToString());
                }
            }
        }

        [TestMethod, Timeout(150)]
        public void GenerateMatrix_EvenInput()
        {
            int[,] testmatrix = RotatingWalkInMatrix.GenerateMatrix(10);

            string[] expected = { "1", "28", "29", "30", "31", "32", "33", "34", "35", "36", "27", "2", "51", "52",
                                 "53", "54", "55", "56", "57", "37", "26", "73", "3", "50", "66", "67", "68",
                                 "69", "58", "38", "25", "90", "74", "4", "49", "65", "72", "70", "59", "39", "24",
                                 "89", "91", "75", "5", "48", "64", "71", "60", "40", "23", "88", "99", "92",
                                 "76", "6", "47", "63", "61", "41", "22", "87", "98", "100", "93", "77", "7", "46",
                                 "62", "42", "21", "86", "97", "96", "95", "94", "78", "8", "45", "43", "20", "85",
                                 "84", "83", "82", "81", "80", "79", "9", "44", "19", "18", "17", "16", "15",
                                 "14", "13", "12", "11", "10" };

            for (int i = 0; i < testmatrix.GetLength(0); i++)
            {
                for (int j = 0; j < testmatrix.GetLength(1); j++)
                {
                    string expectedNumAsStr = expected[testmatrix.GetLength(0) * i + j];
                    Assert.AreEqual(expectedNumAsStr, testmatrix[i, j].ToString());
                }
            }
        }

        [TestMethod, Timeout(150)]
        public void GenerateMatrix_ZeroSize()
        {
            int[,] testmatrix = RotatingWalkInMatrix.GenerateMatrix(0);

            Assert.AreEqual(0, testmatrix.GetLength(0));
        }

        [TestMethod, Timeout(150)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateMatrix_SizeTooLarge()
        {
            int[,] testmatrix = RotatingWalkInMatrix.GenerateMatrix(101);
        }
    }
}
