using Escape_Mines.Business.Enums;

namespace Escape_Mines.Business.Interfaces
{
    interface IPosition
    {
        /// <summary>
        /// N = North direction
        /// S = South direction
        /// W = West direction
        /// E = East direction
        /// </summary>
        Directions Direction { get; }

        /// <summary>
        /// Set positions x and y axis
        /// </summary>
        /// <param name="x">X axis</param>
        /// <param name="y">Y axis</param>
        void SetPosition(int x, int y);

        /// <summary>
        /// Set direction
        /// </summary>
        /// <param name="direction">N-S-W-E enum</param>
        void SetDirection(Directions direction);
    }
}
