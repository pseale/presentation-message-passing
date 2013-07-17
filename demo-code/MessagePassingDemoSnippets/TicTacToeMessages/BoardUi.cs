using System;

namespace TicTacToeMessages
{
  public class BoardUi
  {
    public void Draw(char[,] board)
    {
      Console.WriteLine();
      Console.WriteLine("\t| A | B | C |");
      Console.WriteLine("\t+===+===+===+");
      DrawRow(board, 0);
      DrawRow(board, 1);
      DrawRow(board, 2);
    }

    private static void DrawRow(char[,] board, int rowOffset)
    {
      Console.WriteLine("  {3}\t| {0} + {1} + {2} +", board[rowOffset, 0], board[rowOffset, 1], board[rowOffset, 2],
                        rowOffset + 1);
      Console.WriteLine("\t+===+===+===+");
    }

    public void DrawInitialBoard()
    {
      var board = new char[3,3];
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          board[i, j] = ' ';
          Draw(board);
    }
  }
}