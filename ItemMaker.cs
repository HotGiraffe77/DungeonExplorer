using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    // Generates an Item. Either junk, or a weapon.
    internal class ItemMaker
    {
        private Random rand = new Random();
        private List<string> junkNames;
        private List<string> weaponNames;

        // Lists of names for the different item types.
        public ItemMaker()
        {
            junkNames = new List<string> { "Apple", "RustedSword", "SmallKey", "BrokenJar", "Dice", "DampCloth" };
            weaponNames = new List<string> { "Dagger", "BroadSword", "GreatSword" };
        }


        // Picks a random junk name and gives it 0 damage.
        public Item CreateJunk()
        {
            string itemType = junkNames[rand.Next(junkNames.Count())];
            return new Junk(itemType, 0);
        }

        // The method takes a number and generates the weapon accordingly.
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
