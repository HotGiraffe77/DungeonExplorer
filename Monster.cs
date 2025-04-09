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

            Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage. ");
            target.Hit(Damage);
        }

        public virtual void Speak()
        {
            Console.WriteLine($"The {Name} growls menacingly...");
        }
    }
}
