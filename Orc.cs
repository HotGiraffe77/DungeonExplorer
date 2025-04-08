using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Orc : Monster
    {
        public Orc() : base("Orc", new Random().Next(45, 60), new Random().Next(8, 15))
        {

        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"The {Name} swings its axe...");
            base.Attack(target);
        }

        public override void Speak()
        {
            Console.WriteLine($"The {Name} snarls menacingly...");
        }
    }
}
