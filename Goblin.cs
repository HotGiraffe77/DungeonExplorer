using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Goblin : Monster
    {
        public Goblin() : base("Goblin", new Random().Next(30, 45), new Random().Next(5,12))
        {

        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"The {Name} swings it dagger...");
            base.Attack(target);
        }

        public override void Speak()
        {
            Console.WriteLine($"The {Name} cackles maniacally...");
        }
    }
}
