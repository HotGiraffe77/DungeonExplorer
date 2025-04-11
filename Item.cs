using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Item(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public abstract void Use();

    }
}
