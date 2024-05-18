using System;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        public Player(string name, int maxHealth, int attackPower)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
            Inventory = new List<InventoryItem>();
            
            void Move(string direction)
            {
                Console.WriteLine($"{Name} Moves in {direction}.");
            }

            void PickupItem(Item item)
            {
                Inventory.Add(item);
                Console.WriteLine($"{Name} picked up {item.Name}.");
            }    
            
            void Respawn()
            {
                if (!player.IsAlive)
                {
                    //Resets game

                }
            }
        }
    }
}