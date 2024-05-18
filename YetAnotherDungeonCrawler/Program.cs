﻿using System;

namespace YetAnotherDungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
        
            IView view = new View();

            controller.Start(view);
       }
    }
}
