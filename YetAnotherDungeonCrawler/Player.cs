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

        public void UseHealthPotion()
        {
            var potion = Inventory.Find(item => item.Name == "Health Potion");
            if (potion != null)
            {
                Health += 50; 
                if (Health > MaxHealth) Health = MaxHealth; 
                Inventory.Remove(potion);
                Console.WriteLine($"{Name} used a Health Potion and restored health.");
            }
            else
            {
                Console.WriteLine("No Health Potion in inventory.");
            }
        }

        public void Respawn()
        {
            base.Respawn();
        }
    }

}
