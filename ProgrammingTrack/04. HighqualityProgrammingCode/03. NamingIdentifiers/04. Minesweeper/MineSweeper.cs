using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Minesweeper
{
	public class Minesweeper
	{
		public class ScoreKeeper
		{
            string playerName;
			int playerScoreValue;

			public string PlayerName
			{
				get { return playerName; }
				set { playerName = value; }
			}

			public int PlayerScore
			{
				get { return playerScoreValue; }
				set { playerScoreValue = value; }
			}

			public ScoreKeeper() { }

			public ScoreKeeper(string playerName, int score)
			{
				this.playerName = playerName;
				this.playerScoreValue = score;
			}
		}

		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] board = CreateBoard();
			char[,] bombField = GenerateBombsLocations();
			int turnsPlayed = 0;
			bool hasFailed = false;
			List<ScoreKeeper> champions = new List<ScoreKeeper>(6);
			int inputRow = 0;
			int inputCol = 0;
			bool showInitialScreen = true;
			const int MaxPossibleTurns = 35;
			bool hasWon = false;

			do
			{
				if (showInitialScreen)
				{
					Console.WriteLine("Lets play \"Minesweeper\"!. Good luck finding all safe fields.\n" +
					"Type 'top' to view champions.\nType 'restart' for new game. \nType 'exit' to exit. Bye-bye");
					DrawBoard(board);
					showInitialScreen = false;
				}
				Console.Write("Type row and col: ");
				command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out inputRow) &&
					int.TryParse(command[2].ToString(), out inputCol) &&
						inputRow <= board.GetLength(0) && inputCol <= board.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						PrintChampions(champions);
						break;
					case "restart":
						board = CreateBoard();
						bombField = GenerateBombsLocations();
						DrawBoard(board);
						hasFailed = false;
						showInitialScreen = false;
						break;
					case "exit":
						Console.WriteLine("Ba-Bye!");
						break;
					case "turn":
						if (bombField[inputRow, inputCol] != '*')
						{
							if (bombField[inputRow, inputCol] == '-')
							{
								HandleTurn(board, bombField, inputRow, inputCol);
								turnsPlayed++;
							}
							if (MaxPossibleTurns == turnsPlayed)
							{
								hasWon = true;
							}
							else
							{
								DrawBoard(board);
							}
						}
						else
						{
							hasFailed = true;
						}
						break;
					default:
						Console.WriteLine("\nError! Invalid command.\n");
						break;
				}
				if (hasFailed)
				{
					DrawBoard(bombField);
					Console.Write("\nHrrrrrr! You have {0} points. " +
						"Type nickname: ", turnsPlayed);
					string playerNickName = Console.ReadLine();
					ScoreKeeper playerScore = new ScoreKeeper(playerNickName, turnsPlayed);

					if (champions.Count < 5)
					{
						champions.Add(playerScore);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].PlayerScore < playerScore.PlayerScore)
							{
								champions.Insert(i, playerScore);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((ScoreKeeper r1, ScoreKeeper r2) => r2.PlayerName.CompareTo(r1.PlayerName));
					champions.Sort((ScoreKeeper r1, ScoreKeeper r2) => r2.PlayerScore.CompareTo(r1.PlayerScore));
					PrintChampions(champions);

					board = CreateBoard();
					bombField = GenerateBombsLocations();
					turnsPlayed = 0;
					hasFailed = false;
					showInitialScreen = true;
				}
				if (hasWon)
				{
					Console.WriteLine("\nGood job! You have found all 35 safe fields.");
					DrawBoard(bombField);
					Console.WriteLine("Your name, batka-san: ");
					string playerNickName = Console.ReadLine();
					ScoreKeeper playerScore = new ScoreKeeper(playerNickName, turnsPlayed);
					champions.Add(playerScore);
					PrintChampions(champions);
					board = CreateBoard();
					bombField = GenerateBombsLocations();
					turnsPlayed = 0;
					hasWon = false;
					showInitialScreen = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void PrintChampions(List<ScoreKeeper> bestScores)
		{
			Console.WriteLine("\nHighScore: ");
			if (bestScores.Count > 0)
			{
				for (int i = 0; i < bestScores.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} fields",
						i + 1, bestScores[i].PlayerName, bestScores[i].PlayerScore);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty!\n");
			}
		}

		private static void HandleTurn(char[,] board,
			char[,] bombField, int inputRow, int inputCol)
		{
			char bombsCount = CountBombsAroundPosition(bombField, inputRow, inputCol);
			bombField[inputRow, inputCol] = bombsCount;
			board[inputRow, inputCol] = bombsCount;
		}


		private static void DrawBoard(char[,] board)
		{
			int boardRows = board.GetLength(0);
			int boardCols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

			for (int i = 0; i < boardRows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < boardCols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateBoard()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] GenerateBombsLocations()
		{
			int boardRows = 5;
			int boardCols = 10;
			char[,] board = new char[boardRows, boardCols];

			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardCols; j++)
				{
					board[i, j] = '-';
				}
			}

			List<int> bombLocationCollection = new List<int>();
			while (bombLocationCollection.Count < 15)
			{
				Random random = new Random();
				int location = random.Next(50);
				if (!bombLocationCollection.Contains(location))
				{
					bombLocationCollection.Add(location);
				}
			}

            foreach (int bomb in bombLocationCollection)
            {
                int bombCol = (bomb / boardCols);
                int row = (bomb % boardCols);

                if (row == 0 && bomb != 0)
                {
                    bombCol--;
                    row = boardCols;
                }
                else
                {
                    row++;
                }

                board[bombCol, row - 1] = '*';
            }

			return board;
		}

		private static char CountBombsAroundPosition(char[,] bombField, int row, int col)
		{
			int bombsCount = 0;
			int bombFieldRows = bombField.GetLength(0);
			int bombFieldCols = bombField.GetLength(1);

			if (row - 1 >= 0)
			{
				if (bombField[row - 1, col] == '*')
				{ 
					bombsCount++; 
				}
			}
			if (row + 1 < bombFieldRows)
			{
				if (bombField[row + 1, col] == '*')
				{ 
					bombsCount++; 
				}
			}
			if (col - 1 >= 0)
			{
				if (bombField[row, col - 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if (col + 1 < bombFieldCols)
			{
				if (bombField[row, col + 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (bombField[row - 1, col - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < bombFieldCols))
			{
				if (bombField[row - 1, col + 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((row + 1 < bombFieldRows) && (col - 1 >= 0))
			{
				if (bombField[row + 1, col - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((row + 1 < bombFieldRows) && (col + 1 < bombFieldCols))
			{
				if (bombField[row + 1, col + 1] == '*')
				{ 
					bombsCount++; 
				}
			}

			return char.Parse(bombsCount.ToString());
		}
	}
}
