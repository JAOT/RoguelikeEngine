using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEngine.Entities
{
    public class Worm : NPC
    {
        public Worm(string name, int hp, string symbol) : base(name)
        {
            this.Name   = name;
            this.HP     = hp;
            Symbol      = symbol;
        }
    }
}
