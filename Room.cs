using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;


namespace DungeonExplorer
{
    // Rooms have descriptions, items and a monster. It also has a flag that tracks whether it has been visited or not.
    public class Room
    {


        // List of room descriptions.
        private static List<string> RoomDescriptions = new List<string> {
            "\nRows of rusted chains hang from the ceiling, the walls lined with crude iron shackles. In the center of the room stands, a single, bloodstained alter.",
            "\nA damp, musty odor lingers in this ancient burial chamber. Cracked sarcophagi line the walls. The air is unnervingly still.",
            "\nTowering bookshelves, coated in centuries of dust. Ancient tomes and scrolls lay scattered on the floor. A thick fog clings to the ground.",
            "\nMirrors of varying sizes cover the walls from floor to ceiling. Some reflections move independently, their eyes filled with malice. A fine layer of mist creeps along the floor.",
            "\nThe floor squelches with every step as thick slime coats the stone floors. Occasional bubbles rise and pop. The walls ooze with the same sticky substance",
            "\nThis vast, domed chamber seems unnaturally large. Shadows flicker abnormally. In the center of the room, a pedestal holds a cracked hourglass" };

        private static Random rand = new Random();


        public string Description { get; private set; }
        public List<Item> Items { get; private set; }
        public Monster Monster { get; set; }
        public bool Visited { get; set; }
        // Dictionary that maps directions to different rooms.
        public Dictionary<string, Room> Exits { get; private set; }


        // Constructs a new room with a random description, items, and a monster.
        public Room(List<Item> items = null, Monster monster = null)
        {
            Description = RoomDescriptions[rand.Next(RoomDescriptions.Count)];
            Items = items ?? new List<Item>();
            Monster = monster;
            Visited = false;
            Exits = new Dictionary<string, Room>();
        }


        // Method to connect two rooms in a specific direction. Adds the opposite direction to the other room.
        public void Connect(string direction, Room otherRoom)
        {
            Exits[direction] = otherRoom;
            string opposite = GetOppositeDirection(direction);
            if (!otherRoom.Exits.ContainsKey(opposite))
            {
                otherRoom.Exits[opposite] = this;
            }
        }

        // Returns the opposite direction of the given direction.
        private string GetOppositeDirection(string direction)
        {
            direction = direction.ToLower();

            if (direction == "north") return "south";
            if (direction == "south") return "north";
            if (direction == "east") return "west";
            if (direction == "west") return "east";

            throw new ArgumentException("Invalid direction");
        }

        // Generates an output for the summary of the room. Outputs a description of the room, the list of items in it and the monster.
        public string GetSummary()
        {
            string summary = $"{Description}\n";

            if (Monster != null && Monster.IsAlive)
            {
                summary += $"A {Monster.Name} lurks here...\n";
            }

            if (Items.Count > 0)
            {
                summary += "A chest lies in the corner. It contains:\n";
                foreach (var item in Items)
                {
                    summary += $"- {item.Name}\n";
                }
            }

            summary += $"Exits: {string.Join(", ", Exits.Keys)}";
            return summary;
        }
    }
}





