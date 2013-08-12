using System;

namespace TicTacToeProcedural
{
  public class Program
  {
    private static void Main(string[] args)
    {
      var board = new char[3,3];
      ClearBoard(board);

      bool finished = false;

      DrawBoard(board);
      while (!finished)
      {
        var move = GetPlayerMove();
        UpdateBoard(board, move[0], move[1], 'X');
        if (WeWon(board))
        {
          Console.WriteLine("You win!"); finished = true; continue;
        }

        if (BoardIsFull(board))
        {
          Console.WriteLine("It's a draw!"); finished = true; continue;
        }

        int[] aiMove = GetAiMove(board);
        UpdateBoard(board, aiMove[0], aiMove[1], 'O');

        if (ComputerWon(board))
        {
          Console.WriteLine("You lose!"); finished = true; continue;
        }
      }
      Console.ReadKey();
    }

    private static void ClearBoard(char[,] board)
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          board[i, j] = ' ';
    }

    private static int[] GetPlayerMove()
    {
      Console.Write("Your move (e.g. A1): ");
      string move = Console.ReadLine();
      int col = (int)move[0] - (int)'A';
      int row = Int32.Parse(move[1].ToString()) - 1;
      return new int[] { row, col };
    }

    private static void DrawBoard(char[,] board)
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
      Console.WriteLine("  {3}\t| {0} + {1} + {2} +", board[rowOffset, 0], board[rowOffset, 1], board[rowOffset, 2], rowOffset+1);
      Console.WriteLine("\t+===+===+===+");
    }

    private static bool BoardIsFull(char[,] board)
    {
      for (int i = 0; i < 9; i++)
        if (board[i / 3, i % 3] == ' ')
          return false;
      return true;
    }

    private static bool ComputerWon(char[,] board)
    {
      return PlayerWon(board, 'O');
    }

    private static bool WeWon(char[,] board)
    {
      return PlayerWon(board, 'X');
    }

    private static bool PlayerWon(char[,] board, char mark)
    {
      if (board[0, 0] == mark && board[1, 1] == mark && board[2, 2] == mark)
        return true;
      if (board[2, 0] == mark && board[1, 1] == mark && board[0, 2] == mark)
        return true;
      for (int i = 0; i < 3; i++)
      {
        if (board[i, 0] == mark && board[i, 1] == mark && board[i, 2] == mark)
          return true;
        if (board[0, i] == mark && board[1, i] == mark && board[2, i] == mark)
          return true;
      }

      return false;
    }

    private static int[] GetAiMove(char[,] board)
    {
      //terrible AI, enjoy
      for (int i = 0; i < 9; i++)
        if (board[i/3, i%3] == ' ')
          return new int[] {i/3, i%3};

      //failure case, board is full
      return new int[] {};
    }

    private static void UpdateBoard(char[,] board, int row, int col, char play)
    {
      board[row, col] = play;
      DrawBoard(board);
    }
  }
}
