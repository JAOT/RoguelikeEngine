﻿using System;
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
        public string Symbol { get; set; }

        public Cell(CellType cellType, int x, int y, string symbol)
        {
            CellType = cellType;
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }

        public override string ToString()
        {
            return "Type: " + CellType;
        }
    }
}
