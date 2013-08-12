using System;

namespace TicTacToeMessages
{
  class Program
  {
    static void Main(string[] args)
    {
      var board = new Board();
      var boardUi = new BoardUi();
      var game = new Game(board);
      var playerMoveReader = new PlayerMoveReader();
      var computerBrain = new ComputerBrain();
      //Demo warning: this may be a bad practice because I'm not unsubscribing what I subscribe,  
      //and this may cause memory leaks
      board.Updated += boardUi.Draw;
      board.Updated += computerBrain.StoreBoardUpdate;
      boardUi.DrawInitialBoard();
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
