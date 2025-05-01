using System;
using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    // Contains all the logic for the game to run.
    internal class Game
    {
        // Core components of the game.
        public Player player { get;  set; }
        public MonsterMaker monsterType { get; private set; }
        public ItemMaker itemMaker { get; private set; }
        public Monster monster { get; private set; }
        public Item item { get; private set; }
        public Room currentRoom { get; private set; }
        public Test testing = new Test();
        public GameMap map { get; private set; }
        public Inventory inventory { get; private set; }
        public Statistics stats { get; private set; }
        public string Username { get; private set; }

        // Constructor to initialize the game components.
        public Game()
        {
            currentRoom = new Room();
            map = new GameMap();
            inventory = new Inventory();
            monsterType = new MonsterMaker();
            itemMaker = new ItemMaker();
            stats = new Statistics();

        }

        // Method to start the main game loop.
        public void Start()
        {
            testing.RunTests();

            bool playing = true;

            // Prompts the user for their name and sets a default if none is provided.
            Console.WriteLine("Please enter a username: ");
            Username = Console.ReadLine();
            if (string.IsNullOrEmpty(Username))
            {
                Username = "Blank";
            }

            Console.WriteLine($"Hello, {Username}!");
            Console.WriteLine("Press Enter to start the game...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            
            // Initialises the player and starting room.
            player = new Player(Username, 250, 15);
            currentRoom = map.GetCurrentRoom();


            // Main game loop.
            while (playing && player.IsAlive)
            {
                currentRoom = map.GetCurrentRoom();
                Console.WriteLine("\n-------------------");

                // First time visiting a room.
                if (!currentRoom.Visited)
                {
                    Console.WriteLine(currentRoom.GetSummary());
                    currentRoom.Visited = true;

                    // Monster encounter.
                    if (currentRoom.Monster != null && currentRoom.Monster.IsAlive)
                    {
                        currentRoom.Monster.Speak();

                        // Main combat loop.
                        while (currentRoom.Monster.IsAlive && player.IsAlive)
                        {
                            Console.WriteLine("Press any key to attack...");
                            Console.ReadKey(true);
                            player.Attack(currentRoom.Monster);
                            if (currentRoom.Monster.IsAlive)
                                currentRoom.Monster.Attack(player);
                        }

                        if (!player.IsAlive)
                        {
                            Console.WriteLine("You were defeated...");
                            playing = false;
                            break;
                        }

                        Console.WriteLine($"You defeated the {currentRoom.Monster.Name}!");
                        stats.countKills();
                    }

                    // Item pickup interaction.
                    if (currentRoom.Items.Count > 0)
                    {
                        // Lists the item/s in a room.
                        Console.WriteLine("You walk over to the chest containing: ");
                        foreach (var item in currentRoom.Items)
                        {
                            Console.WriteLine($"- {item.Name}");
                        }



                        Console.WriteLine("Press P to pick it up, I to open inventory, M to show map, or any other key to continue...");
                        ConsoleKey PickUpInput = Console.ReadKey(true).Key;

                        // P picks up the item and adds it to the inventory.
                        if (PickUpInput == ConsoleKey.P)
                        {
                            foreach (var item in currentRoom.Items)
                            {
                                inventory.PickUpItem(item);
                                if (item is Weapon)
                                    player.Damage = item.Damage;
                            }
                            currentRoom.Items.Clear();
                            stats.countItems();

                        }

                        // I opens the inventory and allows the player to use or remove an item.
                        else if (PickUpInput == ConsoleKey.I)
                        {
                            // Lists the items in the inventory.
                            Console.WriteLine($"Your inventory currently has:");
                            int getInv = inventory.InventoryContents();
                            // If the inventory has items in it allows selection.
                            if (getInv == 1)
                            {
                                Console.WriteLine("Please type the name of the item you would like to select...");
                                string rawItemName = Console.ReadLine();
                                string itemName = rawItemName.Replace(" ", "");

                                Item foundItem = inventory.SelectItem(itemName);

                                if (foundItem == null)
                                {
                                    Console.WriteLine("Item not found in inventory.");
                                }
                                else
                                {
                                    // Prompts user to use or remove the item.
                                    Console.WriteLine($"You selected {foundItem.Name}. Would you like to use the item or remove it from your inventory ? (use / remove)");
                                    string input = Console.ReadLine().Trim();


                                    if (input.Equals("use", StringComparison.OrdinalIgnoreCase))
                                    {
                                        inventory.UseItem(foundItem);
                                        if (foundItem is Weapon)
                                        {
                                            player.Damage = foundItem.Damage;

                                        }
                                    }
                                    else if (input.Equals("remove", StringComparison.OrdinalIgnoreCase))
                                    {
                                        inventory.RemoveItem(foundItem);
                                    }
                                    else
                                    {
                                        Console.WriteLine("That is not a valid command...");
                                    }
                                }
                            }
                            
                            
                        }
                        // Prints the number of vistied rooms.
                        else if (PickUpInput == ConsoleKey.M)
                        {
                            map.PrintVisitedMap();
                        }


                    }

                    // If the player chooses to continue, they are prompted for a direction.
                    string direction;
                    while (true)
                    {
                        Console.WriteLine("Which direction would you like to go? (north/south/east/west) or Q to quit");
                        direction = Console.ReadLine().Trim().ToLower();
                        if (direction == "north" || direction == "south" || direction == "east" || direction == "west")
                        {
                            break;
                        }
                        else if (direction == "q")
                        {
                            break;
                        }
                    }
                    if (direction == "q")
                    {
                        playing = false;
                        break;
                    }
                    try
                    {
                        currentRoom = map.Move(direction);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid PickUpInput: {ex.Message}");
                    }
                    stats.countRooms();

                }
                // If the player has already visited the room, they are given a summary of the room.
                else
                {
                    // Summary of the room.
                    Console.WriteLine("You've returned to a familiar room:");
                    Console.WriteLine(currentRoom.Description);
                    Console.WriteLine($"Exits: {string.Join(", ", currentRoom.Exits.Keys)}");

                    // Prompts the user for a direction to go.
                    Console.WriteLine("Which direction would you like to go? (north/south/east/west) or Q to quit:");
                    string revisitDirection = Console.ReadLine().Trim().ToLower();

                    while (true)
                    {
                        Console.WriteLine("Which direction would you like to go? (north/south/east/west) or Q to quit");
                        revisitDirection = Console.ReadLine().Trim().ToLower();
                        if (revisitDirection == "north" || revisitDirection == "south" || revisitDirection == "east" || revisitDirection == "west")
                        {
                            break;
                        }
                        else if (revisitDirection == "q")
                        {
                            break;
                        }
                    }
                    if (revisitDirection == "q")
                    {
                        playing = false;
                        break;
                    }
                    try
                    {
                        currentRoom = map.Move(revisitDirection);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid PickUpInput: {ex.Message}");
                    }

                    // Skip rest of the loop and re-enter with new currentRoom
                    continue;
                }

            }
            // Displays the inventory before ending the game.
            if (playing)
            {
                Console.WriteLine("\nYou made it through the dungeon! Thanks for playing." +
                $"\nIn the end you collected:");
                inventory.InventoryContents();
                stats.conclusion();
                Console.WriteLine("\nPress any key to end the game...");


            }
            else
            {
                Console.WriteLine("Thanks for playing!" +
                $"\nIn the end you collected:");
                inventory.InventoryContents();
                stats.conclusion();
                Console.WriteLine("\nPress any key to end the game...");
            }
            Console.ReadKey();
            playing = false;
        }
    }
}
