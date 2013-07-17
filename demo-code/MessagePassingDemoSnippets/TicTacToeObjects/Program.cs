using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeObjects
{
  public class Program
  {
    private static void Main(string[] args)
    {
      var board = new Board();
      var game = new Game(board);
      var playerMoveReader = new PlayerMoveReader();
      var computerBrain = new ComputerBrain(board);
      game.DrawInitialBoard();
      while (!game.Finished())
      {
        var move = playerMoveReader.Read();
        game.Update(move);
        if (game.DidWeWin())
        {
          Console.WriteLine("You win!"); continue;
        }

        if (game.IsItATie())
        {
          Console.WriteLine("It's a draw!"); continue;
        }

        game.Update(computerBrain.DetermineNextMove());

        if (game.DidComputerWin())
        {
          Console.WriteLine("You lose!"); continue;
        }
      }
      Console.ReadKey();
    }
  }
}