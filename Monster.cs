using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public Monster(string name, int health, int damage)
            : base(name,health, damage) { }


        public override void Attack(Creature target)
        {
            int damage = Damage;
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage. ");
            target.Hit(damage);
        }
    }
}
