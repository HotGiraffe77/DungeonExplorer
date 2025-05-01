using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Represents the map of the game, handles room generation and player movement.
    internal class GameMap
    {
        // Dictionary stores the rooms with their coordinates as keys.
        private Dictionary<(int, int), Room> rooms = new Dictionary<(int, int), Room>();

        // Stores the current player coordinates.
        private (int x, int y) playerPosition = (0, 0);

        private ItemMaker itemMaker = new ItemMaker();
        private MonsterMaker monsterMaker = new MonsterMaker();

        // Initialises the map by generating the starting room and placing it at (0, 0).
        public GameMap()
        {
            var startingRoom = GenerateRoom();
            rooms[playerPosition] = startingRoom;
        }

        // Returns the current room the player is in.
        public Room GetCurrentRoom()
        {
            return rooms[playerPosition];
        }

        // Moves the player in the specified direction. Generates a new room if there isnt one there.
        public Room Move(string direction)
        {
            int dx = 0, dy = 0;
            direction = direction.ToLower();

            // Determines the direction offset.
            if (direction == "north") dy = 1;
            else if (direction == "south") dy = -1;
            else if (direction == "east") dx = 1;
            else if (direction == "west") dx = -1;
            else throw new ArgumentException("Invalid direction");

            // Calculates new coordinates.
            var newPos = (playerPosition.x + dx, playerPosition.y + dy);

            // If no room exists there create a new one.
            if (!rooms.ContainsKey(newPos))
            {
                var newRoom = GenerateRoom();
                rooms[newPos] = newRoom;
                rooms[playerPosition].Connect(direction, newRoom);
            }

            // Updtaes player position.
            playerPosition = newPos;
            return rooms[playerPosition];
        }

        // Generates a new room with random items and a monster.
        // 50% chance of having an extra weapon or junk item.
        private Room GenerateRoom()
        {
            Random rand = new Random();
            int randItem = rand.Next(0, 3);
            if (randItem == 0 || randItem == 1)
            {
                // Generates junk.
                var items = new List<Item>
                {
                    itemMaker.CreateJunk()
                };

                // Chance to add another junk item.
                if (rand.NextDouble() < 0.5)
                {
                    items.Add(itemMaker.CreateJunk());
                }

                var monster = monsterMaker.CreateMonster();
                return new Room(items, monster);
            }
            else
            {
                // Generates weapon.
                randItem = rand.Next(0, 3);
                var items = new List<Item>
                {
                    itemMaker.CreateWeapon(randItem)
                };


                // Chance to add another junk item.
                if (rand.NextDouble() < 0.5)
                {
                    items.Add(itemMaker.CreateJunk());
                }
                var monster = monsterMaker.CreateMonster();
                return new Room(items, monster);
            }
        }

        // Outputs the number of unique rooms visited so far.
        public int PrintVisitedMap()
        {
            Console.WriteLine($"You have visited {rooms.Count} rooms so far.");
            return rooms.Count;
        }
    }
}
