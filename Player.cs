using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonExplorer
{
    ///<summary>
    /// Creates the player that representst he user
    /// The player class has methods for inventory intercation and username aquisition
    /// </summary>

    public class Player : Creature
    {
        // Constructor initialises the players name and health.
        public Player(string name, int health, int damage)
            : base(name, health, damage) { }


        public override void Attack(Creature target)
        {
            int dmg = Damage;
            Console.WriteLine($"You attack {target.Name} for {dmg} damage. ");
            target.Hit(dmg);
        }
    }
}