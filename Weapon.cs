using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Inherits from Item.
    public class Weapon : Item
    {
        // Passes the name and damage back to Item.
        public Weapon(string name, int damage)
            : base(name, damage)
        {

        }

        // Overrides the method to output a custom message.
        public override void Use()
        {
            Console.WriteLine($"This seems like a good weapon, it will damage monsters...");
            Console.WriteLine("Weapon equipped...");
        }
    }
}
