using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        public Player(string name, int maxHealth, int attackPower, IView view)
            : base(maxHealth, attackPower, view)
        {
            Name = name;
            _view = view;
        }

        public void Move(string direction)
        {

            Console.WriteLine($"{Name} moves in {direction}.");
        }

        public void PickupItem(Item item)
        {
            Inventory.Add(item);
            _view.PickUpItem(Name, item);
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
                _view.NoItem();
            }
        }

        public new void Respawn()
        {
            base.Respawn();
        }
    }


}
