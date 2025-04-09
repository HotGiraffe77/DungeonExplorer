using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        public Item NewItem { get; private set; }
        public string ShowInventory { get; private set; }

        private List<Item> inventory = new List<Item>();

        public Inventory()
        {

        }

        // Method to pick up the item in the current room.
        public void PickUpItem(Item item)
        {
            Console.WriteLine($"{item.Name} picked up!");
            NewItem = item;
            inventory.Add(NewItem);
        }


        // Method to Show the contents of the inventory.
        public void InventoryContents()
        {
            // Checks if the inventory is empty or not
            if (inventory.Count == 0)
            {
                Console.WriteLine("Nothing :(");
                return;
            }

            var grouped = inventory
                    .GroupBy(item => item.GetType())
                    .OrderBy(group => group.Key.Name);

            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key.Name}:");

                if (!group.Any())
                {
                    Console.WriteLine("Nothing :(");
                }
                else
                {
                    foreach (var item in group)
                    {
                        Console.WriteLine($"- {item.Name}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
