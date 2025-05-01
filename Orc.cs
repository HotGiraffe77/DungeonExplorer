using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Monster subclass: Orc.
    public class Orc : Monster
    {

        // Constructor sets random value for health and damage between two limits.
        public Orc() : base("Orc", new Random().Next(45, 60), new Random().Next(8, 15))
        {

        }

        // Overriden method to provide specific attack behavior for the Orc.
        public override void Attack(Creature target)
        {
            Console.WriteLine($"The {Name} swings its axe...");
            base.Attack(target);
        }

        // Overriden method to make a custom sound
        public override void Speak()
        {
            Console.WriteLine($"The {Name} snarls menacingly...");
        }
    }
}
