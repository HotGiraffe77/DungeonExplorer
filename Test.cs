using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;

namespace DungeonExplorer
{
    /// <summary>
    /// Tests various aspects of the program
    /// Contains a method that uses debug.assert() to run tests.
    /// </summary>
    internal class Test
    {
        public Player TestPlayer { get; private set; }
        public Room TestRoom { get; private set; }
        public Inventory TestInventory { get; private set; }

        // Contains the tests that are run at the start of the program.
        public void RunTests()
        {
            Console.WriteLine("Running tests...");

            //// Testing the username.
            //TestPlayer = new Player("Username", 10, 10);
            //Debug.Assert(TestPlayer.Name == "Username", "Player name should be Username.");
            //// Tests that the inventory starts empty.
            //Debug.Assert(TestInventory.InventoryContents() == "Nothing :(", "A new players inventory should be empty.");
            //// Tests that the items picked up are moved to the inventory.
            //TestInventory.PickUpItem("Health Potion");
            //Debug.Assert(TestInventory.InventoryContents().Contains("Health Potion"), "Inventory should have a health potion.");
            //// Testing the room description.
            //TestRoom = new Room();
            //string RoomDescription = TestRoom.GetDescription();
            //Debug.Assert(!string.IsNullOrEmpty(RoomDescription), "The Room description shoudln't be empty.");
            //// Testing the rooms item.
            //string RoomItem = TestRoom.GetItems();
            //Debug.Assert(!string.IsNullOrEmpty(RoomItem), "The room item shouldn't be empty");

            //Console.WriteLine("All tests finished successfully.");



        }
    }
}
