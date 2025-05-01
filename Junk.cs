using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Inherits from Item.
    public class Junk : Item
    {
        // Passes the name and damage back to Item.
        public Junk(string name, int damage)
            : base(name, damage)
        {

        }


        // Overrides Use to do nothing.
        public override void Use()
        {
            Console.WriteLine("This item is junk and does nothing...");
        }

    }
}
