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
        // Contains the tests that are run at the start of the program.
        public void RunTests()
        {

            Console.WriteLine("Running tests...");
            TestPlayer();
            TestCombat();
            TestGameFlow();


        }


        private void TestPlayer()
        {
            Player testplayer = new Player("Test", 100, 15);

            Debug.Assert(testplayer.Name == "Test", "Player name incorrect...");
            Debug.Assert(testplayer.Health == 100, "Player health incorrect...");
            Debug.Assert(testplayer.Damage == 15, "Player Damage incorrect...");

            Trace.WriteLine("Player methods tested successfully...");
        }

        private void TestCombat()
        {
            Player testplayer2 = new Player("Test", 100, 15);
            Monster testmonster = new Monster("TestMonster", 20, 1);

            while (testplayer2.IsAlive && testmonster.IsAlive)
            {
                testplayer2.Attack(testmonster);
                if (testmonster.IsAlive)
                {
                    testmonster.Attack(testplayer2);
                }
            }

            Debug.Assert(testplayer2.IsAlive, "Player should have survived...");
            Debug.Assert(!testmonster.IsAlive, "Monster should have died...");

            Trace.WriteLine("Combat tested successfully.");

        }

        private void TestGameFlow()
        {
            Console.WriteLine("Running integration test with Game class...");

            Game game = new Game();
            // Simulate player setup
            game.player = new Player("Tester", 100, 15);

            // Access the first room from map
            Room room1 = game.map.GetCurrentRoom();
            Debug.Assert(room1 != null, "Initial room should not be null.");
            Debug.Assert(room1.Items.Count >= 0, "Initial room should have an item list.");

            // Simulate movement north
            Room room2 = game.map.Move("north");
            Debug.Assert(room2 != null && !ReferenceEquals(room1, room2), "Should arrive in a new room when moving north.");

            // Simulate backtracking
            Room room1Again = game.map.Move("south");
            Debug.Assert(ReferenceEquals(room1, room1Again), "Should return to original room when moving back.");

            // Mark the room visited and simulate interaction
            room1.Visited = true;
            room1.Monster = null;
            room1.Items.Clear();

            // Call Game logic method manually if you create utility functions later

            Console.WriteLine("Integration test completed.");
        }
    }
}
