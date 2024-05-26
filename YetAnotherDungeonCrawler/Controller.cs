using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        private Player player;
        private List<Room> rooms;
        private int currentRoomId;
        private bool gameRunning = false;

        public void Start(IView view)
        {
            view.Intro();

            player = new Player("Lord W Rizz", 100, 20, view);
            rooms = new List<Room>
            {
                new Room(-4, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(-3, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(-2, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(-1, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(0, new Enemy("Novice", 200, 30), new List<Item> { new Item("Health Potion") }),
                new Room(1, new Enemy("Loyal Intern", 50, 10), new List<Item> { new Item("Coffee Mug") }),
                new Room(2, new Enemy("Janitor", 80, 15), new List<Item> { new Item("Broom") }),
                new Room(3, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(4, new Enemy("Novice", 200, 30), new List<Item> { new Item("Artifact") })
            };

            gameRunning = true;
            while (gameRunning)
            {
                Room currentRoom = rooms.Find(r => r.Id == currentRoomId);
                view.DisplayRoomInfo(currentRoom);
                view.ListActions();
                string action = view.GetPlayerInput().ToLower();

                switch (action)
                {
                    case "move right":
                        if (currentRoom.Enemy == null)
                        {
                            currentRoomId += 1;
                            if (!rooms.Exists(r => r.Id == currentRoomId))
                            {
                                currentRoomId -= 1;
                                Console.WriteLine("Can't move any further");
                            }
                            else
                            {
                                view.Move(player.Name, currentRoomId);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You cannot move while there are enemies in the room.");
                        }
                        break;

                    case "use potion":
                        player.UseHealthPotion();
                        break;

                    case "move left":
                        if (currentRoom.Enemy == null)
                        {
                            currentRoomId -= 1;
                            if (!rooms.Exists(r => r.Id == currentRoomId))
                            {
                                currentRoomId += 1;
                                Console.WriteLine("Can't move any further");
                            }
                            else
                            {
                                view.Move(player.Name, currentRoomId);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You cannot move while there are enemies in the room.");
                        }
                        break;

                    case "attack":
                        if (currentRoom.Enemy != null)
                        {
                            player.Attack(currentRoom.Enemy);
                            if (currentRoom.Enemy.Health <= 0)
                            {
                                Console.WriteLine($"{currentRoom.Enemy.Name} was slain.");
                                currentRoom.Enemy = null;
                            }
                            else
                            {
                                currentRoom.Enemy.Attack(player);
                                if (player.Health <= 0)
                                {
                                    Console.WriteLine("You have been killed.");
                                    gameRunning = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no enemy to attack.");
                        }
                        break;

                    case "pickup":
                        if (currentRoom.Items.Count > 0)
                        {
                            player.PickupItem(currentRoom, currentRoom.Items[0]);
                        }
                        else
                        {
                            view.NoItem();
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

            view.TheEnd(player.Health > 0 && player.Inventory.Exists(item => item.Name == "Artifact"));
        }
    }
}
