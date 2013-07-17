namespace TicTacToeObjects
{
  public class Move
  {
    public int Row { get; private set; }
    public int Col { get; private set; }
    public char Mark { get; private set; }

    public Move() { }
    public Move(int row, int col, char mark)
    {
      Row = row;
      Col = col;
      Mark = mark;
    }
  }
}