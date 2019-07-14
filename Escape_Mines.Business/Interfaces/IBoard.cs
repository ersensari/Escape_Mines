using System.Collections.Generic;

namespace Escape_Mines.Business.Interfaces
{
    public interface IBoard
    {
        /// <summary>
        /// How many tiles are built the board's X axis?
        /// </summary>
        int Width { get; }
        /// <summary>
        /// How many tiles are built the board's Y axis?
        /// </summary>
        int Height { get; }
        /// <summary>
        /// X and Y coordinates of exit point. The direction must be none.
        /// </summary>
        Tile ExitPoint { get; }

        /// <summary>
        /// List of mine positions
        /// </summary>
        List<Tile> Mines { get; }
    }
}