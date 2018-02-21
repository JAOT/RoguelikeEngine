using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEngine.Entities
{
    public class NPC
    {
        public string Name      { get; set; }
        public int HP           { get; set; }
        public string Symbol    { get; set; }
        public NPC(string name)
        {
            Name = name;
        }
        public NPC(string name, int hp)
        {
            Name = name;
            HP = hp;
        }
        public NPC(string name, int hp, string symbol)
        {
            Name = name;
            HP = hp;
            Symbol = symbol;
        }
    }
}
