using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Dragon : Monster
    {
        public Dragon() : base("Dragon", new Random().Next(60, 90), new Random().Next(15, 25))
        {

        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"The {Name} shoots a fireball...");
            base.Attack(target);
        }

        public override void Speak()
        {
            Console.WriteLine($"The {Name} roars fiercely...");
        }
    }
}
