using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        public int Id { get; private set; }
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