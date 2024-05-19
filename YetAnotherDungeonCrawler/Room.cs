using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        int id { get; set; }

        Enemy enemy{ get; set; }
        List<Item> items { get; set; }
        Room(int id, Enemy enemy, List<Item> items)
        {
            id = id;
            Enemy = enemy;
            Items = items;
        }
        
    }
}