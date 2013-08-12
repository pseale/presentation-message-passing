namespace TicTacToeObjects
{
  public class ComputerBrain
  {
    private readonly Board _board;

    public ComputerBrain(Board board)
    {
      _board = board;
    }

    public Move DetermineNextMove()
    {
      var board = _board.GetBoardDataForAi();
      //terrible AI, enjoy
      for (int i = 0; i < 9; i++)
        if (board[i / 3, i % 3] == ' ')
          return new Move(i / 3, i % 3, 'O');

      //failure case, board is full
      return new Move();
    }
  }
}