using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        private Player player;
        private List<Room> rooms;
        private int currentRoomIndex;
        private bool gameRunning = false;

        private int currentRoomId = 0;

        public void Start(IView view)
        {
            view.Intro();

            player = new Player("Lord W Rizz", 100, 20);
            rooms = new List<Room>
            {
                new Room(0, new Enemy("Loyal Intern", 50, 10), new List<Item> { new Item("Coffee Mug") }),
                new Room(7, new Enemy("Janitor", 80, 15), new List<Item> { new Item("Broom") }),
                new Room(2, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") })
            };

            gameRunning = true;
            while (gameRunning)
            {
                Room currentRoom = rooms[currentRoomIndex];
                view.DisplayRoomInfo(currentRoom);
                view.ListActions();
                string action = view.GetPlayerInput().ToLower();

                switch (action)
                {
                    case "move right":
                        currentRoomIndex += 2;
                        if (currentRoomIndex >= rooms.Count)
                        {
                            Console.WriteLine("Can't move any further");
                            break;                       
                        }
                        view.Move(player.Name, currentRoomIndex);

                        break;
                    case "move left":
                        currentRoomIndex -= 2;
                        view.Move(player.Name, currentRoomIndex);

                        break;

                    case "move up":
                        currentRoomIndex += 7;
                        view.Move(player.Name, currentRoomIndex);

                        break;

                    case "move down":
                        currentRoomIndex -= 7;
                        view.Move(player.Name, currentRoomIndex);

                        break;

                    case "attack":
                        player.Attack(currentRoom.Enemy);
                        if (currentRoom.Enemy.Health <= 0)
                        {
                            Console.WriteLine($"{currentRoom.Enemy.Name} was slain.");
                            currentRoom.Enemy = null;  // Remove enemy
                        }
                        break;

                    case "pickup":
                        if (currentRoom.Items.Count > 0)
                        {
                            var item = currentRoom.Items[0];
                            player.PickupItem(item);
                            currentRoom.Items.Remove(item);
                        }
                        else
                        {
                            Console.WriteLine("No items to pick up.");
                        }
                        break;

                    case "quit":
                        gameRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid action.");
                        break;
                }
            }

            view.TheEnd();
        }
    }
}
