using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class View : IView
    {
        public void Intro()
        {
            Console.WriteLine("Welcome to Yet Another Dungeon Crawler!");
            Console.WriteLine("So here's the Rules:");
            Console.WriteLine("You must travel through this dungeon to find the long lost artifact");
            Console.WriteLine("There will be enemies and items in some rooms");
            Console.WriteLine("You can attack, move, pickup items and use items");
            Console.WriteLine("If you enter a room with an enemy you must kill the enemy before leaving");
            Console.WriteLine("The game ends when you die or when you retrieve the lost artifact!");
        }

        public void Move(string name, int id)
        {
            Console.WriteLine($"{name} moves to room {id}.");
        }

        public void Attack(string name1, string name2, int damage)
        {
            Console.WriteLine($"{name1} attacked {name2} for {damage} damage.");
        }

        public void Heal(string name, int heal)
        {
            Console.WriteLine($"{name} healed {heal} HP.");
        }

        public void RoomDescription()
        {
            Console.WriteLine("Room description here.");
        }

        public void PickUpItem(string name, Item item)
        {
            Console.WriteLine($"{name} picked up {item.Name}");
        }


        public void UI(int health, int maxhealth, int attackpower)
        {
            Console.Write($"Health: {health}/{maxhealth}");
            Console.WriteLine($"  Attack Power: {attackpower}");
        }

        public void Inventory()
        {
            Console.WriteLine("Displaying inventory.");
        }

        public void TheEnd(bool victory)
        {
            if (victory)
            {
                Console.WriteLine("Congratulations! You retrieved the long lost artifact!");
                Console.WriteLine("Thanks for playing our game!");
            }
            else
            {
                Console.WriteLine("You have been defeated.");
            }
            Console.WriteLine("THE END");
        }

        public void DisplayRoomInfo(Room room)
        {
            if (room.Enemy == null)
            {
                Console.WriteLine("Room Cleared");
            }
            else
            {
                Console.WriteLine($"Enemy: {room.Enemy.Name}");
            }
            Console.WriteLine("Items in the room: ");
            foreach (var item in room.Items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public string GetPlayerInput()
        {
            return Console.ReadLine();
        }

        public void ListActions()
        {
            Console.WriteLine("Available actions: move left, move right, attack, pickup, use potion, quit");
        }

        public void NoItem()
        {
            Console.WriteLine("No items to pick up.");
        }

        public void NoPotion()
        {
            Console.WriteLine("You have no health potions left.");
        }

        public void NoMove()
        {
            Console.WriteLine("You can't move any further");
        }

        public void MoveWhileEnemy()
        {
            Console.WriteLine("You cannot move while there are enemies in the room.");
        }

        public void EnemyDead(string name)
        {
            Console.WriteLine($"{name} was slain.");
        }

        public void NoEnemies()
        {
            Console.WriteLine("There is no enemy to attack.");
        }

        public void InvalidAction()
        {
            Console.WriteLine("Invalid action.");
        }

        public void NoPickUP()
        {
            Console.WriteLine("You cannot pick up items while there are enemies in the room.");
        }

        public void SkillIssue()
        {
            Console.WriteLine("You have been killed.");
        }

        public void Attack2(string thisName, string otherName, int attackpower)
        {
            Console.WriteLine($"{thisName} attacked {otherName} for {attackpower} damage.");
        }

        public void ShowHP(string name, int hp)
        {
            Console.WriteLine($"{name} has {hp} health remaining.");
        }

        public void Die(string Name)
        {
            Console.WriteLine($"{Name} has suffered a very tragic and painful death");
        }

        public void Respawn(string Name)
        {
            Console.WriteLine($"{Name} has respawned with full health.");
        }
    }
}
