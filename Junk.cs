using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Junk : Item
    {
        public Junk(string name, int damage)
            : base(name, damage)
        {

        }


        public override void Use()
        {
            Console.WriteLine("This item is junk and does nothing...");
        }

    }
}
