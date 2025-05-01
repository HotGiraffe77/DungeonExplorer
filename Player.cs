using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonExplorer
{
    // Player class inherits from creature.
    public class Player : Creature
    {
        // Constructor gets the players name, health, and damage then passes them to the creature class.
        public Player(string name, int health, int damage)
            : base(name, health, damage) { }


        // Overides attack method from the creature class.
        public override void Attack(Creature target)
        {
            int dmg = Damage;
            Console.WriteLine($"You attack {target.Name} for {dmg} damage. ");
            target.Hit(dmg);
        }

        // No interface as the player doesnt make sound.
    }
}