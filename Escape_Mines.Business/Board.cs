using Escape_Mines.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace Escape_Mines.Business
{
    public class Board : IBoard
    {
        public int Width { get; }

        public int Height { get; }

        public Tile ExitPoint { get; }

        public List<Tile> Mines { get; }

        public Board(int width, int height, Tile exitPoint, List<Tile> mines)
        {
            if (width <= 3)
            {
                throw new Exception("Width of board must greater than 3");
            }
            if (height <= 3)
            {
                throw new Exception("Height of board must greater than 3");
            }

            Width = width;
            Height = height;
            ExitPoint = exitPoint;
            Mines = mines;
        }
    }
}
