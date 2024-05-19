using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Move(name, id)
        {

        }

        public void Attack(string name1, string name2, int damage)
        {
            Console.WriteLine($"{name1} attacked {name2} for {damage} damage.")
        }

        public void Heal(string name, int heal)
        {
            Console.WriteLine($"{name} healed {heal} HP.");
        }

        public void RoomDescription()
        {

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

        }

        public void TheEnd()
        {
            Console.WriteLine("You got the Artifact!");
            Console.WriteLine("Thanks for playing our game!");
            Console.WriteLine("THE END");
        }

        void DisplayRoomInfo()
        {
            Console.WriteLine($"Enemy: {Enemy.Name}");
            Console.WriteLine($"Items in the room: {Items.Name}");
        }
        
    }
}