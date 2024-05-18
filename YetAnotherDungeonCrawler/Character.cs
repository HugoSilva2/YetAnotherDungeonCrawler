using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Character
    {
        bool canMove = false;
        string Name { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int AttackPower { get; set; }
        List<Item> Inventory { get; set; }
    }

    Character(int MaxHealth, int AttackPower,)
    {
        MaxHealth = MaxHealth;
        MaxHealth = MaxHealth;
        AttackPower = AttackPower;
        Inventory = new List<Item>();
    }
    
    void Attack(Enemy enemy)
    {
        Console.WriteLine($"{Name} attacked {enemy.Name} for {AttackPower} damage.");
        enemy.Health -= AttackPower;
        if (enemy.Health <= 0)
        {
            Console.WriteLine($"{enemy.Name} was slain.")
            enemy.Health = 0;
        }
        else
        {
            Console.WriteLine($"{enemy.Name} has {enemy.Health} health remaining.");
        }
    }

    void Move(string direction)
    {
        Console.WriteLine($"{Name} Moves in {direction}.");
    }

    void PickupItem(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"{Name} picked up {item.Name}.");
    }
}