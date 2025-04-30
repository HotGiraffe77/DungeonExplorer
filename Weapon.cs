using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Weapon : Item
    {
        public Weapon(string name, int damage)
            : base(name, damage)
        {

        }

        public override void Use()
        {
            Console.WriteLine($"This seems like a good weapon, it will damage monsters...");
            Console.WriteLine("Weapon equipped...");
        }
    }
}
