using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class GameMap
    {
        private List<List<string>> SavedRooms;


        public GameMap()
        {
            SavedRooms = new List<List<string>>();
        }

        public void SaveRoom(string desc, string item)
        {
            SavedRooms.Add(new List<string> {desc,item});

        }

        public void PrintRooms()
        {
            Console.WriteLine($"You have visited {SavedRooms.Count()} rooms.");
            
        }
    }
}
