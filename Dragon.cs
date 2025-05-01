using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Subclass of Monster: Dragon.
    internal class Dragon : Monster
    {
        // Constructor sets random value for health and damage between two limits.
        public Dragon() : base("Dragon", new Random().Next(60, 90), new Random().Next(15, 25))
        {

        }

        // Overriden method to provide specific attack behavior for the Dragon.
        public override void Attack(Creature target)
        {
            Console.WriteLine($"The {Name} shoots a fireball...");
            base.Attack(target);
        }

        // Overriden method to make a custom sound.
        public override void Speak()
        {
            Console.WriteLine($"The {Name} roars fiercely...");
        }
    }
}
