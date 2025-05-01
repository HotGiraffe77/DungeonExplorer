using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Abstract class that both item types inherit from.
    public abstract class Item
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        // Constructor initialises item name and damage.
        public Item(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        // Abstract method for items to be "used".
        public abstract void Use();

    }
}
