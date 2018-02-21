using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonEngine.DungeonGenerator.CellInfo;
using DungeonEngine.Structs;

namespace DungeonEngine.FOV
{
    class FOVCalculator
    {
        public void GetVisibleCellsInRange(Point Location, int Radius, Cell[,] Dungeon)
        {
            var listOfCells = new List<Point>();
            //Get Top Left coordinate of our rounded rectangle
            int topLeftX = Location.X - (Radius / 2);
            int topLeftY = Location.Y - (Radius / 2);

            if (topLeftX < 1) topLeftX = 1;
            if (topLeftY < 1) topLeftY = 1;

            //Get circular area around the player
            for (int y = 0; y < Radius; y++)
            {
                for (int x = 0; x < Radius; x++)
                {
                    var distance = Math.Sqrt(Math.Pow((topLeftX + x) - Location.X, 2) + Math.Pow((topLeftY + y) - Location.Y, 2));
                    float diameter = ((float)Radius / 2);
                    //are we inside the circle (using diameter)
                    if (distance < diameter)
                    {
                        if ((Dungeon[topLeftX + x, topLeftY + y].CellType != CellType.PLAYER) && (Dungeon[topLeftX + x, topLeftY + y].CellType != CellType.WALL))

                        Dungeon[topLeftX + x, topLeftY + y].CellType = CellType.INVIEW;
                    }
                }
            }

        }
    }
}
