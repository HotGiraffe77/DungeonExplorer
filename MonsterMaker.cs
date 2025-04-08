using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class MonsterMaker
    {
        private Random random = new Random();

        public Monster CreateMonster()
        {
            int monsterType = random.Next(1, 4);

            switch (monsterType)
            {
                case 1:
                    return new Goblin();
                case 2:
                    return new Orc();
                case 3:
                    return new Dragon();
                default:
                    throw new Exception("Cannot create monster.");
            }
        }
    }
}
