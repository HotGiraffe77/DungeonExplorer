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

        public string PrintRooms()
        {
            Console.WriteLine($"You have visited {SavedRooms.Count()} rooms.");
            if (SavedRooms.Count() >1)
            {
                while (true)
                {
                    Console.WriteLine("Would you like to go back to the previous room?");
                    string input = Console.ReadLine().Trim();
                    if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        var row = SavedRooms[SavedRooms.Count() - 2];
                        var room = row[row.Count() - 2];
                        var item = row[row.Count() - 1];
                        Console.WriteLine(room);
                        return item;
                    }
                    else if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }


            
            
        }
    }
}
