using System;
using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains all the logic for the game to run.
    /// This class has a method with the main game loop inside.
    /// </summary>
    internal class Game
    {
        // Private sets.
        public Player player { get; private set; }
        public Room currentRoom { get; private set; }
        public Test testing = new Test();
        public GameMap map { get; private set; }
        public string Username { get; private set; }

        public Game()
        {
            currentRoom = new Room();
            map = new GameMap();
            player = new Player("Username", 10);

        }

        // Method to start the main game loop.
        public void Start()
        {

            bool playing = true;
            while (playing)
            {
                testing.RunTests();
                // Gets the users name.(Calls GetName())
                Username = player.GetName();
                Console.WriteLine($"Hello, {Username}!");
                ConsoleKey Key;
                do
                {
                    Console.WriteLine("Press Enter to start the game...");
                    Key = Console.ReadKey(true).Key;
                }
                while (Key != ConsoleKey.Enter);

                // The player has 6 turns to go through the dungeon.
                int TurnCount = 6;
                while (TurnCount > 0)
                {
                    // Gets the description and item for the room.(Calls GetDescription() and GetItems())
                    string _room = currentRoom.GetDescription();
                    string _item = currentRoom.GetItems();
                    map.SaveRoom(_room, _item);
                    Console.WriteLine(_room);
                    // Gets the users input to continue.
                    Console.WriteLine($"In the room there is a {_item}.");
                    // Loops until the user enters a valid input.
                    bool condition = true;
                    while (condition == true)
                    {
                        Console.WriteLine(" Press Space to pick it up, I to check your inventory, M to check your map, or E to enter the next room...");
                        ConsoleKey PickupInput;
                        PickupInput = Console.ReadKey(true).Key;

                        if (PickupInput == ConsoleKey.Spacebar)
                        {
                            // Adds the item to the inventory list. (Calls PickUpItem())
                            player.PickUpItem(_item);
                            Console.WriteLine("Press any key to enter the next room...");
                            PickupInput = Console.ReadKey(true).Key;
                            condition = false;
                        }
                        else if (PickupInput == ConsoleKey.I)
                        {
                            // Displays the contents of the inventory. (calls InventoryContents())
                            Console.WriteLine($"Your inventory currently has: {player.InventoryContents()}");
                            Console.WriteLine($"Press Space to pick up {_item}, or Enter to enter the next room...");
                            PickupInput = Console.ReadKey(true).Key;
                        }
                        else if (PickupInput == ConsoleKey.M)
                        {
                            _item = map.PrintRooms();
                            Console.WriteLine($"In the room there is a {_item}");
                            PickupInput = Console.ReadKey(true).Key;
                            
                        }
                        else if (PickupInput == ConsoleKey.E)
                        {
                            // Continues the game.
                            condition = false;
                        }
                    }
                    TurnCount -= 1;

                }

                // Displays the inventory before ending the game.
                Console.WriteLine("\nYou made it through the dungeon! Thanks for playing." +
                    $"\nIn the end you collected: {player.InventoryContents()}" +
                    "\nPress any key to end the game...");
                Console.ReadKey();
                playing = false;
            }
        }
    }
}