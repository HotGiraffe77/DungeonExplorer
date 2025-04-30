using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Statistics
    {
        private int kills { get; set; }
        private int items { get; set; }
        private int rooms { get; set; }
        public Statistics()
        {

        }

        public void countKills()
        {
            kills += 1;
        }
        public void countItems()
        {
            items += 1;
        }
        public void countRooms()
        {
            rooms += 1;
        }
        public void conclusion()
        {
            Console.WriteLine($"You have killed {kills} monsters," +
                $"\npicked up {items} items," +
                $"\nand visited {rooms} rooms.");
        }
    }
}
