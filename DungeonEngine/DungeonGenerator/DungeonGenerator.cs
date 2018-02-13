using DungeonEngine.Structs;
using DungeonEngine.FOV;
using System;
namespace DungeonEngine.DungeonGenerator
{
    public class DungeonGenerator
    {
        public int Width            { get; set; }
        public int Height           { get; set; }
        public int CellsToGenerate  { get; set; }
        public Cell[,] DungeonCells { get; set; }
        public Point PlayerPosition { get; set; }

        public void CreateDungeonRoom(int RoomWidth, int RoomHeight)
        {
            Width = RoomWidth;
            Height = RoomHeight;
            DungeonCells = new Cell[Width,Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    CellType cellType = CellType.WALL;
                    DungeonCells[x, y] = new Cell(cellType);
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

            //Choose a random position in the room
            Random random = new Random();
            int startX = random.Next(minValueXY, maxValueX);
            int startY = random.Next(minValueXY, maxValueY);

            //Mark it as the starting position, for player placement, maybe?
            DungeonCells[startX, startY] = new Cell(CellType.START);
            PlayerPosition = new Point(startX, startY);


            //Get directions to an array for random choosing
            Array values = Enum.GetValues(typeof(Direction));

            //From the starting position, proceed to create X number of ground cells
            int cellCount = 0;
            while (cellCount < CellsToGenerate)
            {
                //Choose a direction at random
                Direction direction = (Direction)values.GetValue(random.Next(values.Length));

                #region old if clauses
                //if (direction == Direction.UP)
                //{
                //    startY -= 1;
                //    if (startY < minValueXY) { startY = minValueXY; }
                //}
                //else if (direction == Direction.DOWN)
                //{
                //    if (startY < maxValueY) { startY += 1; }
                //}
                //else if (direction == Direction.LEFT)
                //{
                //    startX -= 1;
                //    if (startX < minValueXY) { startX = minValueXY; }

                //}
                //else if (direction == Direction.RIGHT)
                //{

                //    if (startX < maxValueX) { startX += 1; }
                //}
                #endregion

                switch (direction)
                {
                    case Direction.UP:
                        startY--;
                        if (startY < minValueXY)
                            startY = minValueXY;
                        break;
                    case Direction.DOWN:
                        if (startY < maxValueY)
                            startY++;
                        break;
                    case Direction.LEFT:
                        startX--;
                        if (startX < minValueXY)
                            startX = minValueXY;
                        break;
                    case Direction.RIGHT:
                        if (startX < maxValueX)
                            startX++;
                        break;
                }

                //From the position chosen, mark it as ground, if possible
                if (CreateGround(startX, startY))
                {
                    //Mark the cell as ground
                    DungeonCells[startX, startY].CellType = CellType.GROUND;
                    //Add one to cells created
                    cellCount++;
                }
            }

            FOVCalculator FovCalculator = new FOVCalculator();
            FovCalculator.GetVisibleCellsInRange(PlayerPosition, 7, DungeonCells);




        }
        #region old if clause
        //private bool CreateGround(int startX, int startY)
        //{
        //    //There's not a wall there, so there's nothing to be done here
        //    if (DungeonCells[startX, startY].CellType != CellType.WALL)
        //    {
        //        return false;
        //    }
        //    //There is a wall, let's mark it as ground
        //    //DungeonCells[startX, startY].CellType = CellType.GROUND;
        //    return true;
        //}
        #endregion
        private bool CreateGround(int startX, int startY) => DungeonCells[startX, startY].CellType == CellType.WALL;

        public void LogDungeon()
        {
            Console.Clear();

            for (int y = 0; y < Height; y++)
            {
                string line = "";
                for (int x = 0; x < Width; x++)
                {
                    switch (DungeonCells[x, y].CellType)
                    {
                        case CellType.WALL:
                            line += "█";
                            break;
                        case CellType.GROUND:
                            line += "O";
                            break;
                        case CellType.START:
                            line += "H";
                            break;
                        case CellType.INVIEW:
                            line += "*";
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(line);
            }
                Console.Write(PlayerPosition.X + " " +PlayerPosition.Y);
        }
    }
}
