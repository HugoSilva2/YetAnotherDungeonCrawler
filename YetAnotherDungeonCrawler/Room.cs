using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        public int Id { get; set; }
        public Enemy Enemy { get; set; }
        public List<Item> Items { get; set; }

        public Room(int id, Enemy enemy, List<Item> items)
        {
            Id = id;
            Enemy = enemy;
            Items = items;
        }
    }
}
