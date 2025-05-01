using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Monster subclass: Goblin.
    public class Goblin : Monster
    {
        // Constructor sets random value for health and damage between two limits.
        public Goblin() : base("Goblin", new Random().Next(30, 45), new Random().Next(5,12))
        {

        }

        // Overriden method to provide specific attack behavior for the Goblin.
        public override void Attack(Creature target)
        {
            Console.WriteLine($"The {Name} swings it dagger...");
            base.Attack(target);
        }

        // Overriden method to make a custom sound.
        public override void Speak()
        {
            Console.WriteLine($"The {Name} cackles maniacally...");
        }
    }
}
