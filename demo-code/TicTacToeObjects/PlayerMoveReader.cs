using System;

namespace TicTacToeObjects
{
  public class PlayerMoveReader
  {
    public Move Read()
    {
      Console.Write("Your move (e.g. A1): ");
      string move = Console.ReadLine();
      int col = (int)move[0] - (int)'A';
      int row = Int32.Parse(move[1].ToString()) - 1;
      return new Move(row, col, 'X');
    }
  }
}