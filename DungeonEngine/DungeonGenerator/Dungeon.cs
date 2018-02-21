using DungeonEngine.Structs;
using DungeonEngine.FOV;
using System;
using DungeonEngine.Entities;
using DungeonEngine.DungeonGenerator.CellInfo;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace DungeonEngine.DungeonGenerator
{
    public class Dungeon
    {
        int Width                       { get; set; }
        int Height                      { get; set; }
        int CellsToGenerate             { get; set; }
        public Cell[,] DungeonCells     { get; set; }
        public Player Player            { get; set; }

        /// <summary>
        /// A representation of a room to be decorated with cells.
        /// </summary>
        /// <param name="Width">How wide the room will be</param>
        /// <param name="height">How tall the room will be</param>
        /// <param name="freeCells">How many "walkable cells the room should contain</param>
        public Dungeon(int width, int height, int freeCells)
        {
            Width = width;
            Height = height;
            CellsToGenerate = freeCells;

            CreateDungeonRoom();
        }

        /// <summary>
        /// Create the basic dungeon area, filled with walls.
        /// Serves as the canvas of the final room to be built
        /// </summary>
        /// <param name="RoomWidth">The width of the room, as int</param>
        /// <param name="RoomHeight">The height of the room, as int</param>
        /// <param name="NumberOfGroundTiles">The number of ground (walkable) tiles to generate</param>
        public void CreateDungeonRoom()
        {
            DungeonCells = new Cell[Width,Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    DungeonCells[x, y] = new Cell(CellType.WALL, x, y, "#");
                }
            }
        }

        /// <summary>
        /// Populate the insides of the room
        /// </summary>
        public void CreateDungeonScenery()
        {
            //Make it so that the outside walls are untouched
            int minValueXY = 1;
            int maxValueX = Width - 2;
            int maxValueY = Height - 2;

            //Choose a random starting position in the room
            Random random = new Random();
            Point start = new Point(random.Next(minValueXY, maxValueX), random.Next(minValueXY, maxValueY));

            //Get directions to an array for random choosing
            Array values = Enum.GetValues(typeof(Direction));

            //From the starting position, proceed to create X number of ground cells, starting at 0
            int cellCount = 0;
            //A list to hold cell tiles, for scenery placement
            List<Cell> groundCells = new List<Cell>();
            
            //The variable that marks the current walker location
            Point walkerPosition = start;
            //Carve the ground

            while (cellCount < CellsToGenerate)
            {
                //Choose a direction at random
                Direction direction = (Direction)values.GetValue(random.Next(values.Length));

                //Update current selected cell coordinate
                switch (direction)
                {
                    case Direction.UP:
                        if (walkerPosition.Y > minValueXY)
                            walkerPosition.Y--;
                        break;
                    case Direction.DOWN:
                        if (walkerPosition.Y < maxValueY)
                            walkerPosition.Y++;
                        break;
                    case Direction.LEFT:
                        if (walkerPosition.X > minValueXY)
                            walkerPosition.X--;
                        break;
                    case Direction.RIGHT:
                        if (walkerPosition.X < maxValueX)
                            walkerPosition.X++;
                        break;
                }

                //From the position chosen, mark it as ground, if possible
                if (CreateGround(walkerPosition))
                {
                    //Mark the cell as ground
                    DungeonCells[walkerPosition.X, walkerPosition.Y] = new Cell(CellType.GROUND, walkerPosition.X, walkerPosition.Y, ".");

                    //Add current cell to the list
                    groundCells.Add(new Cell(CellType.GROUND, walkerPosition.X, walkerPosition.Y, "."));
                    
                    //Add one to cells created
                    cellCount++;
                }

            }

            //spawn player
            Player = new Player(start, DungeonCells)
            {
                Symbol = "Ô"
            };
            DungeonCells[start.X, start.Y] = new Cell(CellType.PLAYER, start.Y, start.Y, "Õ");
        }

        /// <summary>
        /// Check if the selected cell can be converted to a valid walkable tile, if not already
        /// </summary>
        /// <param name="pathLocation"></param>
        /// <returns></returns>
        private bool CreateGround(Point pathLocation) => DungeonCells[pathLocation.X, pathLocation.Y].CellType == CellType.WALL;

        /// <summary>
        /// Output the dungeon to the screen
        /// </summary>
        public void LogDungeon()
        {
            Console.Clear();

            for (int y = 0; y < Height; y++)
            {
                string line = "";
                for (int x = 0; x < Width; x++)
                {
                    line += DungeonCells[x, y].Symbol;
                }
                Console.WriteLine(line);
            }
        }
    }
}
