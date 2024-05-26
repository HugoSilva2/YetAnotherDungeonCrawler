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
            Console.WriteLine($"{name} moves {id}.");
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
            
            Console.WriteLine("Items in the room:");
            if (room.Items.Count > 0)
            {
                foreach (var item in room.Items)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("No items in the room.");
            }
        }


        public string GetPlayerInput()
        {
            Console.Write("Enter your action: ");
            return Console.ReadLine();
        }

        public void ListActions()
        {
            Console.WriteLine("Possible actions:");
            Console.WriteLine(" - move right");
            Console.WriteLine(" - move left");
            Console.WriteLine(" - attack");
            Console.WriteLine(" - use potion");
            Console.WriteLine(" - pickup");
            Console.WriteLine(" - quit");
        }

        public void NoItem(Item item)
        {
            Console.WriteLine($"No {item} in inventory.");
        }
    }
}
