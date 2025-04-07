using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        public string NewItem { get; private set; }
        public string ShowInventory { get; private set; }
        // Fully private property.
        private List<string> inventory = new List<string>();

        public Inventory()
        {

        }

        // Method to pick up the item in the current room.
        public void PickUpItem(string item)
        {
            Console.WriteLine($"{item} picked up!");
            NewItem = item;
            inventory.Add(item);
        }


        // Method to Show the contents of the inventory.
        public string InventoryContents()
        {
            // Checks if the inventory is empty or not
            if (inventory.Count == 0)
            {
                ShowInventory = ("Nothing :(");
            }
            else
            {
                ShowInventory = string.Join(", ", inventory);
            }
            return ShowInventory;
        }
    }
}
