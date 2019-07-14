namespace Escape_Mines.Business.Interfaces
{
    interface ITurtle
    {
        /// <summary>
        /// X,Y and Direction of turtle
        /// </summary>
        Position Position { get; }
        /// <summary>
        /// The turtle must know the board
        /// </summary>
        Board Board { get; }

        /// <summary>
        /// Move for a tile. This method moves turtle forward only one tile.
        /// </summary>
        /// <returns>
        /// Success – if the turtle finds the exit point
        /// Mine Hit – if the turtle hits a mine
        /// Still in Danger – it the turtle has not yet found the exit or hit a mine
        /// </returns>
        string Move();

        /// <summary>
        /// Turns turtle to N-S-W-E direction
        /// </summary>
        /// <param name="direction">N-S-W-E</param>
        void Turn(char direction);

    }
}
