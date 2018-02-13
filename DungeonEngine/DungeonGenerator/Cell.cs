using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonEngine.DungeonGenerator
{
    public struct Cell
    {
        /// <summary>
        /// Location in the grid
        /// </summary>
        public CellType CellType;

        public Cell(CellType cellType)
        {
            CellType = cellType;
        }

        public override string ToString()
        {
            return "Type: " + CellType;
        }
    }
}
