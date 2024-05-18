using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
         private Player player;
        private List<Room> rooms;
        private int currentRoomIndex;
        private bool gameRunning = false;
        public void Start(IView view)
        {
            view.Intro();

            Player player = new Player("Lord McBullshitus", 100, 20);
            Room rooms = new List<Room>
            {
                new Room(1, new Enemy("Loyal Intern", 50, 10), new Item("Coffee Mug")),
                new Room(2, new Enemy("Jannitor", 80, 15), new Item("Broom")),
                new Room(3, new Enemy("Novice", 200, 30), new Item("Glasses"))
            };

            gameRunning = true;
            while (gameRunning)
            {
                Room currentRoom = rooms[currentRoomIndex];
                view.DisplayRoomInfo(currentRoom);
                string action = view.GetPlayerInput().ToLower();

                switch (action)
                {
                    case "move":
                        
                        
                        break;

                    case "attack":
                        player.Attack(currentRoom.Enemy);
                        if (currentRoom.Enemy.Health <= 0)
                        {
                            
                        }
                        else
                        {
                            
                        }
                        break;

                    case "pickup":
                        if (currentRoom.Item != null)
                        {
                            player.PickupItem(currentRoom.Item);
                            currentRoom.Item = null;  
                        }
                        else
                        {
                        
                        }
                        break;

                    case "quit":
                        gameRunning = false;
                        break;

                    default:
                        
                        break;
                }
            }
            

        }
    }
}