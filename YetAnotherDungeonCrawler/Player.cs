using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        private IView _view;

        public Player(string name, int maxHealth, int attackPower, IView view)
            : base(maxHealth, attackPower)
        {
            Name = name;
            _view = view;
        }

        public void Move(Room currentRoom, string direction)
        {
            if (currentRoom.Enemy == null)
            {
                Console.WriteLine($"{Name} moves {direction}.");
            }
            else
            {
                Console.WriteLine("You cannot move while there are enemies in the room.");
            }
        }

        public void PickupItem(Room currentRoom, Item item)
        {
            if (currentRoom.Enemy == null)
            {
                Inventory.Add(item);
                _view.PickUpItem(Name, item);
                currentRoom.Items.Remove(item); 
            }
            else
            {
                Console.WriteLine("You cannot pick up items while there are enemies in the room.");
            }
        }

        public void UseHealthPotion()
        {
            var potion = Inventory.Find(item => item.Name == "Health Potion");
            if (potion != null)
            {
                Health += 50;
                if (Health > MaxHealth) Health = MaxHealth;
                Inventory.Remove(potion);
                _view.Heal(Name, 50);
            }
            else
            {
                _view.NoPotion(); 
            }
        }

        public new void Respawn()
        {
            base.Respawn();
        }
    }
}
