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
        public MonsterMaker monsterType { get; private set; }
        public ItemMaker itemMaker { get; private set; }
        public Monster monster { get; private set; }
        public Item item { get; private set; }
        public Room currentRoom { get; private set; }
        public Test testing = new Test();
        public GameMap map { get; private set; }
        public Inventory inventory { get; private set; }
        public string Username { get; private set; }

        public Game()
        {
            currentRoom = new Room();
            map = new GameMap();
            inventory = new Inventory();
            monsterType = new MonsterMaker();
            itemMaker = new ItemMaker();

        }

        // Method to start the main game loop.
        public void Start()
        {

            bool playing = true;
            while (playing)
            {
                testing.RunTests();
                // Gets the users name.(Calls GetName())
                Console.WriteLine("Please enter a username: ");
                string username = Console.ReadLine();
                if (string.IsNullOrEmpty(username))
                {
                    username = "Blank";
                }
                Console.WriteLine($"Hello, {username}!");

                ConsoleKey Key;
                do
                {
                    Console.WriteLine("Press Enter to start the game...");
                    Key = Console.ReadKey(true).Key;
                }
                while (Key != ConsoleKey.Enter);

                // The player has 6 turns to go through the dungeon.
                player = new Player(username, 1000, 15);
                int TurnCount = 6;
                while (TurnCount > 0)
                {
                    string _room = currentRoom.GetDescription();
                    if (TurnCount == 5)
                    {
                        item = itemMaker.CreateWeapon(1);
                    }
                    else if (TurnCount == 3)
                    {
                        item = itemMaker.CreateWeapon(2);
                    }
                    else
                    {
                        item = itemMaker.CreateJunk();
                    }

                    monster = monsterType.CreateMonster();
                    map.SaveRoom(_room, item.Name);
                    Console.WriteLine(_room);
                    Console.WriteLine($"In the room there is a {monster.Name} guarding a chest.");
                    monster.Speak();
                    while (monster.IsAlive && player.IsAlive)
                    {
                        Console.WriteLine($"Press any key to attack the {monster.Name}.");
                        Console.ReadKey();
                        player.Attack(monster);
                        if (monster.IsAlive)
                        {
                            monster.Attack(player);
                        }
                    }
                    if (!player.IsAlive)
                    {
                        Console.WriteLine("You were defeated...");
                        playing = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You defeated the monster.");

                    }
                    Console.WriteLine($"The chest the monster was guarding contains a {item.Name}");



                    bool condition = true;
                    while (condition == true)
                    {
                        Console.WriteLine(" Press P to pick it up, I to check your inventory, M to check your map, or E to enter the next room...");
                        ConsoleKey PickupInput;
                        PickupInput = Console.ReadKey(true).Key;

                        if (PickupInput == ConsoleKey.P)
                        {
                            // Adds the item to the inventory list. (Calls PickUpItem())
                            inventory.PickUpItem(item);
                            if (item is Weapon)
                            {
                                player.Damage = item.Damage;
                            }
                            Console.WriteLine("Press any key to enter the next room...");
                            PickupInput = Console.ReadKey(true).Key;
                            condition = false;
                        }
                        else if (PickupInput == ConsoleKey.I)
                        {
                            // Displays the contents of the inventory. (calls InventoryContents())
                            Console.WriteLine($"Your inventory currently has:");
                            inventory.InventoryContents();
                        }
                        else if (PickupInput == ConsoleKey.M)
                        {
                            item.Name = map.PrintRooms();
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
                if (playing)
                {
                    Console.WriteLine("\nYou made it through the dungeon! Thanks for playing." +
                    $"\nIn the end you collected:");
                    inventory.InventoryContents();
                    Console.WriteLine("\nPress any key to end the game...");


                }
                else
                {
                    Console.WriteLine("Thanks for playing!" +
                    $"\nIn the end you collected:");
                    inventory.InventoryContents();
                    Console.WriteLine("\nPress any key to end the game...");
                }
                Console.ReadKey();
                playing = false;
            }
        }
    }
}