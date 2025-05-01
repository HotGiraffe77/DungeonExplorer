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

        // Method to pick up the item in the current room by adding it to an inventory list.
        public void PickUpItem(Item item)
        {
            Console.WriteLine($"{item.Name} picked up!");
            NewItem = item;
            inventory.Add(NewItem);
        }


        // Method to Show the contents of the inventory.
        public int InventoryContents()
        {

            if (inventory.Count == 0)
            {
                Console.WriteLine("Nothing :(");
                return 0;
            }

            // Uses LINQ to group items by their runtime type (junk or weapon).
            var grouped = inventory
                    .GroupBy(item => item.GetType())
                    .OrderBy(group => group.Key.Name);


            // Outputs the name of each item type before going through the grouped items and outputting them in a list.
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
            return 1;
        }

        // Method used to "select" an item from the inventory list.
        public Item SelectItem(string itemName) // The user inputs the name of an item in the inventory they want to select.
        {
            // Searches the list for the first item whose name matches the users input.
            Item foundItem = inventory.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (foundItem != null)
            {
                return foundItem;
            }
            else
            {
                return null;
            }

        }

        // Calls the Use() method of the selected item.
        public void UseItem(Item item)
        {
            item.Use();
            return;
        }

        // Simply removes the selected item from the inventory list.
        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
            Console.WriteLine($"{item.Name} has been dropped.");
            return;
        }
    }
}
