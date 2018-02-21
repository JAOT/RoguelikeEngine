using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonEngine.DungeonGenerator.CellInfo
{
    public struct Cell
    {
        /// <summary>
        /// Location in the grid
        /// </summary>
        public CellType CellType { get; set; }
        private int X { get; }
        private int Y { get; }

        public Cell(CellType cellType, int x, int y)
        {
            CellType = cellType;
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "Type: " + CellType;
        }
    }
}
