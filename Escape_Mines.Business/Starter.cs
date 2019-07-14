using Escape_Mines.Business.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Escape_Mines.Business
{
    public class Starter
    {
        private readonly Board board;
        private readonly List<Tile> mines;
        private readonly int boardWidth;
        private readonly int boardHeight;
        private readonly Tile exitPoint;
        private readonly Position startPoint;
        private readonly string[][] routes;

        public Starter(string[] fileLines)
        {
            if (fileLines.Length < 5)
            {
                throw new Exception("File format is incorect.");
            }

            boardWidth = ParseBoardWidth(fileLines[0]);
            boardHeight = ParseBoardHeight(fileLines[0]);
            mines = ParseMines(fileLines[1]);
            exitPoint = new Tile(ParseExitPointX(fileLines[2]), ParseExitPointY(fileLines[2]));

            board = new Board(boardWidth, boardHeight, exitPoint, mines);

            startPoint = ParseStartPoint(fileLines[3]);
            routes = ParseRoutes(fileLines.Skip(4));
        }

        private string[][] ParseRoutes(IEnumerable<string> routeLines)
        {
            if (routeLines == null)
            {
                throw new Exception("Routes has been defined incorrect");
            }

            string[][] routearray = routeLines.Select(x =>
            {
                return x.Split(' ');
            }).ToArray();

            return routearray;
        }

        private List<Tile> ParseMines(string minesLine)
        {
            List<Tile> t_mines = new List<Tile>();
            string[] tiles = minesLine.Split(' ');
            if (tiles.Length == 0)
            {
                throw new Exception("Mine array has been defined incorrect");
            }

            foreach (var t in tiles)
            {
                string[] pos = t.Split(',');
                if (pos.Length != 2)
                {
                    throw new Exception("Mine position is not correct");
                }

                if (!int.TryParse(pos[0], out int x))
                {
                    throw new Exception("Mine position x must be integer");
                }
                if (!int.TryParse(pos[1], out int y))
                {
                    throw new Exception("Mine position y must be integer");
                }


                t_mines.Add(new Tile(x, y));
            }

            return t_mines;
        }

        private int ParseBoardWidth(string sizeLine)
        {
            //First line is board size seperated with space
            string[] size = sizeLine.Split(' ');
            if (size.Length != 2)
            {
                throw new Exception("Board size has been defined incorrect");
            }

            if (!int.TryParse(size[0], out int width))
            {
                throw new Exception("Board size must be an integer.");
            }

            return width;
        }
        private int ParseBoardHeight(string sizeLine)
        {
            //First line is board size seperated with space
            string[] size = sizeLine.Split(' ');
            if (size.Length != 2)
            {
                throw new Exception("Board size has been defined incorrect");
            }

            if (!int.TryParse(size[1], out int height))
            {
                throw new Exception("Board size must be an integer.");
            }
            return height;
        }

        private int ParseExitPointX(string pointLine)
        {
            string[] point = pointLine.Split(' ');
            if (point.Length != 2)
            {
                throw new Exception("Exit point has been defined incorrect");
            }

            if (!int.TryParse(point[0], out int x))
            {
                throw new Exception("Exit point X must be an integer.");
            }

            return x;
        }

        private int ParseExitPointY(string pointLine)
        {
            string[] point = pointLine.Split(' ');
            if (point.Length != 2)
            {
                throw new Exception("Exit point has been defined incorrect");
            }

            if (!int.TryParse(point[1], out int y))
            {
                throw new Exception("Exit point Y must be an integer.");
            }

            return y;
        }

        private int ParseStartPointX(string[] point)
        {
            if (!int.TryParse(point[0], out int x))
            {
                throw new Exception("Start point X must be an integer.");
            }

            return x;
        }

        private int ParseStartPointY(string[] point)
        {
            if (!int.TryParse(point[1], out int y))
            {
                throw new Exception("Start point Y must be an integer.");
            }

            return y;
        }

        private Directions ParseStartDirection(string[] point)
        {
            string d = point[2];
            if (!Enum.TryParse(d, true, out Directions direction))
            {
                throw new Exception("Start point Direction must be one of N,E,S,W.");
            }
            return direction;
        }

        private Position ParseStartPoint(string pointLine)
        {
            string[] point = pointLine.Split(' ');
            if (point.Length != 3)
            {
                throw new Exception("Start point has been defined incorrect");
            }

            return new Position(ParseStartPointX(point), ParseStartPointY(point), ParseStartDirection(point));
        }

        private string MoveOrTurn(Turtle turtle, string command)
        {
            string result = string.Empty;
            if (command.Length > 1)
            {
                throw new Exception("Series of commands must be char");
            }

            switch (command)
            {
                case "M":
                    result = turtle.Move();
                    break;
                case "R":
                case "L":
                    turtle.Turn(command[0]);
                    break;
            }


            return result;
        }

        public string[] Start()
        {
            List<string> results = new List<string>();

            for (int i = 0; i < routes.Length; i++)
            {
                //the turtle is created for every series of moves 
                Turtle turtle = new Turtle(startPoint.X, startPoint.Y, startPoint.Direction, board);
                string result = string.Empty;
                for (int j = 0; j < routes[i].Length; j++)
                {
                    result = MoveOrTurn(turtle, routes[i][j]);
                    if (result != string.Empty && result != "Still in Danger")
                    {
                        break;
                    }
                }
                results.Add(result);
            }

            return results.ToArray();
        }
    }
}
