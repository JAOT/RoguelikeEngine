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
        static Dungeon dungeon;
        static void Main(string[] args)
        {
            CreateDungeon();
        }

        private static void CreateDungeon( )
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            if (keyPressed.Key == ConsoleKey.Enter)
            {
                dungeon = new Dungeon(64, 28, 1200);
                dungeon.CreateDungeonScenery();
                dungeon.LogDungeon();
                Console.SetCursorPosition(5, 29);
                Console.Write("The Ancient Location of doomed adventurers");

                Console.SetCursorPosition(66, 0);
                Console.Write("Location: " + dungeon.Player.Location + "  ");

                Play();
            }

            Play();
        }

        private static void Play()
        {

            dungeon.Player.Location = dungeon.Player.GetInput();
            Console.SetCursorPosition(66, 0);
            Console.Write("Location: " + dungeon.Player.Location + "  ");

            Play();

        }
    }
}