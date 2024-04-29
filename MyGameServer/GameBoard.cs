using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourServer
{
    public class GameBoard
    {
        public int[,] statusMatrix;
        private const int rows = 6;
        private const int cols = 7;

        public GameBoard()
        {
            statusMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    statusMatrix[i, j] = 0;
                }
            }
        }
        

        public int insertDisc(int column, int currentPlayer)
        {
            for (int i = statusMatrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (statusMatrix[i, column] == 0)
                {
                    statusMatrix[i, column] = currentPlayer;
                    return i;
                }
            }
            return -1; // Column is already full
        }

        public void restartGame()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    statusMatrix[i, j] = 0;
                }
            }
        }

            public bool checkWin(int currentPlayer)
        {
            return CheckHorizontal(currentPlayer) || CheckVertical(currentPlayer) || CheckDiagonal(currentPlayer);
        }

        private bool CheckHorizontal(int currentPlayer)
        {
            for (int row = 0; row < rows; row++)
                {
                  for (int col = 0; col <= cols - 4; col++)
                    {
                      if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row, col + 1] == currentPlayer &&
                            statusMatrix[row, col + 2] == currentPlayer &&
                            statusMatrix[row, col + 3] == currentPlayer)
                        {
                            return true;
                        }
                    }
                }
                return false;
        }

        private bool CheckVertical(int currentPlayer)
        {
            for (int row = 0; row <= rows - 4; row++)
            {
                   for (int col = 0; col < cols; col++)
                   {
                        if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row + 1, col] == currentPlayer &&
                            statusMatrix[row + 2, col] == currentPlayer &&
                           statusMatrix[row + 3, col] == currentPlayer)
                        {
                            return true;
                        }
                   }
            }
                return false;
        }

        private bool CheckDiagonal(int currentPlayer)
        {
                // Check for diagonal wins from top-left to bottom-right
            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = 0; col <= cols - 4; col++)
                {
                    if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row + 1, col + 1] == currentPlayer &&
                            statusMatrix[row + 2, col + 2] == currentPlayer &&
                            statusMatrix[row + 3, col + 3] == currentPlayer)
                    {
                            return true;
                    }
                }
            }


            // Check for diagonal wins from top-right to bottom-left
            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = cols - 1; col >= 3; col--)
                {
                    if (statusMatrix[row, col] == currentPlayer &&
                            statusMatrix[row + 1, col - 1] == currentPlayer &&
                            statusMatrix[row + 2, col - 2] == currentPlayer &&
                            statusMatrix[row + 3, col - 3] == currentPlayer)
                    {
                            return true;
                    }
                }
            }

            return false;
        }
    }
}

   
