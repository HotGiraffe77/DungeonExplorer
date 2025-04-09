using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class ItemMaker
    {
        private Random rand = new Random();
        private List<string> junkNames;
        private List<string> weaponNames;

        public ItemMaker()
        {
            junkNames = new List<string> { "Apple", "Rusted Sword", "Small Key", "Broken Jar", "Dice", "Damp Cloth" };
            weaponNames = new List<string> { "Dagger", "Broad Sword", "Great Sword" };
        }


        public Item CreateJunk()
        {
            string itemType = junkNames[rand.Next(junkNames.Count())];
            return new Junk(itemType, 0);
        }

        public Item CreateWeapon(int weaponChoice)
        {
            switch (weaponChoice)
            {
                case 0:
                    return new Weapon(weaponNames[0], 15);
                case 1:
                    return new Weapon(weaponNames[1], 25);
                case 2:
                    return new Weapon(weaponNames[2], 50);
                default:
                    throw new ArgumentException("Cannot create a weapon");

            }
            
        }


    }
}
