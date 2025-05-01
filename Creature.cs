using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{   
    // Base class for all "living" creatures in the game. (Monsters and the player inherit from this.)
    public abstract class Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }


        public Creature(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        // Property to check if the creature is alive.
        public bool IsAlive => Health > 0;

        // Method to reduce Health when attacked.
        public void Hit(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name}'s health is now {Health}.");
        }

        // Abstract method for custom attacks for creatures.
        public abstract void Attack(Creature target);

    }

    // Interface for monsters to make sounds.
    public interface IMonsterSound
    {
        void Speak();
    }
}
