using System;
using System.Collections.Generic;
using System.Text;

namespace Escape_Mines.Business
{
  public class Turtle
  {
    public TurtlePosition CurrentPosition { get; private set; }
    /// <summary>
    /// Set starting position of the turtle
    /// </summary>
    /// <param name="X">X axis on board</param>
    /// <param name="Y">Y axis on board</param>
    /// <param name="Direction">
    /// N = North direction
    /// S = South direction
    /// W = West direction
    /// E = East direction
    /// </param>
    public Turtle(int X, int Y, char Direction)
    {
      this.CurrentPosition = new TurtlePosition(X, Y, Direction);
    }
  }

  /// <summary>
  /// This entity accommodates the position of turtle
  /// </summary>
  public class TurtlePosition
  {
    /// <summary>
    /// Y axis on board
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// Y axis on board
    /// </summary>
    public int Y { get; set; }
    /// <summary>
    /// N = North direction
    /// S = South direction
    /// W = West direction
    /// E = East direction
    /// </summary>
    public char Direction { get; set; }

    public TurtlePosition(int X, int Y, char Direction)
    {
      this.X = X;
      this.Y = Y;
      this.Direction = Direction;
    }
  }

}
