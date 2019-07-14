using Escape_Mines.Business;
using Escape_Mines.Business.Enums;
using Escape_Mines.Business.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Escape_Mines.Tests
{
    public class TurtleTests
    {
        Board board;
        Turtle turtle;
        public TurtleTests()
        {
            List<Tile> mines = new List<Tile>();
            mines.Add(new Tile(1, 1));
            mines.Add(new Tile(1, 3));
            mines.Add(new Tile(3, 3));

            board = new Board(5, 4, new Tile(4, 2), mines);

            turtle = new Turtle(0, 1, Directions.N, board);
        }
        [Theory]
        [InlineData("MRMMRMMLMM")]
        public void Turtle_ShouldBeSuccess(string moves)
        {
            foreach (var m in moves)
            {
                if (m == 'M')
                {
                    turtle.Move();
                }
                else
                {
                    turtle.Turn(m);
                }
            }

            Assert.Equal("Success", turtle.Status);
        }

        [Theory]
        [InlineData("RMLMM")]
        [InlineData("RMMM")]
        public void Turtle_ShouldHitMine(string moves)
        {
            foreach (var m in moves)
            {
                if (m == 'M')
                {
                    turtle.Move();
                }
                else
                {
                    turtle.Turn(m);
                }
            }

            Assert.Equal("Mine Hit", turtle.Status);
        }
        [Theory]
        [InlineData("MRMLMM")]
        public void Turtle_ShouldBeStillInDanger(string moves)
        {
            foreach (var m in moves)
            {
                if (m == 'M')
                {
                    turtle.Move();
                }
                else
                {
                    turtle.Turn(m);
                }
            }

            Assert.Equal("Still in Danger", turtle.Status);
        }
    }
}
