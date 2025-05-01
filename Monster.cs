using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Base class for all monsters to inherit from. Inherits from creature itself.
    public class Monster : Creature, IMonsterSound // Implements IMonsterSound interface.
    {

        // Contructor for the monster class. Takes a name, health, and damage then passes them back to creature.
        public Monster(string name, int health, int damage)
            : base(name,health, damage)
        {
        }

        // Base version of the attack method for monsters to call back to (Uses the hit method from creature).
        public override void Attack(Creature target)
        {

            Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage. ");
            target.Hit(Damage);
        }

        // Base version of the speak method.
        public virtual void Speak()
        {
            Console.WriteLine($"The {Name} growls menacingly...");
        }
    }
}
