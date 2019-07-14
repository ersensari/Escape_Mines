using Escape_Mines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escape_Mines.Business
{
    public class Tile : ITile
    {
        public int X { get; }

        public int Y { get; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
