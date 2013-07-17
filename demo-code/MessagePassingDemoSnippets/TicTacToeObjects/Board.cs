using System;

namespace TicTacToeObjects
{
  public class Board
  {
    private readonly char[,] _board = new char[3,3];

    public Board()
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          _board[i, j] = ' ';
    }

    public void Draw()
    {
      Console.WriteLine();
      Console.WriteLine("\t| A | B | C |");
      Console.WriteLine("\t+===+===+===+");
      DrawRow(_board, 0);
      DrawRow(_board, 1);
      DrawRow(_board, 2);
    }

    private static void DrawRow(char[,] board, int rowOffset)
    {
      Console.WriteLine("  {3}\t| {0} + {1} + {2} +", board[rowOffset, 0], board[rowOffset, 1], board[rowOffset, 2],
                        rowOffset + 1);
      Console.WriteLine("\t+===+===+===+");
    }

    public bool PlayerWon(char mark)
    {
      if (_board[0, 0] == mark && _board[1, 1] == mark && _board[2, 2] == mark)
        return true;
      if (_board[2, 0] == mark && _board[1, 1] == mark && _board[0, 2] == mark)
        return true;
      for (int i = 0; i < 3; i++)
      {
        if (_board[i, 0] == mark && _board[i, 1] == mark && _board[i, 2] == mark)
          return true;
        if (_board[0, i] == mark && _board[1, i] == mark && _board[2, i] == mark)
          return true;
      }

      return false;
    }

    public void Update(Move move)
    {
      _board[move.Row, move.Col] = move.Mark;
    }

    public bool IsFull()
    {
      for (int i = 0; i < 9; i++)
        if (_board[i / 3, i % 3] == ' ')
          return false;
      return true;
    }

    public char[,] GetBoardDataForAi()
    {
      var clone = new char[3,3];
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          clone[i, j] = _board[i, j];

      return clone;
    }
  }
}