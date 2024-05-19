using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        public Player(string name, int maxHealth, int attackPower)
            : base(maxHealth, attackPower)
        {
            Name = name;
        }

        public void Move(string direction)
        {
            Console.WriteLine($"{Name} moves in {direction}.");
        }

        public void PickupItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{Name} picked up {item.Name}.");
        }

        public void Respawn()
        {
            if (!IsAlive)
            {
                // Reset game
            }
        }
    }
}
