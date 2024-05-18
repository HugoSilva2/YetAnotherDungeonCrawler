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
            enemy = new Enemy("Corporate Bad Guy", 50, 10);
            

        }
    }
}