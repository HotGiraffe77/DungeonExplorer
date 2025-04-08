using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Creature, IMonsterSound
    {


        public Monster(string name, int health, int damage)
            : base(name,health, damage)
        {

        }

        public override void Attack(Creature target)
        {
            int damage = new Random().Next(1,Damage + 1);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage. ");
            target.Hit(damage);
        }

        public virtual void Speak()
        {
            Console.WriteLine($"The {Name} growls menacingly...");
        }
    }
}
