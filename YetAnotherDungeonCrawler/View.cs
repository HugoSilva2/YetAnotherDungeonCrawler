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
        }
    }
}