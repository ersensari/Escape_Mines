using Escape_Mines.Business.Enums;
using Escape_Mines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escape_Mines.Business
{
    /// <summary>
    /// This entity accommodates the position of turtle
    /// </summary>
    public class Position : IPosition, ITile
    {
        /// <summary>
        /// Y axis on board
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// Y axis on board
        /// </summary>
        public int Y { get; private set; }
        /// <summary>
        /// N = North direction
        /// S = South direction
        /// W = West direction
        /// E = East direction
        /// </summary>
        public Directions Direction { get; private set; }

        public Position(int x, int y, Directions direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        /// <summary>
        /// Set positions x and y axis
        /// </summary>
        /// <param name="x">X axis</param>
        /// <param name="y">Y axis</param>
        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Set direction to N-S-W-E
        /// </summary>
        /// <param name="direction">N-S-W-E enum</param>
        public void SetDirection(Directions direction)
        {
            Direction = direction;
        }
    }
}
