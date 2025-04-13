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


        }


        private void TestPlayer()
        {
            Player player = new Player("Test", 100, 15);

            Debug.Assert(player.Name == "Test", "Player name incorrect...");
            Debug.Assert(player.Health == 100, "Player health incorrect...");
            Debug.Assert(player.Damage == 15, "Player Damage incorrect...");

            Trace.WriteLine("Player methods tested successfully...");
        }

        private void TestCombat()
        {
            Player player = new Player("Test", 100, 15);
            Monster monster = new Monster("TestMonster", 20, 1);

            while (player.IsAlive && monster.IsAlive)
            {
                player.Attack(monster);
                if (monster.IsAlive)
                {
                    monster.Attack(player);
                }
            }

            Debug.Assert(player.IsAlive, "Player should have survived...");
            Debug.Assert(!monster.IsAlive, "Monster should have died...");

            Trace.WriteLine("Combat tested successfully.");

        }
    }
}
