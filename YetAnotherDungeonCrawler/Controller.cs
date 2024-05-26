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

            player = new Player("Lord W Rizz", 100, 20);
            rooms = new List<Room>
            {
                new Room(-4, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(-3, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(-2, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(-1, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(0, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(1, new Enemy("Loyal Intern", 50, 10), new List<Item> { new Item("Coffee Mug") }),
                new Room(2, new Enemy("Janitor", 80, 15), new List<Item> { new Item("Broom") }),
                new Room(3, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") }),
                new Room(4, new Enemy("Novice", 200, 30), new List<Item> { new Item("Glasses") })
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
                        MovePlayer(1, view);
                        break;

                    case "move left":
                        MovePlayer(-1, view);
                        break;

                    case "use potion":
                        player.UseHealthPotion();
                        break;

                    case "attack":
                        PerformAttack(currentRoom, view);
                        break;

                    case "pickup":
                        PickupItem(currentRoom, view);
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

        private void MovePlayer(int direction, IView view)
        {
            currentRoomId += direction;
            if (!rooms.Exists(r => r.Id == currentRoomId))
            {
                currentRoomId -= direction;
                Console.WriteLine("Can't move any further");
            }
            else
            {
                view.Move(player.Name, currentRoomId);
            }
        }

        private void PerformAttack(Room currentRoom, IView view)
        {
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
        }

        private void PickupItem(Room currentRoom, IView view)
        {
            if (currentRoom.Items.Count > 0)
            {
                var item = currentRoom.Items[0];
                player.PickupItem(item);
                currentRoom.Items.Remove(item);
                if (item.Name == "Artifact")
                {
                    Console.WriteLine("You have found the long lost artifact!");
                    gameRunning = false;
                }
            }
            else
            {
                Console.WriteLine("No items to pick up.");
            }
        }
    }
}
   