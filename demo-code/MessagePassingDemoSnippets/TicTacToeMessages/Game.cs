namespace TicTacToeMessages
{
  public class Game
  {
    private readonly Board _board;

    public Game(Board board)
    {
      _board = board;
    }

    public void DrawInitialBoard()
    {
      _board.Draw();
    }

    public bool Finished()
    {
      if (PlayerWon('X'))
        return true;
      if (PlayerWon('O'))
        return true;
      if (_board.IsFull())
        return true;
      return false;
    }

    public bool DidWeWin()
    {
      return PlayerWon('X');
    }

    public bool DidComputerWin()
    {
      return PlayerWon('O');
    }

    private bool PlayerWon(char mark)
    {
      return _board.PlayerWon(mark);
    }

    public bool IsItATie()
    {
      return _board.IsFull();
    }

    public void Update(Move move)
    {
      _board.Update(move);
      _board.Draw();
    }
  }
}