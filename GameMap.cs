using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class GameMap
    {
        private Dictionary<(int, int), Room> rooms = new Dictionary<(int, int), Room>();


        private (int x, int y) playerPosition = (0, 0);

        private ItemMaker itemMaker = new ItemMaker();
        private MonsterMaker monsterMaker = new MonsterMaker();

        public GameMap()
        {
            var startingRoom = GenerateRoom();
            rooms[playerPosition] = startingRoom;
        }

        public Room GetCurrentRoom()
        {
            return rooms[playerPosition];
        }

        public Room Move(string direction)
        {
            int dx = 0, dy = 0;
            direction = direction.ToLower();

            if (direction == "north") dy = 1;
            else if (direction == "south") dy = -1;
            else if (direction == "east") dx = 1;
            else if (direction == "west") dx = -1;
            else throw new ArgumentException("Invalid direction");

            var newPos = (playerPosition.x + dx, playerPosition.y + dy);

            if (!rooms.ContainsKey(newPos))
            {
                var newRoom = GenerateRoom();
                rooms[newPos] = newRoom;
                rooms[playerPosition].Connect(direction, newRoom);
            }

            playerPosition = newPos;
            return rooms[playerPosition];
        }


        private Room GenerateRoom()
        {
            Random rand = new Random();
            int randItem = rand.Next(0, 3);
            if (randItem == 0 || randItem == 1)
            {
                var items = new List<Item>
                {
                    itemMaker.CreateJunk()
                };

                if (rand.NextDouble() < 0.5)
                {
                    items.Add(itemMaker.CreateJunk());
                }

                var monster = monsterMaker.CreateMonster();
                return new Room(items, monster);
            }
            else
            {
                randItem = rand.Next(0, 3);
                var items = new List<Item>
                {
                    itemMaker.CreateWeapon(randItem)
                };

                if (rand.NextDouble() < 0.5)
                {
                    items.Add(itemMaker.CreateJunk());
                }
                var monster = monsterMaker.CreateMonster();
                return new Room(items, monster);
            }
        }

        public int PrintVisitedMap()
        {
            Console.WriteLine($"You have visited {rooms.Count} rooms so far.");
            return rooms.Count;
        }
    }
}
