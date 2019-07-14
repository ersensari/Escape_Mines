using Escape_Mines.Business.Enums;
using Escape_Mines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escape_Mines.Business
{
    public class Turtle : ITurtle
    {
        /// <summary>
        /// The turtle's last result
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Board specifications
        /// </summary>
        public Board Board { get; }

        /// <summary>
        /// Position of turtle
        /// </summary>
        public Position Position { get; }


        /// <summary>
        /// Set starting position of the turtle
        /// </summary>
        /// <param name="x">X axis on board</param>
        /// <param name="y">Y axis on board</param>
        /// <param name="direction">
        /// N = North direction
        /// S = South direction
        /// W = West direction
        /// E = East direction
        /// </param>
        public Turtle(int x, int y, Directions direction, Board board)
        {
            Board = board ?? throw new Exception("The turtle must know the board. Board mustn't be null.");

            Position = new Position(x, y, direction);
        }

        /// <summary>
        /// Move for a tile. This method moves turtle forward only one tile.
        /// </summary>
        /// <returns>
        /// Success – if the turtle finds the exit point
        /// Mine Hit – if the turtle hits a mine
        /// Still in Danger – it the turtle has not yet found the exit or hit a mine
        /// </returns>

        public string Move()
        {
            if (Status != null && Status != "Still in Danger")
            {
                return Status;
            }

            int x = Position.X;
            int y = Position.Y;

            switch (Position.Direction)
            {
                case Directions.N:
                    y--;
                    break;
                case Directions.E:
                    x++;
                    break;
                case Directions.S:
                    y++;
                    break;
                case Directions.W:
                    x--;
                    break;
            }

            //The turtle can not move to out of the board. Check this before setting position
            if (IsTheMovementWithinTheBoard(x, y))
            {
                Position.SetPosition(x, y);

                Status = CheckTurtleStatus();
            }

            return Status;
        }

        /// <summary>
        /// The turtle can not move to out of the board
        /// </summary>
        /// <param name="x">new position of x axis</param>
        /// <param name="y">new position of y axis</param>
        /// <returns>if true The turtle will move next, otherwise won't</returns>
        private bool IsTheMovementWithinTheBoard(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return false;
            }

            if (x > Board.Width)
            {
                return false;
            }

            if (y > Board.Height)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// What is the turtle's last status by current position?
        /// </summary>
        /// <returns>
        /// Success – if the turtle finds the exit point
        /// Mine Hit – if the turtle hits a mine
        /// Still in Danger – it the turtle has not yet found the exit or hit a mine
        /// </returns>
        private string CheckTurtleStatus()
        {
            if (Position.X == Board.ExitPoint.X && Position.Y == Board.ExitPoint.Y)
            {
                return "Success";
            }

            if (Board.Mines != null && Board.Mines.Count > 0)
            {
                if (Board.Mines.Any(m => m.X == Position.X && m.Y == Position.Y))
                {
                    return $"Mine Hit";
                }
            }

            return "Still in Danger";
        }

        /// <summary>
        /// Turns turtle to Left Or Right
        /// </summary>
        /// <param name="direction">L/R</param>
        public void Turn(char direction)
        {
            if (direction != 'R' && direction != 'L')
            {
                throw new Exception("Direction must be (R)ight or (L)eft");
            }


            switch (direction)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void TurnRight()
        {
            int rightFlag = (int)Position.Direction == 8 ? 1 : (int)Position.Direction << 1;
            Position.SetDirection((Directions)rightFlag);
        }

        /// <summary>
        /// 
        /// </summary>
        private void TurnLeft()
        {
            int leftFlag = (int)Position.Direction == 1 ? 8 : (int)Position.Direction >> 1;
            Position.SetDirection((Directions)leftFlag);
        }
    }

}
