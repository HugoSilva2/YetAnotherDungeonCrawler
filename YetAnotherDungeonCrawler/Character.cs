using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
        public class Character
    {
        public bool IsAlive { get; private set; } = true;
        public bool CanMove { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }
        public List<Item> Inventory { get; set; }
        public IView _view;

        public Character(int maxHealth, int attackPower, IView view)
        {
            MaxHealth = maxHealth;
            Health = maxHealth; 
            AttackPower = attackPower;
            Inventory = new List<Item>();
            _view = view;
        }
        
        public void Attack(Character target)
        {
            _view.Attack2(Name, target.Name, AttackPower);
            target.Health -= AttackPower;

            if (target.Health <= 0)
            {
                target.Die();
                target.IsAlive = false;
            }
            else
            {
                _view.ShowHP(target.Name, target.Health);
            }
        }

        public void Die()
        {
            if (Health <= 0)
            {
                _view.Die(Name);
            }
        }

        public void Respawn()
        {
            Health = MaxHealth;
            IsAlive = true;
            _view.Respawn(Name);
        }
    }

}
