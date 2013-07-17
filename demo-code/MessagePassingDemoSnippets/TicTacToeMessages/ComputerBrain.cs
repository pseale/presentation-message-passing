namespace TicTacToeMessages
{
  public class ComputerBrain
  {
    private char[,] _board;

    public ComputerBrain()
    {
    }

    public void StoreBoardUpdate(char[,] board)
    {
      _board = board;
    }

    public Move DetermineNextMove()
    {
      //terrible AI, enjoy
      for (int i = 0; i < 9; i++)
        if (_board[i / 3, i % 3] == ' ')
          return new Move(i / 3, i % 3, 'O');

      //failure case, board is full
      return new Move();
    }
  }
}