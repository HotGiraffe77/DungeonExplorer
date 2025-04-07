using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{   
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

        public bool IsAlive => Health > 0;

        public void Hit(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} takes {amount} damage. Health is now {Health}.");
        }

        public abstract void Attack(Creature target);
    }
}
