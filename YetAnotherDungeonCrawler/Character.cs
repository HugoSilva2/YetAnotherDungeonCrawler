using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Character
    {
        public bool IsAlive { get; private set; } = true;
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }
        public List<Item> Inventory { get; set; }

        public Character(int maxHealth, int attackPower)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
            Inventory = new List<Item>();
        }
        
        public void Attack(Character target)
        {
            Console.WriteLine($"{Name} attacked {target.Name} for {AttackPower} damage.");
            target.Health -= AttackPower;
            if (target.Health <= 0)
            {
                target.Die();
                target.IsAlive = false;
            }
            else
            {
                Console.WriteLine($"{target.Name} has {target.Health} health remaining.");
            }
        }

        protected void Die()
        {
            Console.WriteLine($"{Name} has suffered a very tragic and painful death");
        }
    }
}
