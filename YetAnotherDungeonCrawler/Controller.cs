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

        public void Start(IView view)
        {
            view.Intro();

            player = new Player("Lord McBullshitus", 100, 20);
            rooms = new List<Room>
            {
                new Room(1, new Enemy("Loyal Intern", 50, 10), new List<Item> { new Item("Coffee Mug") }),
                new Room(2, new Enemy("Janitor", 80, 15), new List<Item> { new Item("Broom") }),
                new Room(3, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") })
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
                    case "move":
                        if (currentRoomIndex < rooms.Count - 1)
                        {
                            currentRoomIndex++;
                            view.Move(player.Name, currentRoomIndex);
                        }
                        else
                        {
                            Console.WriteLine("You can't move further.");
                        }
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
