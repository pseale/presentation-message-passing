using System;

namespace TicTacToeMessages
{
  public class Board
  {
    public event Action<char[,]> Updated;

    private readonly char[,] _board = new char[3, 3];

    public Board()
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          _board[i, j] = ' ';
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
      OnUpdated(CloneBoardData());
    }

    public bool IsFull()
    {
      for (int i = 0; i < 9; i++)
        if (_board[i / 3, i % 3] == ' ')
          return false;
      return true;
    }

    private char[,] CloneBoardData()
    {
      var clone = new char[3, 3];
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          clone[i, j] = _board[i, j];

      return clone;
    }

    protected virtual void OnUpdated(char[,] board)
    {
      Action<char[,]> handler = Updated;
      if (handler != null) handler(board);
    }
  }
}