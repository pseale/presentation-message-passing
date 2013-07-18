using System;

namespace MessagePassingDemoSnippets
{
  public class Board
  {
    readonly int[,] _board = new int[3,3];
    public Board()
    {
      MessageBus.Subscribe<PlayerMovedMessage>(UpdateBoard);  
    }

    private void UpdateBoard(PlayerMovedMessage message)
    {
      //do work
      _board[message.Row, message.Col] = message.Mark;
  
      //publish message
      var boardUpdatedMessage = new BoardUpdatedMessage {Board = CloneBoard(), IsFull = IsFull()};
      MessageBus.Publish(boardUpdatedMessage);
    }

    private bool IsFull()
    {
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          if (_board[i, j] != ' ')
            return false;
      return true;
    }

    private int[,] CloneBoard()
    {
      var clone = new int[3,3];
      for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
          clone[i, j] = _board[i, j];
      return clone;
    }
  }

  public class BoardUpdatedMessage
  {
    public int[,] Board { get; set; }
    public bool IsFull { get; set; }
  }

  public class PlayerMovedMessage
  {
    public int Row { get; set; }
    public int Col { get; set; }
    public char Mark { get; set; } // 'X' or 'O'
  }

  public static class MessageBus
  {
    public static void Subscribe<T>(Action<T> messageRecipient)
    {
      //demo, use a real one
    }

    public static void Publish<T>(T message)
    {
      //demo, use a real one
    }
  }
}