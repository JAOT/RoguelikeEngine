using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonEngine.DungeonGenerator;
namespace RogueLikeEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            DungeonGenerator dungeonGenerator = new DungeonGenerator();
            dungeonGenerator.CreateDungeonRoom(152, 36);
            dungeonGenerator.CellsToGenerate = 1500;
            dungeonGenerator.CreateDungeonScenery();
            dungeonGenerator.LogDungeon();
            if (Console.ReadKey() == ConsoleKeyInfo(ConsoleKey.Enter))
        }
    }
}
