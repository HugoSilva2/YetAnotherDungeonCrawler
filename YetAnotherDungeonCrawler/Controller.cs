using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        public void Start(IView view)
        {
            view.Intro();

            player = new Player("Lord McBullshitus", 100, 20);
            rooms = new List<Room>
            {
                new Room(1, new Enemy("Loyal Intern", 50, 10), new Item("Coffee Mug")),
                new Room(2, new Enemy("Jannitor", 80, 15), new Item("Broom")),
                new Room(3, new Enemy("Novice", 200, 30), new Item("Glasses"))
            };
            

        }
    }
}