using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Character
    {
        bool IsAlive = true;
        bool canMove = false;
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }
        public List<Item> Inventory { get; set; }

        Character(int MaxHealth, int AttackPower)
        {
            MaxHealth = MaxHealth;
            MaxHealth = MaxHealth;
            AttackPower = AttackPower;
            Inventory = new List<Item>();
        }
        
        void Attack(something)
        {
            Console.WriteLine($"{Name} attacked {something.Name} for {AttackPower} damage.");
            something.Health -= AttackPower;
            if (something.Health <= 0)
            {
                //Call Die Method
                Die();
                something.IsAlive = false;
            }
            else
            {
                Console.WriteLine($"{something.Name} has {something.Health} health remaining.");
            }
        }

        void Die()
        {
            if (something.Health <= 0)
            {
                Console.WriteLine($"{something.Name} has suffered a very tragic and painfull death");
            }
        }
    }
}